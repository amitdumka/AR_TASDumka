using System;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;

namespace AR_TASDumka
{
    class CashInHand
    {
        public int CashInHandId { get; set; }
        public DateTime CIHDate { get; set; }
        public double OpenningBalance { get; set; }
        public double ClosingBalance { get; set; }
        public double CashInHandAmount { get; set; }
    }
    class CashInBank
    {
        public int CashInBankId { get; set; }
        public DateTime CIBDate { get; set; }
        public double OpenningBalance { get; set; }
        public double ClosingBalance { get; set; }
        public double CashInBankAmount { get; set; }
    }
    class CashInward
    {
        public int CashInwardId { get; set; }
        public DateTime dateTime { get; set; }
        public string RecieptFrom { get; set; }
        public double Amount { get; set; }
        public string SlipNo { get; set; }
    }
    class HomeExpense
    {
        public int HomeExpenseId { get; set; }
        public DateTime dateTime { get; set; }
        public string PaidTo { get; set; }
        public double Amount { get; set; }
        public string SlipNo { get; set; }
    }
    class OtherHomeExpense
    {
        public int OtherHomeExpenseId { get; set; }
        public DateTime dateTime { get; set; }
        public string PaidTo { get; set; }
        public double Amount { get; set; }
        public string SlipNo { get; set; }
        public string Remarks { get; set; }
    }
    class AmitKumarExpense
    {
        public int AmitKumarExpenseId { get; set; }
        public DateTime dateTime { get; set; }
        public string PaidTo { get; set; }
        public double Amount { get; set; }
        public string SlipNo { get; set; }
    }
    class DailySale
    {
        public int DailySaleId { get; set; }
        public DateTime SaleDate { get; set; }
        public string InvNo { get; set; }
        public double Amount { get; set; }
        public string PayMode { get; set; }
        public double CashAmount { get; set; }
        public string Salesman { get; set; }
        public bool IsDues { get; set; }
        public bool IsManualBill { get; set; }
        public bool IsTailingBill { get; set; }
        public string Remarks { get; set; }
    }
    class Expenses
    {
        public int ExpensesId { get; set; }
        public DateTime ExpDate { get; set; }
        public string Particulars { get; set; }
        public double Amount { get; set; }
        public string PayMode { get; set; }
        public string PaymentDetails { get; set; }
        public string PaidBy { get; set; }
        public string PaidTo { get; set; }
        public string Remarks { get; set; }

    }
    class BankDeposit
    {
        public int BankDepositId { get; set; }
        public DateTime DepoDate { get; set; }
        public string BankName { get; set; }
        public string AccountNo { get; set; }
        public double Amount { get; set; }
        public string PayMode { get; set; }
        public string Details { get; set; }
        public string Remarks { get; set; }
    }


    public class TalioringBooking
    {
        public int TalioringBookingId { get; set; }
        public DateTime BookingDate { get; set; }
        public string CustName { get; set; }
        public DateTime DeliveryDate { get; set; }
        public string BookingSlipNo { get; set; }
        public double TotalAmount { get; set; }
        public int TotalQty { get; set; }
        public int ShirtQty { get; set; }
        public double ShirtPrice { get; set; }
        public int PantQty { get; set; }
        public double PantPrice { get; set; }
        public int CoatQty { get; set; }
        public int KurtaQty { get; set; }
        public int BundiQty { get; set; }
        public int OthersQty { get; set; }
        public double CoatPrice { get; set; }
        public double BundiPrice { get; set; }
        public double OthersPrice { get; set; }
        public double KurtaPrice { get; set; }

    }

    public class TalioringDelivery
    {
        public int TalioringDeliveryId { get; set; }
        public DateTime DeliveryDate { get; set; }
        public string InvNo { get; set; }
        public string Remarks { get; set; }
        public double Amount { get; set; }

    }


