using System;
using System.Collections.Generic;

namespace LoginMVC.Models
{
    public partial class Roles
    {
        public int Idrol { get; set; }
        public string Nombrerol { get; set; }
        public int Idusuarios { get; set; }

        public Usuarios IdusuariosNavigation { get; set; }
    }
}
