//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Student_Praktica
{
    using System;
    using System.Collections.Generic;
    
    public partial class User
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public int ID_Role { get; set; }
        public int ID_Department { get; set; }
    
        public virtual Department Department { get; set; }
        public virtual Role Role { get; set; }
    }
}
