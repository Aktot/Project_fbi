//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Project_fbi
{
    using System;
    using System.Collections.Generic;
    
    public partial class History
    {
        public int ID { get; set; }
        public int ImageId { get; set; }
        public System.DateTime Date { get; set; }
        public bool IsDecrypted { get; set; }
    
        public virtual ImageCollection ImageCollection { get; set; }
    }
}