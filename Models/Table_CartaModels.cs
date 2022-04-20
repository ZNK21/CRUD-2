using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace CRUD.Models
{
    public class Table_CartaModels
    {
        public int CartaID { get; set; }
        public int TipoID { get; set; }
        public string CartaFuerza { get; set; }
        public string CartaTexto { get; set; }
    }
}
