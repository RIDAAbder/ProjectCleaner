using Autodesk.Revit.DB;
using Autodesk.Revit.DB.ExtensibleStorage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectCleaner
{
    public static class Helpers
    {
        public static DataStorage GetDataStorage(Document objDocument)
        {
            return new FilteredElementCollector(objDocument)
                .OfClass(typeof(DataStorage))
                .Where<Element>(e => e.Name.Equals("ProjectDataStorage", StringComparison.InvariantCultureIgnoreCase))
                .FirstOrDefault() as DataStorage;
        }

    }
}
