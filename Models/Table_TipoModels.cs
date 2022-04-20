using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace CRUD.Models
{
    public class Table_TipoModels
    {
        public int TipoID { get; set; }
        public string TipoTexto { get; set; }
        public List<SelectListItem> ListTipo { get; set; }
    }
}
