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
    
    public partial class SessionNovokuznetskaya
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SessionNovokuznetskaya()
        {
            this.Novokuznetskaya = new HashSet<Novokuznetskaya>();
        }
    
        public int IdSessionNovokuznetskaya { get; set; }
        public string NameSessionNovokuznetskaya { get; set; }
        public string ARSeissionNovokuznetskaya { get; set; }
        public string TimeSessionNovokuznetskaya { get; set; }
        public byte[] ImageSessionNovokuznetskaya { get; set; }
        public System.DateTime DateSessionNovokuznetskaya { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Novokuznetskaya> Novokuznetskaya { get; set; }
    }
}
