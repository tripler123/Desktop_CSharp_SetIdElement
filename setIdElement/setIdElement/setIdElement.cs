using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Name Spaces Add
using Autodesk.Revit.DB;
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using Autodesk.Revit.Attributes;
using System.Diagnostics;
using System.Reflection;
using Autodesk.Revit.DB.Structure;

namespace setIdElement
{
    [Transaction(TransactionMode.Manual)]
    public class setIdElement : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, 
                              ref string message, 
                              ElementSet elements)
        {
            TaskDialog.Show("Message Test", "Hello World");

            return Result.Succeeded;
        }
    }
}
