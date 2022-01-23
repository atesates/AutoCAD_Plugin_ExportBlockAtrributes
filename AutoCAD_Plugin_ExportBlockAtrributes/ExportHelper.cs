using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;
using System.IO;

namespace AutoCAD_Plugin_ExportBlockAtrributes
{
    public static class ExportHelper
    {
        /// <summary>
        /// This method takes a DBObject and output path to export 
        /// all properties of this object 
        /// </summary>
        public static void ExportToExcel(DBObject dbObject, string outPutPath)
        {
            using (StreamWriter streamWriter = new StreamWriter(outPutPath))
            {
                streamWriter.Write(ExportHelper.GetBlockAttributes(dbObject));
            }
        }
        /// <summary>
        /// This method takes a DBObject and output path to display 
        /// all attributes of this object in textbox
        /// </summary>
        public static string GetBlockAttributesForText(DBObject dBObject)
        {
            Document document = Application.DocumentManager.MdiActiveDocument;
            Database database = document.Database;

            using (Transaction transaction = database.TransactionManager.StartTransaction())
            {
                string result = "";
                BlockReference blockReference = (BlockReference)transaction.GetObject(dBObject.ObjectId, OpenMode.ForRead);
                BlockTableRecord blockTablerecord = (BlockTableRecord)transaction.GetObject(blockReference.BlockTableRecord, OpenMode.ForRead);

                result += "\nBlock: " + blockTablerecord.Name;
                blockTablerecord.Dispose();
                string headers = "Attribute Tag\t  Attribute String";
                result += System.Environment.NewLine + headers;

                Autodesk.AutoCAD.DatabaseServices.AttributeCollection attributeCollection = blockReference.AttributeCollection;

                foreach (ObjectId objectID in attributeCollection)
                {
                    AttributeReference attributeReference = (AttributeReference)transaction.GetObject(objectID, OpenMode.ForRead);
                    string messageBody = string.Format("{0}: {1}", FixToNumber(attributeReference.Tag, 12), attributeReference.TextString);
                    result += System.Environment.NewLine + messageBody;

                }
                return result;
            }
        }
        /// <summary>
        /// This method takes a DBObject and output path to export 
        /// all attributes of this object 
        /// </summary>
        public static string GetBlockAttributes(DBObject dBObject)
        {
            Document document = Application.DocumentManager.MdiActiveDocument;
            Database database = document.Database;

            using (Transaction transaction = database.TransactionManager.StartTransaction())
            {
                string result = "";
                BlockReference blockReference = (BlockReference)transaction.GetObject(dBObject.ObjectId, OpenMode.ForRead);
                BlockTableRecord blockTableRecord = (BlockTableRecord)transaction.GetObject(blockReference.BlockTableRecord, OpenMode.ForRead);

                result += "\nBlock: " + blockTableRecord.Name;
                blockTableRecord.Dispose();
                string headers = "Attribute Tag, Attribute String";
                result += System.Environment.NewLine + headers;

                Autodesk.AutoCAD.DatabaseServices.AttributeCollection attributeCollection = blockReference.AttributeCollection;

                foreach (ObjectId objectId in attributeCollection)
                {
                    AttributeReference attributereference = (AttributeReference)transaction.GetObject(objectId, OpenMode.ForRead);
                    string messageBody = string.Format("{0} , {1}", attributereference.Tag, attributereference.TextString);
                    result += System.Environment.NewLine + messageBody;

                }
                return result;
            }
        }
        /// <summary>
        /// This method takes two parameter to fix a string in a specific 
        /// number to display a column thst has width equal,
        /// returns same string i a rearrenged width
        /// </summary>
        private static string FixToNumber(string input, int number)
        {
            if (input.Length < number)
            {
                if (input.Length < 4)
                    input += input + "\t";
                int numberOfChar = input.Length;
                int numberOfSub = number - numberOfChar;
                for (int i = 0; i <= numberOfSub; i++)
                {
                    input += " ";
                }
            }
            else if (input.Length > number)
            {
                input = input.Substring(0, number);
            }
            return input + "\t";

        }


    }
}
