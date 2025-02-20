using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace com.svnFacturame.cloud.frontend.core.ViewModel
{
    public class MenuViewModel
    {
        public List<MenuElement> elements { get; set; }
    }

    public class MenuElement
    {
        public int Id { get; set; }
        public int Nivel { get; set; }
        public string Cod_Modulo { get; set; }
        public string Des_Modulo { get; set; }
        public int Cod_NPadre { get; set; }
        public List<MenuElement> children { get; set; }
        public string Controller_Name { get; set; }
        public string Action_Name { get; set; }
        public string NombreImage { get; set; }
    }
}
