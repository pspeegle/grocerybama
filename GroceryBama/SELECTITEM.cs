//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GroceryBama
{
    using System;
    using System.Collections.Generic;
    
    public partial class SELECTITEM
    {
        public int item_id { get; set; }
        public int quantity { get; set; }
        public int order_id { get; set; }
    
        public virtual ITEM ITEM { get; set; }
        public virtual ORDERR ORDERR { get; set; }
    }
}
