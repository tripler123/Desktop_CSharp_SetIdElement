using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Windows;

using WinForms = System.Windows.Forms;
using System.Windows.Media.Imaging; // for ribbon, requires references to PresentationCore and WindowsBase .NET assemblies
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Architecture;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Events;
using DocumentSavingEventArgs = Autodesk.Revit.DB.Events.DocumentSavingEventArgs;


namespace setIdElement
{
    public class App : IExternalApplication
    {
        public Result OnShutdown(UIControlledApplication application)
        {
            return Result.Succeeded;
        }

        public Result OnStartup(UIControlledApplication app)
        {
            try
            {
                CreateRibbonItems(app);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                TaskDialog.Show("ERROR MESSAGE", ex.Message, TaskDialogCommonButtons.Ok);
            }
            return Result.Succeeded;
        }
        private void CreateRibbonItems(UIControlledApplication app)
        {
            //const string tabName = "360 GesPro";
            //app.CreateRibbonTab(tabName);
            //RibbonPanel pnLastPlanner = app.CreateRibbonPanel(tabName, pnName);
            const string pnName = "Information Management";
            RibbonPanel pnLastPlanner = app.CreateRibbonPanel(pnName);


            LPAddPushButton(pnLastPlanner);

        }

        public void LPAddPushButton(RibbonPanel panel)
        {
            const string cmd1 = "setIdElement.setIdElement";
            const string name1 = "Set Element ID";
            const string text1 = "Set Element ID";

            PushButtonData pbd1 = new PushButtonData(name1, text1, addAssemblyPath, cmd1);
            pbd1.LongDescription = "This small, but useful, application allows users to use, within a shared parameter or project parameter, the element ID information. This allows the user to create quantification tables with this information and be able to export it for later control and monitoring. " +
                                    "\n \n HOW TO USE? \n \n" +
                                    "- The user can choose the parameter where he wants to save the item ID information. \n" +
                                    "- The parameter can be a shared parameter or an existing project parameter. \n" +
                                    "- After the user executes the application, he can verify that each element has the ID of the element within the parameter selected by the user. \n" +
                                    "- This option allows the user to have this information within the quantization tables. \n";

            PushButton pb1 = panel.AddItem(pbd1) as PushButton;

            ContextualHelp contextHelp = new ContextualHelp(ContextualHelpType.Url,
                "https://tripler123.github.io/360GESPRO/ElementID");
            pb1.SetContextualHelp(contextHelp);

            SetIconsForPushButton(pb1, Properties.Resources.ID_Logo);
        }

        #region Metodos
        private static void SetIconsForPushButton(PushButton button, System.Drawing.Icon icon)
        {
            button.LargeImage = GetStdIcon(icon);
            button.Image = GetSmallIcon(icon);
        }
        private static BitmapSource GetStdIcon(System.Drawing.Icon icon)
        {
            return System.Windows.Interop.Imaging.CreateBitmapSourceFromHIcon(
                icon.Handle,
                Int32Rect.Empty,
                BitmapSizeOptions.FromEmptyOptions());
        }
        private static BitmapSource GetSmallIcon(System.Drawing.Icon icon)
        {
            System.Drawing.Icon smallIcon = new System.Drawing.Icon(icon, new System.Drawing.Size(16, 16));
            return System.Windows.Interop.Imaging.CreateBitmapSourceFromHIcon(
                smallIcon.Handle,
                Int32Rect.Empty,
                BitmapSizeOptions.FromEmptyOptions());
        }
        static String addAssemblyPath = typeof(App).Assembly.Location;
        #endregion
    }
}
