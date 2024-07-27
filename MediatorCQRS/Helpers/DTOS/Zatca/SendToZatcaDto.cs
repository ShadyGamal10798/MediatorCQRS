using MediatorCQRS.Helpers.Entities;
using MediatorCQRS.Helpers.Entities.InvoiceAggregateRoot;
using MediatorCQRS.Helpers.Enums;

namespace MediatorCQRS.Helpers.DTOS.Zatca
{
    public class SendToZatcaDto
    {
        public Order? Order { get; set; }
        public PostpaidClientInvoice? PostpaidClientInvoice { get; set; }
        public ShopRentalInvoice? ShopRentalInvoice { get; set; }

        public string InvoiceType { get; set; }


        private int? _orderTypeId;
        public int? OrderTypeId
        {
            get { return _orderTypeId; }
            set
            {
                // Set the OrderTypeId
                _orderTypeId = value;

                // Update PaymentType based on OrderTypeId
                switch (value)
                {
                    //to do : handle client escape 
                    case (int)OrderType.Cash:
                        _paymentType = "Cache";
                        break;
                    case (int)OrderType.CustomerAccount:
                    case (int)OrderType.MadaOrVisa:
                        _paymentType = "Bank card";
                        break;
                    default:
                        _paymentType = "Cache";
                        break;
                }
            }
        }
        private int? _paymentTypeId;
        public int? PaymentTypeId
        {
            get { return _paymentTypeId; }
            set
            {
                // Set the OrderTypeId
                _paymentTypeId = value;

                // Update PaymentType based on OrderTypeId
                switch (value)
                {

                    case (int)PaymentMethod.Cash:
                        _paymentType = "Cache";
                        break;
                    case (int)PaymentMethod.PostPaid:

                        _paymentType = "Credit";
                        break;

                    case (int)PaymentMethod.Transfer:
                    case (int)PaymentMethod.Check:

                        _paymentType = "Payment to bank account";
                        break;


                    default:
                        _paymentType = "Cache";
                        break;
                }
            }
        }

        private string _paymentType;
        public string PaymentType
        {
            get { return _paymentType; }
            private set { _paymentType = value; }
        }
        public DateTime? PreviousOrderIssuedDate { get; set; }
        public string? PreviousOrderSerial { get; set; }
        public string? InstructionNote { get; set; }
    }
}
