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
    
    public partial class CartProduct
    {
        public long CartProductId { get; set; }
        public long CartId { get; set; }
        public long ProductId { get; set; }
    
        public virtual Cart Cart { get; set; }
        public virtual Product Product { get; set; }
    }
}
