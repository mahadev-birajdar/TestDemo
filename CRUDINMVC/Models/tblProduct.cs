//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CRUDINMVC.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class tblProduct
    {
        public int PROD_ID { get; set; }
        public string PROD_NAME { get; set; }
        public Nullable<decimal> PROD_PRICE { get; set; }
        public Nullable<int> PROD_UNIT { get; set; }
        public Nullable<int> PROD_CATEGORY_ID { get; set; }
    
        public virtual tblCategory tblCategory { get; set; }
    }
}
