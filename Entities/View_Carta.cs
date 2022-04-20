using System.ComponentModel.DataAnnotations;

namespace CRUD.Entities
{
    public class View_Carta
    {
        [Key()]
        public int CartaID { get; set; }
        public string CartaNombre { get; set; }
        public int CartaFuerza { get; set; }
        public string CartaTexto { get; set; }
        public string TipoTexto { get; set; }
        public int TipoID { get; set; }
    }
}
