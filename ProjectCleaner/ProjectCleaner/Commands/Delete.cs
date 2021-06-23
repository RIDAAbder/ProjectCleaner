using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.DB.ExtensibleStorage;
using Autodesk.Revit.UI;
using VCExtensibleStorageExtension.ElementExtensions;


namespace ProjectCleaner
{
    [Transaction(TransactionMode.Manual)]
    [Regeneration(RegenerationOption.Manual)]
    class Delete : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIApplication uiapp = commandData.Application;
            UIDocument uidoc = uiapp.ActiveUIDocument;
            Document document = uidoc.Document;
            var list = new List<string>();

            DataStorage dataStorage = Helpers.GetDataStorage(document);
            if (null != dataStorage)
            {
                var entity = dataStorage.GetEntity<StorageForParameter>();

                if (entity != null)
                {
                    foreach (var item in entity.Names)
                    {
                        list.Add(item);
                    }
                }
            }

            var dlg = new deleteWindow(list);
            var result = dlg.ShowDialog();
            if (result != true) return Result.Cancelled;
            var newEntity = new StorageForParameter();
            var parametersNames = new List<string>();

            foreach (var item in dlg.parameters)
            {
                parametersNames.Add(item.Name);
            }
            newEntity.Names = parametersNames;

            try
            {
                using (var transaction = new Transaction(document, "Set entity"))
                {
                    transaction.Start("Set entity");
                    if (dataStorage == null)
                    {
                        dataStorage = DataStorage.Create(document);
                        dataStorage.Name = "ProjectDataStorage";
                    }

                    dataStorage.SetEntity(newEntity);

                    BindingMap bm = document.ParameterBindings;

                    var toDelete = new List<Definition>();
                    DefinitionBindingMapIterator it
                      = bm.ForwardIterator();
                    while (it.MoveNext())
                    {
                        Definition def = it.Key;

                        if (!parametersNames.Contains(def.Name))
                        {
                            toDelete.Add(def);
                        }
                    }
                    foreach (var def in toDelete)
                    {
                        bm.Remove(def);
                    }
                    transaction.Commit();
                }

            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, "", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);

            }
            System.Windows.Forms.MessageBox.Show("The shared parameters were deleted.", "", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);

            return Result.Succeeded;
        }
    }
}
