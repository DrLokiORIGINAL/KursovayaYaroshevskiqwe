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
    
    public partial class Smolenskaya
    {
        public int IdSmolenskaya { get; set; }
        public int IdStaffSmolenskaya { get; set; }
        public int IdSessionSmolenskaya { get; set; }
        public int IdHelperSmolenskaya { get; set; }
        public int NumberOfNachosSmolenskaya { get; set; }
        public int NumberOfCrispsSmolenskaya { get; set; }
        public int AmountOfColaSmolenskaya { get; set; }
        public int AmountOfFantaSmolenskaya { get; set; }
        public int AmountOfSweetPopcornSmolenskaya { get; set; }
        public int AmountOfSaltedPopcornSmolenskaya { get; set; }
        public int AmountOfCaramelPopcornSmolenskaya { get; set; }
        public int IdCleaning { get; set; }
    
        public virtual Cleaning Cleaning { get; set; }
        public virtual HelperSmolenskaya HelperSmolenskaya { get; set; }
        public virtual SessionSmolenskaya SessionSmolenskaya { get; set; }
        public virtual StaffSmolenskaya StaffSmolenskaya { get; set; }
    }
}
