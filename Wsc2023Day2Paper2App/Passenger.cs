//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Wsc2023Day2Paper2App
{
    using System;
    using System.Collections.Generic;
    
    public partial class Passenger
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Passenger()
        {
            this.Tickets = new HashSet<Ticket>();
        }
    
        public string Passenger_Email { get; set; }
        public string Passenger_First_Name { get; set; }
        public string Passenger_Last_Name { get; set; }
        public string Passenger_Frequent_Flyer_Number { get; set; }
        public string Passenger_Passport_number { get; set; }
        public Nullable<int> Contact_number { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}