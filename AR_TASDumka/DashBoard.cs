using CyberN;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Core.Metadata.Edm;
using System.Data.Entity.Design.PluralizationServices;
using System.Data.Entity.Infrastructure;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace AR_TASDumka
{
    public partial class DashBoard : Form
    {


        public DashBoard()
        {
            InitializeComponent ();

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close ();
            Application.Exit ();
        }

        private void groupBox8_Enter(object sender, EventArgs e)
        {

        }

        private void btnAddEmp_Click(object sender, EventArgs e)
        {
            if ( btnAddEmp.Text == "Add" )
            {
                btnAddEmp.Text = "Save";
                // Clear All Fields
                this.ClearUIFields (tlpEmp);

            }
            else if ( btnAddEmp.Text == "Save" )
            {
                using ( var ctx = new TASContext () )
                {

                    Emp emp = new Emp ()
                    {
                        Mobileno = txtEmpMobileno.Text,
                        StaffName = txtEmpStaffName.Text + " " + txtEmpStaffLastName.Text,
                        JoiningDate = dtpDOJ.Value
                    };
                    ctx.Emps.Add (emp);
                    ctx.SaveChanges ();
                }
                btnAddEmp.Text = "Add";
                LoadStaffName (true);
                ClearUIFields (tlpAttend);

            }

        }

        private void btnAddSalaryPayment_Click(object sender, EventArgs e)
        {
            if ( btnAddSalaryPayment.Text == "Add" )
            {
                ClearUIFields (tlpSalaryPayment);
                btnAddSalaryPayment.Text = "Save";

            }
            else if ( btnAddSalaryPayment.Text == "Save" )
            {
                using ( var ctx = new TASContext () )
                {
                    SalaryPayment sp = new SalaryPayment ()
                    {
                        Amount = Double.Parse (txtSBAmount.Text),
                        Details = txtSBDetails.Text,
                        PaymentDate = DateTime.Now,
                        PayMode = cbSBPayMode.Text,
                        SalaryMonth = txtSBSalaryMonth.Text,

                        StaffName = cbSPStaffName.Text
                    };
                    ctx.SalaryPayments.Add (sp);
                    ctx.SaveChanges ();
                }
                ClearUIFields (tlpSalaryPayment);
                btnAddSalaryPayment.Text = "Add";
            }
        }

        private void LoadStaffName(bool isNew)
        {

            using ( var ctx = new TASContext () )
            {
                if ( isNew )
                {
                    cbARStaffName.Items.Clear ();//.Add(staff.StaffName);
                    cbAttdStaffName.Items.Clear ();//.Add(staff.StaffName);
                    cbSPStaffName.Items.Clear ();//.Add(staff.StaffName);
                    cbDSStaffName.Items.Clear ();//.Add(staff.StaffName);
                }
                foreach ( var staff in ctx.Emps )
                {
                    cbARStaffName.Items.Add (staff.StaffName);
                    cbAttdStaffName.Items.Add (staff.StaffName);
                    cbSPStaffName.Items.Add (staff.StaffName);
                    cbDSStaffName.Items.Add (staff.StaffName);


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
            var textBoxes = Con.Controls.Cast<Control> ()
                                     .OfType<TextBox> ()
                                     .OrderBy (control => control.TabIndex);
            var comBoxes = Con.Controls.Cast<Control> ()
                                     .OfType<ComboBox> ()
                                     .OrderBy (control => control.TabIndex);
            var numFields = Con.Controls.Cast<Control> ()
                                    .OfType<NumericUpDown> ()
                                    .OrderBy (control => control.TabIndex);

            Console.WriteLine (Con.Text);
            foreach ( var textBox in textBoxes )
            {
                textBox.Text = "";
            }
            foreach ( var comBox in comBoxes )
            {
                comBox.Text = "";
            }
            foreach ( var numf in numFields )
            {
                numf.Value = 0;
            }

            return true;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearUIFields (tlpEmp);
            btnAddEmp.Text = "Add";
        }

        private void btnAddAttnd_Click(object sender, EventArgs e)
        {
            if ( btnAddAttnd.Text == "Add" )
            {
                ClearUIFields (tlpAttend);
                btnAddAttnd.Text = "Save";

            }
            else if ( btnAddAttnd.Text == "Save" )
            {
                using ( var ctx = new TASContext () )
                {
                    Attendences atd = new Attendences ()
                    {
                        AttDate = DateTime.Now,
                        AttUnit = Double.Parse (txtAttdAttendence.Text),
                        EntryTime = txtAttdTimeEntry.Text,
                        Remarks = txtAttdRemarks.Text,
                        StaffName = cbAttdStaffName.Text
                    };
                    ctx.Attendences.Add (atd);
                    ctx.SaveChanges ();
                }
                ClearUIFields (tlpAttend);
                btnAddAttnd.Text = "Add";
            }
        }

        private void btnAddAdvance_Click(object sender, EventArgs e)
        {
            if ( btnAddAdvance.Text == "Add Advance" )
            {
                ClearUIFields (tlpAdvRecp);
                btnAddAdvance.Text = "Save";
                cbARSlipMode.SelectedIndex = 0;
            }
            else if ( btnAddAdvance.Text == "Save" && cbARSlipMode.Text == "Payments" )
            {
                using ( var ctx = new TASContext () )
                {
                    AdvancePayment sp = new AdvancePayment ()
                    {
                        Amount = Double.Parse (txtARAmount.Text),
                        Details = txtARDetails.Text,
                        PaymentDate = DateTime.Now,
                        PayMode = cbARPaymode.Text,
                        StaffName = cbARStaffName.Text
                    };
                    ctx.AdvancePayments.Add (sp);
                    ctx.SaveChanges ();
                }
                ClearUIFields (tlpAdvRecp);
                btnAddAdvance.Text = "Add Advance";
            }
        }

        private void btnAddRecipts_Click(object sender, EventArgs e)
        {
            if ( btnAddRecipts.Text == "Add Recipets" )
            {
                ClearUIFields (tlpAdvRecp);
                btnAddRecipts.Text = "Save";
                cbARSlipMode.SelectedIndex = 1;

            }
            else if ( btnAddRecipts.Text == "Save" && cbARSlipMode.Text == "Reciepts" )
            {
                using ( var ctx = new TASContext () )
                {
                    AdvancePayment sp = new AdvancePayment ()
                    {
                        Amount = Double.Parse (txtARAmount.Text),
                        Details = txtARDetails.Text,
                        PaymentDate = DateTime.Now,
                        PayMode = cbARPaymode.Text,
                        StaffName = cbARStaffName.Text
                    };
                    ctx.AdvancePayments.Add (sp);
                    ctx.SaveChanges ();
                }
                ClearUIFields (tlpAdvRecp);
                btnAddRecipts.Text = "Add Recipets";
            }
        }

        private void btnClearAR_Click(object sender, EventArgs e)
        {
            ClearUIFields (tlpAdvRecp);
            btnAddRecipts.Text = "Add Recipets";
            btnAddAdvance.Text = "Add Advance";

        }

        private void btnClearAttd_Click(object sender, EventArgs e)
        {
            ClearUIFields (tlpAttend);
            btnAddAdvance.Text = "Add";
        }

        private void btnClearSP_Click(object sender, EventArgs e)
        {
            ClearUIFields (tlpSalaryPayment);
            btnAddSalaryPayment.Text = "Add";

        }

        private void btnClearReciept_Click(object sender, EventArgs e)
        {
            ClearUIFields (tlpReciept);
        }

        private void btnClearDailySale_Click(object sender, EventArgs e)
        {
            ClearUIFields (tplDailySale);

        }

        private void btnClearEOD_Click(object sender, EventArgs e)
        {
            ClearUIFields (tlpEOD);
        }

        private void btnClearTailoring_Click(object sender, EventArgs e)
        {
            ClearUIFields (tlpBooking);
        }

        private void btnClearDelivery_Click(object sender, EventArgs e)
        {
            ClearUIFields (flpDelivery);
        }

        private void btnClearExp_Click(object sender, EventArgs e)
        {
            ClearUIFields (tlpExp);
        }

        private void btnClearBank_Click(object sender, EventArgs e)
        {
            ClearUIFields (tlpBank);
        }

        private void btnClearrPayments_Click(object sender, EventArgs e)
        {
            ClearUIFields (tlpPay);
        }

        private void btnHEClear_Click(object sender, EventArgs e)
        {
            ClearUIFields (gbHomeExp);
        }

        private void btnClearCashInWard_Click(object sender, EventArgs e)
        {
            ClearUIFields (gbCashInWard);
        }

        private void btnClearAmit_Click(object sender, EventArgs e)
        {
            ClearUIFields (gbAmitkumar);

        }

        private void btnClearOtherHE_Click(object sender, EventArgs e)
        {
            ClearUIFields (gbOtherHomeExp);
        }

        private void btnHEAdd_Click(object sender, EventArgs e)
        {
            if ( btnHEAdd.Text == "Add" )
            {
                btnHEAdd.Text = "Save";
                ClearUIFields (gbHomeExp);
            }
            else if ( btnHEAdd.Text == "Save" )
            {
                using ( var db = new TASContext () )
                {
                    HomeExpense he = new HomeExpense ()
                    {
                        Amount = Double.Parse (txtHEAmount.Text.Trim ()),
                        dateTime = dtpHEDate.Value,
                        PaidTo = txtHEPaidTo.Text,
                        SlipNo = txtHESlipNo.Text
                    };
                    db.HomeExpenses.Add (he);
                    db.SaveChanges ();
                    btnHEAdd.Text = "Add";
                    ClearUIFields (gbHomeExp);
                }

            }
        }

        private void btnAddCashInward_Click(object sender, EventArgs e)
        {
            if ( btnAddCashInward.Text == "Add" )
            {
                btnAddCashInward.Text = "Save";
                ClearUIFields (gbCashInWard);
            }
            else if ( btnAddCashInward.Text == "Save" )
            {
                using ( var db = new TASContext () )
                {
                    CashInward he = new CashInward ()
                    {
                        Amount = Double.Parse (txtCIHAmount.Text.Trim ()),
                        dateTime = dtpCIHDate.Value,
                        RecieptFrom = txtCIHFrom.Text,
                        SlipNo = txtCIHSlipNo.Text
                    };
                    db.CashInwards.Add (he);
                    db.SaveChanges ();
                    btnAddCashInward.Text = "Add";
                    ClearUIFields (gbCashInWard);
                }
            }
        }

        private void btnAddOtherHE_Click(object sender, EventArgs e)
        {
            if ( btnAddOtherHE.Text == "Add" )
            {
                btnAddOtherHE.Text = "Save";
                ClearUIFields (gbOtherHomeExp);
            }
            else if ( btnAddOtherHE.Text == "Save" )
            {
                using ( var db = new TASContext () )
                {
                    OtherHomeExpense he = new OtherHomeExpense ()
                    {
                        Amount = Double.Parse (txtOHEAmount.Text.Trim ()),
                        dateTime = dtpOHEDate.Value,
                        PaidTo = txtOHEPaidTo.Text,
                        SlipNo = txtOHESlipNo.Text,
                        Remarks = txtOHERemarks.Text
                    };
                    db.OtherHomeExpenses.Add (he);
                    db.SaveChanges ();
                    btnAddOtherHE.Text = "Add";
                    ClearUIFields (gbOtherHomeExp);
                }
            }
        }

        private void btnAddAmit_Click(object sender, EventArgs e)
        {
            if ( btnAddAmit.Text == "Add" )
            {
                btnAddAmit.Text = "Save";
                ClearUIFields (gbAmitkumar);
            }
            else if ( btnAddAmit.Text == "Save" )
            {
                using ( var db = new TASContext () )
                {
                    AmitKumarExpense he = new AmitKumarExpense ()
                    {
                        Amount = Double.Parse (txtAKAmount.Text.Trim ()),
                        dateTime = dtpAKDate.Value,
                        PaidTo = txtAKPaidTo.Text,
                        SlipNo = txtAKSlipNo.Text
                    };
                    db.AmitKumarExpenses.Add (he);
                    db.SaveChanges ();
                    btnAddAmit.Text = "Add";
                    ClearUIFields (gbAmitkumar);
                }
            }
        }

        private void DashBoard_Load(object sender, EventArgs e)
        {
            this.LoadStaffName (false);
            LoadTableNameList ();
        }
        private string GetPluralized(string input)
        {
            string ret;//= string.Empty;

            PluralizationService ps = PluralizationService.CreateService (System.Globalization.CultureInfo.GetCultureInfo ("en-us"));
            ret = ps.Pluralize (input);
            Console.WriteLine ("Pul: " + ret);
            return ret;
        }
        private void btnTableUpdate_Click(object sender, EventArgs e)
        {
            using ( var db = new TASContext () )
            {
                try
                {
                    DbSet dS = db.Set (db.GetType ().GetProperty (GetPluralized (cbTableList.Text)).GetValue (db).GetType ());

                    // DbSet dS = ((DbSet)db.GetType().GetProperty(GetPluralized(cbTableList.Text)).GetValue(db, null));
                    dS.Load ();

                    dgvData.DataSource = dS.Local;
                }
                catch ( Exception ex )
                {
                    MessageBox.Show ("Cannnot edit table: " + cbTableList.Text + Environment.NewLine + Environment.NewLine + ex.Message, "Error");
                }
            }

        }

        private void LoadTableNameList()
        {
            using ( var dbContext = new TASContext () )
            {
                var metadata = ( (IObjectContextAdapter) dbContext ).ObjectContext.MetadataWorkspace;

                var tables = metadata.GetItemCollection (DataSpace.SSpace)
                    .GetItems<EntityContainer> ()
                    .Single ()
                    .BaseEntitySets
                    .OfType<EntitySet> ()
                    .Where (s => !s.MetadataProperties.Contains ("Type")
                     || s.MetadataProperties ["Type"].ToString () == "Tables");

                foreach ( var table in tables )
                {
                    var tableName = table.MetadataProperties.Contains ("Table")
                        && table.MetadataProperties ["Table"].Value != null
                        ? table.MetadataProperties ["Table"].Value.ToString ()
                        : table.Name;

                    //var tableSchema = table.MetadataProperties["Schema"].Value.ToString();
                    cbTableList.Items.Add (tableName);
                    //Console.WriteLine(tableSchema + "." + tableName);
                }
            }
        }

        private void btnAddDelivery_Click(object sender, EventArgs e)
        {
            if ( btnAddDelivery.Text == "Add" )
            {
                btnAddDelivery.Text = "Save";
                ClearUIFields (flpDelivery);
            }
            else if ( btnAddDelivery.Text == "Save" )
            {
                using ( var db = new TASContext () )
                {

                    TalioringDelivery td = new TalioringDelivery ()
                    {
                        Amount = Double.Parse (txtTDAmount.Text.Trim ()),
                        DeliveryDate = dtpTDDate.Value,
                        InvNo = txtTDInvNo.Text,
                        Remarks = txtTDRemarks.Text
                    };
                    db.TalioringDeliveries.Add (td);
                    db.SaveChanges ();
                    btnAddDelivery.Text = "Add";
                    ClearUIFields (flpDelivery);
                }

            }
        }

        private void btnAddTailoring_Click(object sender, EventArgs e)
        {
            if ( btnAddTailoring.Text == "Add" )
            {
                btnAddTailoring.Text = "Save";
                ClearUIFields (tlpBooking);
            }
            else if ( btnAddTailoring.Text == "Save" )
            {
                using ( var db = new TASContext () )
                {

                    TalioringBooking td = new TalioringBooking ()
                    {
                        TotalAmount = Double.Parse (txtTBTotalAmount.Text.Trim ()),
                        DeliveryDate = dtpTBDeliveryDate.Value,
                        BookingDate = dtpTBDate.Value,
                        BookingSlipNo = txtTBSlipNo.Text,
                        BundiPrice = Double.Parse (txtBundiAmount.Text.Trim ()),
                        BundiQty = Int16.Parse (txtBundiQty.Text.Trim ()),
                        CoatPrice = Double.Parse (txtCoatAmount.Text),
                        CoatQty = Int16.Parse (txtCoatQty.Text),
                        CustName = txtTBCustName.Text,
                        KurtaPrice = Double.Parse (txtKurtaAmount.Text),
                        KurtaQty = Int16.Parse (txtKurtaQty.Text),
                        OthersPrice = Double.Parse (txtOthersAmount.Text),
                        PantPrice = Double.Parse (txtPantAmount.Text),
                        ShirtPrice = Double.Parse (txtShirtAmount.Text),
                        OthersQty = Int16.Parse (txtOthersQty.Text),
                        PantQty = Int16.Parse (txtPantQty.Text),
                        ShirtQty = Int16.Parse (txtShirtQty.Text),
                        TotalQty = Int16.Parse (txtTBTotalQty.Text)

                    };
                    db.TalioringBookings.Add (td);
                    db.SaveChanges ();
                    btnAddTailoring.Text = "Add";
                    ClearUIFields (tlpBooking);
                }

            }
        }

        private void btnAddPayments_Click(object sender, EventArgs e)
        {
            if ( btnAddPayments.Text == "Add" )
            {
                ClearUIFields (tlpPay);
                btnAddPayments.Text = "Save";

            }
            else if ( btnAddPayments.Text == "Save" )
            {
                using ( var db = new TASContext () )
                {

                    Payments pay = new Payments ()
                    {
                        Amount = Double.Parse (txtPayAmount.Text),
                        PayDate = dtpPayDate.Value,
                        PayMode = cbPaymentPayMode.Text,
                        PaymentDetails = txtPayDetails.Text,
                        PaymentSlipNo = txtPaymentSlipNo.Text,
                        Remarks = txtPayRemarks.Text,
                        PaymentParties = txtPaymentTo.Text

                    };
                    db.Payments.Add (pay);
                    db.SaveChanges ();
                }
                btnAddPayments.Text = "Add";
                ClearUIFields (tlpPay);
            }

        }

        private void btnAddReceipt_Click(object sender, EventArgs e)
        {
            if ( btnAddReceipt.Text == "Add" )
            {
                ClearUIFields (tlpReciept);
                btnAddReceipt.Text = "Save";

            }
            else if ( btnAddReceipt.Text == "Save" )
            {
                using ( var db = new TASContext () )
                {
                    Recipets recp = new Recipets ()
                    {
                        Amount = Double.Parse (txtReceiptAmount.Text),
                        RecieptDate = dtpReceiptDate.Value,
                        PayMode = cbReceiptPayMode.Text,
                        RecieptDetails = txtReceiptDetails.Text,
                        RecieptSlipNo = txtReceiptNo.Text,
                        Remarks = txtPayRemarks.Text,
                        RecieptFrom = txtReceiptFrom.Text

                    };
                    db.Recipets.Add (recp);
                    db.SaveChanges ();

                }
                btnAddReceipt.Text = "Add";
                ClearUIFields (tlpReciept);
            }
        }

        private void btnAddBank_Click(object sender, EventArgs e)
        {
            if ( btnAddBank.Text == "Add" )
            {
                ClearUIFields (tlpBank);
                btnAddBank.Text = "Save";
            }
            else if ( btnAddBank.Text == "Save" )
            {
                using ( var db = new TASContext () )
                {
                    BankDeposit bd = new BankDeposit ()
                    {
                        Amount = Double.Parse (txtBankAmount.Text),
                        DepoDate = dtpPayDate.Value,
                        PayMode = cbPaymentPayMode.Text,
                        Details = txtPayDetails.Text,
                        Remarks = txtPayRemarks.Text,
                        AccountNo = txtBankAccountNo.Text,
                        BankName = txtBankName.Text
                    };
                    db.BankDeposits.Add (bd);
                    db.SaveChanges ();
                }
                btnAddBank.Text = "Add";
                ClearUIFields (tlpBank);
            }
        }

        private void btnAddExp_Click(object sender, EventArgs e)
        {
            if ( btnAddExp.Text == "Add" )
            {
                ClearUIFields (tlpExp);
                btnAddExp.Text = "Save";

            }
            else if ( btnAddExp.Text == "Save" )
            {
                using ( var db = new TASContext () )
                {

                    Expenses exp = new Expenses ()
                    {
                        Amount = Double.Parse (txtExpAmount.Text),
                        ExpDate = dtpExpDate.Value,
                        PayMode = cbExpPayMode.Text,
                        PaymentDetails = txtExpPaymentDetails.Text,
                        Remarks = txtExpRemarks.Text,
                        PaidBy = cbExpPaidBy.Text,
                        PaidTo = txtExpPaidTo.Text,
                        Particulars = txtExpParticulars.Text
                    };
                    db.Expenses.Add (exp);
                    db.SaveChanges ();
                }
                btnAddExp.Text = "Add";
                ClearUIFields (tlpExp);
            }
        }

        private void btnAddDailySale_Click(object sender, EventArgs e)
        {
            if ( btnAddDailySale.Text == "Add" )
            {
                btnAddDailySale.Text = "Save";
                ClearUIFields (tplDailySale);
            }
            else if ( btnAddDailySale.Text == "Save" )
            {
                using ( var db = new TASContext () )
                {


                }

                btnAddDailySale.Text = "Save";
                ClearUIFields (tplDailySale);
            }
        }

        private void btnAddEOD_Click(object sender, EventArgs e)
        {
            if ( btnAddEOD.Text == "Add" )
            {
                btnAddEOD.Text = "Save";
                ClearUIFields (tlpEOD);
            }
            else if ( btnAddEOD.Text == "Save" )
            {
                using ( var db = new TASContext() )
                {

                    EndOfDay eod = new EndOfDay () { };
                    db.SaveChanges ();
                }

                btnAddEOD.Text = "Save";
                ClearUIFields (tlpEOD);
            }

        }
    }
}
