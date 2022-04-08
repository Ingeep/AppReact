using System.ComponentModel.DataAnnotations;

namespace ApiPrueba.DataModel
{
    public class Servicio
    {
        [Key]
        public int ServicioId { get; set; }

        public string Nombre { get; set; }

        public decimal Precio { get; set; }

        public string Categoria { get; set; }
    }

}
