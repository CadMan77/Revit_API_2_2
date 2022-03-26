// Создайте приложение, которое подсчитывает количество труб на активном виде.

using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Plumbing;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Revit_API_2_2
{
    [Transaction(TransactionMode.Manual)]

    public class Main : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIApplication uiapp = commandData.Application;
            UIDocument uidoc = uiapp.ActiveUIDocument;
            Document doc = uidoc.Document;
            View actView = doc.ActiveView;

            var pipes = new FilteredElementCollector(doc, actView.Id)
                .OfClass(typeof(Pipe))
                .Cast<Pipe>()
                .ToList();
            
            TaskDialog.Show("Труб на активном виде", pipes.Count.ToString());
            return Result.Succeeded;
        }
    }
}
