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
    
    public partial class HelperPaveletskaya
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public HelperPaveletskaya()
        {
            this.Paveletskaya = new HashSet<Paveletskaya>();
        }
    
        public int IdHelperPaveletskaya { get; set; }
        public string FLMHelperPaveletskaya { get; set; }
        public string NumberPhoneHelperPaveletskaya { get; set; }
        public string EmailHelperPaveletskaya { get; set; }
        public string PositionHelperPaveletskaya { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Paveletskaya> Paveletskaya { get; set; }
    }
}
