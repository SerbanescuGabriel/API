//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace API.Db.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class UserPayment
    {
        public long UserPaymentId { get; set; }
        public string CVV { get; set; }
        public System.DateTime ExprirationDate { get; set; }
        public string OwnerName { get; set; }
        public bool IsActive { get; set; }
        public long UserId { get; set; }
    
        public virtual User User { get; set; }
    }
}
