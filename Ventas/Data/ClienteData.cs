using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography.X509Certificates;
using Ventas.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Ventas.Data
{
    public class ClienteData
    {
        public string connectionString = "Data Source=GRANADOS\\SQLEXPRESS;Initial Catalog=Ventas;Integrated Security=True;Encrypt=False";  
      
        public IEnumerable<ClienteModel> GetAll()
        {
            List<ClienteModel> clienteList = new List<ClienteModel>();
            using(var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "SELECT id_cliente, nombre, apellido, telefono, correo, direccion, creado_en FROM Clientes";
                 command.CommandType = CommandType.Text;

                    using(var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ClienteModel clienteModel = new ClienteModel();
                            clienteModel.IdCliente = Convert.ToInt32(reader["id_cliente"]);
                            clienteModel.Nombre = reader["nombre"].ToString();
                            clienteModel.Apellido = reader["apellido"].ToString();
                            clienteModel.Telefono = reader["telefono"].ToString();
                            clienteModel.Correo = reader["correo"].ToString();
                            clienteModel.Direccion = reader["direccion"].ToString();
                            clienteModel.CreadoEn = Convert.ToDateTime(reader["creado_en"]);

                           clienteList.Add(clienteModel);
                             
                        }
                    }
                }

            }
        return clienteList;
        }

        public ClienteModel ?GetById(int id)
        {
            ClienteModel clienteModel = new ClienteModel();
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = @"SELECT id_cliente, nombre, apellido, telefono, correo, direccion, creado_en FROM Clientes WHERE id_cliente = @IdCliente";
                    command.Parameters.AddWithValue("@IdCliente", id);
                    command.CommandType = CommandType.Text;

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {

                            clienteModel.IdCliente = Convert.ToInt32(reader["id_cliente"]);
                            clienteModel.Nombre = reader["nombre"].ToString();
                            clienteModel.Apellido = reader["apellido"].ToString();
                            clienteModel.Telefono = reader["telefono"].ToString();
                            clienteModel.Correo = reader["correo"].ToString();
                            clienteModel.Direccion = reader["direccion"].ToString();
                            clienteModel.CreadoEn = Convert.ToDateTime(reader["creado_en"]);



                        }
                    }
                }


            }
            return clienteModel;
        }
        public void Add(ClienteModel cliente)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection= connection;
                    command.CommandText = @"NSERT INTO Clientes (nombre, apellido, telefono, correo, direccion, creado_en) VALUES ( @Nombre, @Apellido, @Telefono, @Correo, @Direccion, CURRENT_TIMESTAMP) ";
                    command.Parameters.AddWithValue("@Nombre", cliente.Nombre);
                    command.Parameters.AddWithValue("@Apellido", cliente.Apellido);
                    command.Parameters.AddWithValue("@Telefono", cliente.Telefono);
                    command.Parameters.AddWithValue("@Correo", cliente.Correo);
                    command.Parameters.AddWithValue("@Direccion", cliente.Direccion);
                    command.CommandType = CommandType.Text;
                    command.ExecuteNonQuery();

                }
            }
        }
        public void Edit(ClienteModel cliente)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = @"UPDATE Clientes SET nombre = @Nombre, SET apellido = @Apellido, SET telefono = @Telefono, SET correo = @Correo, SET direccion = @Direccion WHERE id_cliente = @IdCliente";
                    command.Parameters.AddWithValue("@Nombre", cliente.Nombre);
                    command.Parameters.AddWithValue("@Apellido", cliente.Apellido);
                    command.Parameters.AddWithValue("@Telefono", cliente.Telefono);
                    command.Parameters.AddWithValue("@Correo", cliente.Correo);
                    command.Parameters.AddWithValue("@Direccion", cliente.Direccion);
                    command.Parameters.AddWithValue("@IdCliente", cliente.IdCliente);
                    command.CommandType = CommandType.Text;
                    command.ExecuteNonQuery();


                }
            }
        }
        public void Delete(int id)
        {
            using (var connection = new SqlConnection(connectionString))
            {

                connection.Open
                ();

                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = @"DELETE FROM Clientes
                                           WHERE id_cliente = @IdCliente";

                    command.Parameters.AddWithValue("@IdCliente", id);

                    command.CommandType = CommandType.Text;

                    command.ExecuteNonQuery();
                }
            }
        }

    }

}
