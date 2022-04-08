using System.ComponentModel.DataAnnotations;

namespace ApiPrueba.DataModel
{
    public class Factura
    {
        [Key]
        public  int  FacturaId { get; set; }

        public string Nombre { get; set; }

        public decimal Precio { get; set; }

        public string Categoria { get; set; }

        public int ClienteId { get; set; }

        public int ServicioId { get; set; }
    }
}
