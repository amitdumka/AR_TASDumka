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


        public DashBoard()
        {
            InitializeComponent();

        }

        protected override void OnLoad(EventArgs e)
        {
            this.LoadStaffName(false);
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

        private void btnAddEmp_Click(object sender, EventArgs e)
        {
            if (btnAddEmp.Text == "Add")
            {
                btnAddEmp.Text = "Save";
                // Clear All Fields
                this.ClearUIFields(tlpEmp);

            }
            else if (btnAddEmp.Text == "Save")
            {
                using (var ctx = new TASContext())
                {

                    Emp emp = new Emp()
                    {
                        Mobileno = txtEmpMobileno.Text,
                        StaffName = txtEmpStaffName.Text + " " + txtEmpStaffLastName.Text,
                        JoiningDate = dtpDOJ.Value
                    };
                    ctx.Emps.Add(emp);
                    ctx.SaveChanges();
                }
                btnAddEmp.Text = "Add";
                LoadStaffName(true);
                ClearUIFields(tlpAttend);

            }

        }

        private void btnAddSalaryPayment_Click(object sender, EventArgs e)
        {
            if (btnAddSalaryPayment.Text == "Add")
            {
                ClearUIFields(tlpSalaryPayment);
                btnAddSalaryPayment.Text = "Save";

            }
            else if (btnAddSalaryPayment.Text == "Save")
            {
                using (var ctx = new TASContext())
                {
                    SalaryPayment sp = new SalaryPayment()
                    {
                        Amount = Double.Parse(txtSBAmount.Text),
                        Details = txtSBDetails.Text,
                        PaymentDate = DateTime.Now,
                        PayMode = cbSBPayMode.Text,
                        SalaryMonth = txtSBSalaryMonth.Text,

                        StaffName = cbSPStaffName.Text
                    };
                    ctx.SalaryPayments.Add(sp);
                    ctx.SaveChanges();
                }
                ClearUIFields(tlpSalaryPayment);
                btnAddSalaryPayment.Text = "Add";
            }
        }

        private void LoadStaffName(bool isNew)
        {

            using (var ctx = new TASContext())
            {
                if (isNew)
                {
                    cbARStaffName.Items.Clear();//.Add(staff.StaffName);
                    cbAttdStaffName.Items.Clear();//.Add(staff.StaffName);
                    cbSPStaffName.Items.Clear();//.Add(staff.StaffName);
                    cbDSStaffName.Items.Clear();//.Add(staff.StaffName);
                }
                foreach (var staff in ctx.Emps)
                {
                    cbARStaffName.Items.Add(staff.StaffName);
                    cbAttdStaffName.Items.Add(staff.StaffName);
                    cbSPStaffName.Items.Add(staff.StaffName);
                    cbDSStaffName.Items.Add(staff.StaffName);


                }
            }
        }
        /// <summary>
        /// Clear All TextBoxes Mapped to ViewLayout
        /// </summary>
        /// <param name="Con"></param>
        /// <returns></returns>
        private bool ClearUIFields(Control Con)
        {
            var textBoxes = Con.Controls.Cast<Control>()
                                     .OfType<TextBox>()
                                     .OrderBy(control => control.TabIndex);
            var comBoxes = Con.Controls.Cast<Control>()
                                     .OfType<ComboBox>()
                                     .OrderBy(control => control.TabIndex);
            var numFields = Con.Controls.Cast<Control>()
                                    .OfType<NumericUpDown>()
                                    .OrderBy(control => control.TabIndex);

            Console.WriteLine(Con.Text);
            foreach (var textBox in textBoxes)
            {
                textBox.Text = "";
            }
            foreach (var comBox in comBoxes)
            {
                comBox.Text = "";
            }
            foreach (var numf in numFields)
            {
                numf.Value = 0;
            }

            return true;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearUIFields(tlpEmp);
            btnAddEmp.Text = "Add";
        }

        private void btnAddAttnd_Click(object sender, EventArgs e)
        {
            if (btnAddAttnd.Text == "Add")
            {
                ClearUIFields(tlpAttend);
                btnAddAttnd.Text = "Save";

            }
            else if (btnAddAttnd.Text == "Save")
            {
                using (var ctx = new TASContext())
                {
                    Attendences atd = new Attendences()
                    {
                        AttDate = DateTime.Now,
                        AttUnit = Double.Parse(txtAttdAttendence.Text),
                        EntryTime = txtAttdTimeEntry.Text,
                        Remarks = txtAttdRemarks.Text,
                        StaffName = cbAttdStaffName.Text
                    };
                    ctx.Attendences.Add(atd);
                    ctx.SaveChanges();
                }
                ClearUIFields(tlpAttend);
                btnAddAttnd.Text = "Add";
            }
        }

        private void btnAddAdvance_Click(object sender, EventArgs e)
        {
            if (btnAddAdvance.Text == "Add Advance")
            {
                ClearUIFields(tlpAdvRecp);
                btnAddAdvance.Text = "Save";
                cbARSlipMode.SelectedIndex = 0;
            }
            else if (btnAddAdvance.Text == "Save" && cbARSlipMode.Text == "Payments")
            {
                using (var ctx = new TASContext())
                {
                    AdvancePayment sp = new AdvancePayment()
                    {
                        Amount = Double.Parse(txtARAmount.Text),
                        Details = txtARDetails.Text,
                        PaymentDate = DateTime.Now,
                        PayMode = cbARPaymode.Text,
                        StaffName = cbARStaffName.Text
                    };
                    ctx.AdvancePayments.Add(sp);
                    ctx.SaveChanges();
                }
                ClearUIFields(tlpAdvRecp);
                btnAddAdvance.Text = "Add Advance";
            }
        }

        private void btnAddRecipts_Click(object sender, EventArgs e)
        {
            if (btnAddRecipts.Text == "Add Recipets")
            {
                ClearUIFields(tlpAdvRecp);
                btnAddRecipts.Text = "Save";
                cbARSlipMode.SelectedIndex = 1;

            }
            else if (btnAddRecipts.Text == "Save" && cbARSlipMode.Text == "Reciepts")
            {
                using (var ctx = new TASContext())
                {
                    AdvancePayment sp = new AdvancePayment()
                    {
                        Amount = Double.Parse(txtARAmount.Text),
                        Details = txtARDetails.Text,
                        PaymentDate = DateTime.Now,
                        PayMode = cbARPaymode.Text,
                        StaffName = cbARStaffName.Text
                    };
                    ctx.AdvancePayments.Add(sp);
                    ctx.SaveChanges();
                }
                ClearUIFields(tlpAdvRecp);
                btnAddRecipts.Text = "Add Recipets";
            }
        }

        private void btnClearAR_Click(object sender, EventArgs e)
        {
            ClearUIFields(tlpAdvRecp);
            btnAddRecipts.Text = "Add Recipets";
            btnAddAdvance.Text = "Add Advance";

        }

        private void btnClearAttd_Click(object sender, EventArgs e)
        {
            ClearUIFields(tlpAttend);
            btnAddAdvance.Text = "Add";
        }

        private void btnClearSP_Click(object sender, EventArgs e)
        {
            ClearUIFields(tlpSalaryPayment);
            btnAddSalaryPayment.Text = "Add";

        }
    }
}
