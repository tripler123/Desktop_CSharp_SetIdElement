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
        public static bool next { get; set; }
        public static string paramName { get; set; }
        public Result Execute(ExternalCommandData commandData,
                              ref string message,
                              ElementSet elements)

        {
            //DECLARACION DE VARIABLES PARA ACCEDER AL DOCUMENTO
            UIApplication uiApp = commandData.Application;
            UIDocument uiDoc = uiApp.ActiveUIDocument;
            Document doc = uiDoc.Document;
            next = false; //Iniciar el parametro como falso

            using (frmParameterName frm = new frmParameterName())
            {
                frm.ShowDialog();
            }
            if (next)
            {
                //Todos los elementos fisicos del proyecto
                List<Element> allElements = Util.AllElement(doc);
                var list = allElements.Select(item => item.Id).ToList();

                int eModificados = 0;

                foreach (Element e in allElements)
                {
                    if (e.LookupParameter(paramName) != null)
                    {
                        if (e.LookupParameter(paramName).StorageType == StorageType.String)
                        {
                            try
                            {
                                using (Transaction t = new Transaction(doc, "param"))
                                {
                                    t.Start();
                                    e.LookupParameter(paramName).Set(e.Id.ToString());
                                    ++eModificados;
                                    t.Commit();
                                }
                            }
                            catch (Exception err)
                            {
                                TaskDialog.Show("Mensaje de Error", err.ToString());
                            }
                        }
                        else
                        {
                            TaskDialog.Show("Mensaje de Error", "El parametro no es de tipo String, " +
                                                            "para poder ejecutar este addin el parametro debe ser de tipo String");
                            return Result.Cancelled;
                        }
                        
                    }
                    else
                    {

                        TaskDialog.Show("Mensaje de Error", "El parametro no existe, " +
                                                            "verificar si la categoria del elemento" +
                                                            " cuenta con el parameto - " + e.Id.ToString());
                        return Result.Cancelled;
                    }
                }
                TaskDialog.Show("Mensaje de Finalización", eModificados.ToString() + " Fueron modificados de un total de " + allElements.Count.ToString());
            }
            else
            {
                TaskDialog.Show("Mensaje de Finalización", "No se Ejecuto el addin.");
            }     
            return Result.Succeeded;
        }
    }
}

