﻿using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevitAPITraningSelection
{
    [Transaction(TransactionMode.Manual)]
    public class Main : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIApplication uiapp = commandData.Application;
            UIDocument uidoc = uiapp.ActiveUIDocument;
            Document doc = uidoc.Document;

            List<FamilyInstance> fInstances = new FilteredElementCollector(doc)
                  .OfCategory(BuiltInCategory.OST_DuctCurves)
                  .WhereElementIsNotElementType()
                  .Cast<FamilyInstance>()
                  .ToList();


            TaskDialog.Show("Duct count", fInstances.Count.ToString());
            return Result.Succeeded;
        } 
    }
}
