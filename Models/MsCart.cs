//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ProjectPSDLab.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class MsCart
    {
        public int CartID { get; set; }
        public int UserID { get; set; }
        public int SuplementID { get; set; }
        public int Quantity { get; set; }
    
        public virtual MsSuplement MsSuplement { get; set; }
        public virtual MsUser MsUser { get; set; }
    }
}
