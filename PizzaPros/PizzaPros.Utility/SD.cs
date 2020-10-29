using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaPros.Utility
{
    public static class SD
    {
        // define role constants
        public const string ManagerRole = "Manager";
        public const string DeliverDriverRole = "DeliverDriver";
        public const string FrontDeskRole = "FrontDesk";
        public const string PizzaMakerRole = "PizzaMaker";
        public const string CustomerRole = "Customer";

        //added for shopping cart 
        public const string ShoppingCart = "ShoppingCart";

        //added for Order processing 
        public const string StatusSubmitted = "Submitted";
        public const string StatusInProcess = "Being Prepared";
        public const string StatusReady = "Ready for Pickup";
        public const string StatusCompleted = "Completed";
        public const string StatusCancelled = "Cancelled";
        public const string StatusRefunded = "Refunded";

        public const string PaymentStatusPending = "Pending";
        public const string PaymentStatusApproved = "Approved";
        public const string PaymentStatusRejected = "Rejected";
    }
}
