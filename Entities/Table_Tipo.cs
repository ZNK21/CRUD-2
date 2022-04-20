using System.ComponentModel.DataAnnotations;

namespace CRUD.Entities
{
    public class Table_Tipo
    {
        [Key()]
        public int TipoID { get; set; }
        public string TipoTexto { get; set; }
    }

    public class ListadoTipo
    {
        public int TipoID { get; set; }
        public string TipoTexto { get; set; }
    }
}
