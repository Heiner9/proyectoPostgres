using System;
using System.Collections.Generic;

namespace  LoginMVC.Models
{
    public partial class Usuarios
    {
       public Usuarios()
        {
            Roles = new HashSet<Roles>();
        }

        public int Id { get; set; }
        public string Userid { get; set; }
        public string Nombre { get; set; }
        public string Pass { get; set; }

        public ICollection<Roles> Roles { get; set; }

    
    }
}
