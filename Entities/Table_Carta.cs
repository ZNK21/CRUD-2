using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRUD.Entities
{
    public class Table_Carta
    {
        [Key()]
        public int CartaID { get; set; }
        public string CartaNombre { get; set; }
        public int TipoID { get; set; }
        public int CartaFuerza { get; set; }
        public string CartaTexto { get; set; }
    }
}
