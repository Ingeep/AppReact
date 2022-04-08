using System.ComponentModel.DataAnnotations;

namespace ApiPrueba.DataModel
{
    public class Cliente
    {
        [Key]
        public int ClienteId { get; set; }

        public string Nombre_Completo { get; set; }

        public string Cedula { get; set; }

        public string Direccion { get; set; }

        public string Sector { get; set; }

        public string Ciudad { get; set; }

        public string Provincia { get; set; }

        public string  Telefono { get; set; }

        public string  Correo_Electronico { get; set; }

        public string Fotografia { get; set; }

    }
}