    class Payments
    {
        public int PaymentsId { get; set; }
        public DateTime PayDate { get; set; }
        public string PaymentParties { get; set; }
        public string PaymentDetails { get; set; }
        public string Remarks { get; set; }
        public double Amount { get; set; }
        public string PaymentSlipNo { get; set; }
        public string PayMode { get; set; }

    }
    class Recipets
    {
        public int RecipetsId { get; set; }
        public DateTime RecieptDate { get; set; }
        public string RecieptFrom { get; set; }
        public string RecieptDetails { get; set; }
        public string Remarks { get; set; }
        public double Amount { get; set; }
        public string RecieptSlipNo { get; set; }
        public string PayMode { get; set; }
    }
    class Attendences
    {
        public int AttendencesId { get; set; }
        public string StaffName { get; set; }
        public string Remarks { get; set; }
        public DateTime AttDate { get; set; }
        public string EntryTime { get; set; }
        public double AttUnit { get; set; }

    }
    class DailySaleReport
    {
        public double DailySale { get; set; }
        public double MonthlySale { get; set; }
        public double YearlySale { get; set; }
        public double WeeklySale { get; set; }
        public double QuaterlySale { get; set; }

    }
    class ManaulSaleReport
    {
        public double DailySale { get; set; }
        public double MonthlySale { get; set; }
        public double YearlySale { get; set; }
        public double PendingSale { get; set; }
        public double SaleAdjustest { get; set; }
        public double TotalFixedSale { get; set; }
    }

    class Emp
    {
        public int EmpId { get; set; }
        public string StaffName { get; set; }
        public string Mobileno { get; set; }
        public DateTime JoiningDate { get; set; }

    }

    class SalaryPayment
    {
        public int SalaryPaymentId { get; set; }
        public string StaffName { get; set; }
        public string SalaryMonth { get; set; }
        public DateTime PaymentDate { get; set; }
        public double Amount { get; set; }
        public string PayMode { get; set; }
        public string Details { get; set; }


    }
    class AdvancePayment
    {
        public int AdvancePaymentId { get; set; }
        public string StaffName { get; set; }
        public DateTime PaymentDate { get; set; }
        public double Amount { get; set; }
        public string PayMode { get; set; }
        public string Details { get; set; }
    }
    class AdvanceReceipt
    {
        public int AdvanceReceiptId { get; set; }
        public string StaffName { get; set; }
        public DateTime PaymentDate { get; set; }
        public double Amount { get; set; }
        public string PayMode { get; set; }
        public string Details { get; set; }
    }

    class TailoringReport
    {
        public double TodaySale { get; set; }
        public double MonthlySale { get; set; }
        public double YearlySale { get; set; }
        public double QuaterlySale { get; set; }
        public double TodayBooking { get; set; }
        public double TodayUnit { get; set; }
        public double MonthlyBooking { get; set; }
        public double MonthlyUnit { get; set; }
        public double YearlyBooking { get; set; }
        public double YearlyUnit { get; set; }
    }


    class TASContext : DbContext
    {
        public TASContext() : base("DB_TAS_Dumka")
        {
            Database.SetInitializer<TASContext>(new CreateDatabaseIfNotExists<TASContext>());
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<TASContext, AR_TASDumka.Migrations.Configuration>());
        }
       
        public DbSet<DailySale> DailySales { get; set; }
        public DbSet<Expenses> Expenses { get; set; }
        public DbSet<BankDeposit> BankDeposits { get; set; }
        public DbSet<Payments> Payments { get; set; }
        public DbSet<Recipets> Recipets { get; set; }
        public DbSet<TalioringBooking> TalioringBookings { get; set; }
        public DbSet<TalioringDelivery> TalioringDeliveries { get; set; }
        public DbSet<Attendences> Attendences { get; set; }
        public DbSet<Emp> Emps { get; set; }
        public DbSet<AdvancePayment> AdvancePayments { get; set; }
        public DbSet<AdvanceReceipt> AdvanceReceipts { get; set; }
        public DbSet<SalaryPayment> SalaryPayments { get; set; }
        public DbSet<HomeExpense> HomeExpenses { get; set; }
        public DbSet<OtherHomeExpense> OtherHomeExpenses { get; set; }
        public DbSet<AmitKumarExpense> AmitKumarExpenses { get; set; }
        public DbSet<CashInward> CashInwards { get; set; }
    }
}

