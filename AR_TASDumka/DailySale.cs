using System;

namespace AR_TASDumka
{
    class DailySale
    {
        public int ID { get; set; }
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
        public int ID { get; set; }
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
        public int ID { get; set; }
        public DateTime DepoDate { get; set; }
        public string BankName { get; set; }
        public string AccountNo { get; set; }
        public double Amount { get; set; }
        public string PayMode { get; set; }
        public string Details { get; set; }
        public string Remarks { get; set; }
    }

    class Talioring
    {
        public class Booking
        {
            public int ID;
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

        public class Delivery
        {
            public int ID { get; set; }
            public DateTime DeliveryDate { get; set; }
            public string InvNo { get; set; }
            public string Remarks { get; set; }
            public double Amount { get; set; }

        }

        public Delivery Deliverys { get; set; }
        public Booking TailoringBooking { get; set; }
    }

}
class Payments { }
class Recipets { }
class Attendences { }

class DailySaleReport {
    public double DSAmount { get; set; }
   
}
class ManaulSaleReport { }
class TailoringReport { }

}
