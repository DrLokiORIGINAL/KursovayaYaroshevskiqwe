//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace KursovayaYaroshevski.DataFolder
{
    using System;
    using System.Collections.Generic;
    
    public partial class StaffPaveletskaya
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public StaffPaveletskaya()
        {
            this.Paveletskaya = new HashSet<Paveletskaya>();
        }
    
        public int IdStaffPaveletskaya { get; set; }
        public string FLMStaffPaveletskaya { get; set; }
        public string NumberPhoneStaffPaveletskaya { get; set; }
        public string EmailStaffPaveletskaya { get; set; }
        public string PositionStaffPaveletskaya { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Paveletskaya> Paveletskaya { get; set; }
    }
}