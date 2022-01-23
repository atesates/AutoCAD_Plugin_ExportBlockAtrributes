using Autodesk.AutoCAD.Runtime;
using Autodesk.AutoCAD.EditorInput;
using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;

namespace AutoCAD_Plugin_ExportBlockAtrributes
{
    public class MainMethods
    {
        [CommandMethod("GETBLOCKATTRIBUTES")]
        public static void GetBlockAttributes()
        {
            Document document = Application.DocumentManager.MdiActiveDocument;
            Database database = document.Database;
            Editor editor = document.Editor;

            using (Transaction transaction = database.TransactionManager.StartTransaction())
            {
                // Select a block reference
                PromptEntityOptions promptEntityOptions = new PromptEntityOptions("\nSelect block reference: ");
                promptEntityOptions.SetRejectMessage("\nEntity is not a block.");
                promptEntityOptions.AddAllowedClass(typeof(BlockReference), false);
                // 
                PromptEntityResult promptEntityResult = editor.GetEntity(promptEntityOptions);
                if (promptEntityResult.Status != PromptStatus.OK)
                    return;

                // Access the selected block reference
                BlockReference blockReference = transaction.GetObject(promptEntityResult.ObjectId, OpenMode.ForRead) as BlockReference;
                Entity entity = transaction.GetObject(blockReference.ObjectId, OpenMode.ForRead) as Entity;

                // Call our from and function to display the block properties
                FormObjectAttributes formBlockProperties = new FormObjectAttributes();

                //Display on Form TextBox
                formBlockProperties.SetObjectText(ExportHelper.GetBlockAttributesForText(entity));
                // Send object to from with id to export
                formBlockProperties.SetObjectId(blockReference.ObjectId);
                Application.ShowModalDialog(null, formBlockProperties, false);
                // Committing is cheaper than aborting
                transaction.Commit();
            }
        }
    }
}
