using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CyberN;
using Excel = Microsoft.Office.Interop.Excel;

namespace AR_TASDumka
{
    public partial class DashBoard : Form
    {
        Workbook workbook;
        worksheet worksheet;

        private void LoadWorkBooks()
        {
            
            // Can be used for reading. 
            foreach(var workst in Workbook.Worksheets("test.xls"))
            {
                worksheet = workst;
                foreach (var row in worksheet.Rows)
                {
                    foreach (var cell in row.Cells)
                    {
                        cell.Value = "Amit Kumar";

                    }
                }
            }
            
        }

        public DashBoard()
        {
            InitializeComponent();
            workbook = new Workbook();
            worksheet = new worksheet();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
        }

        private void groupBox8_Enter(object sender, EventArgs e)
        {

        }
    }
}
