//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AdminConsole.Models
{
    public partial class Desktop
    {
        public Desktop()
        {
            this.TargetContainers = new HashSet<TargetContainer>();
        }
    
        [Key]
        public string DesktopCode { get; set; }
        public string Description { get; set; }
        public string ExtendedProperty { get; set; }
    
        public virtual ICollection<TargetContainer> TargetContainers { get; set; }
    }
    
}
