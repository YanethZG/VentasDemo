namespace Ventas.Models
{
    public class ClienteModel
    {
        public int IdCliente { get; set; }
        public string Nombre { get; set; }

        public string Apellido { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
        public string Direccion { get; set; }
        public DateTime CreadoEn {  get; set; }

    }
}
