using System;
using Autodesk.AutoCAD.DatabaseServices;
using System.Windows.Forms;

namespace AutoCAD_Plugin_ExportBlockAtrributes
{
    public partial class FormObjectAttributes : Form
    {
        private ObjectId objectId = new ObjectId();
        public FormObjectAttributes()
        {
            InitializeComponent();
        }
        public void SetObjectText(string text)
        {
            textBoxBlockProperties.Text = text;
        }
        public void SetObjectId(ObjectId id)
        {
            objectId = id;
        }
        private void ButtonExportToExcel_Click(object sender, EventArgs e)
        {
            //DocumentCollection dm = Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager;
            Database database = HostApplicationServices.WorkingDatabase;
            //PromptEntityResult per = ed.GetEntity("\nSelect entity: ");

            using (Transaction transaction = database.TransactionManager.StartTransaction())
            {
                Entity entity = transaction.GetObject(objectId, OpenMode.ForRead) as Entity;

                try
                {
                    ExportHelper.ExportToExcel(entity, @"c:\temp\" + entity.ObjectId + "_AcadObjectAttributes.csv");
                    Autodesk.AutoCAD.ApplicationServices.Application.ShowAlertDialog(this.Text + " is exported to C:/temp/" + entity.ObjectId + "_AcadObjectAttributes.csv");
                }
                catch (Autodesk.AutoCAD.Runtime.Exception ex)
                {
                    Autodesk.AutoCAD.ApplicationServices.Application.ShowAlertDialog(ex.Message);
                }

                transaction.Commit();

            }
        } 
        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            this.Close();

        }
    }
}
