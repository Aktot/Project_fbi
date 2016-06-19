using System.ComponentModel.DataAnnotations;
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
    
    public partial class UserCollection
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public UserCollection()
        {
            this.ImageCollection = new HashSet<ImageCollection>();
        }
    
        public int ID { get; set; }
        [Required(ErrorMessage = "Будь ласка, введіть своє ім'я")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Будь ласка, введіть своє прізвище")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Будь ласка, введіть свій емейл")]
        [RegularExpression(".+\\@.+\\..+", ErrorMessage = "Ви ввели некоректний email")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Будь ласка, введіть свій телефон")]
        public int Phone { get; set; }
        [Required(ErrorMessage = "Будь ласка, введіть свій пароль")]
        public string Password { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ImageCollection> ImageCollection { get; set; }
    }
}
