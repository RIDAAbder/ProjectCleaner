using Autodesk.Revit.UI;
using Autodesk.Revit.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectCleaner
{
    class Main : IExternalApplication
    {
        public Result OnStartup(UIControlledApplication application)
        {
            var tabName = "ARK M&E";
            RevitUi.AddRibbonTab(application, tabName);
            //var settingPanel = RevitUi.AddRibbonPanel(application, tabName, "Settings");
            //var settingsBtn = RevitUi.AddPushButton(settingPanel, "Settings", typeof(Settings), Properties.Resources.settings, Properties.Resources.settings, typeof(AvailableIfOpenDoc));
            //settingsBtn.ToolTip = "Click to set the settings of the plugin.";

            var cleanPanel = RevitUi.AddRibbonPanel(application, tabName, "Clean Project");
            var deleteBtn = RevitUi.AddPushButton(cleanPanel, "Clean Project", typeof(Delete), Properties.Resources.delete, Properties.Resources.delete, typeof(AvailableIfOpenDoc));
            deleteBtn.ToolTip = "Click to clean the project parameters.";

            ContextualHelp contextHelp = new ContextualHelp(
            ContextualHelpType.ChmFile,
            "https://www.arkme.co.uk/");

            //settingsBtn.SetContextualHelp(contextHelp);
            deleteBtn.SetContextualHelp(contextHelp);
            return Result.Succeeded;
        }
        public Result OnShutdown(UIControlledApplication application)
        {
            return Result.Succeeded;
        }

        private class AvailableIfOpenDoc : IExternalCommandAvailability
        {
            public bool IsCommandAvailable(UIApplication applicationData, CategorySet selectedCategories)
            {
                if (applicationData.ActiveUIDocument != null && applicationData.ActiveUIDocument.Document != null)
                    return true;
                return false;
            }
        }
    }
}

