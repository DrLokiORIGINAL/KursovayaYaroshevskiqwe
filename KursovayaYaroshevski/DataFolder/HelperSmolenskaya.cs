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
    
    public partial class HelperSmolenskaya
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public HelperSmolenskaya()
        {
            this.Smolenskaya = new HashSet<Smolenskaya>();
        }
    
        public int IdHelperSmolenskaya { get; set; }
        public string FLMHelperSmolenskaya { get; set; }
        public string NumberPhoneHelperSmolenskaya { get; set; }
        public string EmailHelperSmolenskaya { get; set; }
        public string PositionHelperSmolenskaya { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Smolenskaya> Smolenskaya { get; set; }
    }
}