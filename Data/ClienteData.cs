using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MVC_Contactos.Models;
using System.Data;
using System.Data.SqlClient;

namespace MVC_Contactos.Data
{
    public class ClienteData
    {
        public List<ClienteModel> Listarclientes()
        {
            var oListaCliente = new List<ClienteModel>();

            //Instancia de clase de conexión
            var cn = new ConexionData();

            //Creamos la conexión
            using (var conexion = new SqlConnection(cn.GetCadenaSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("Select * from TBLCLIENTES",conexion);
                
                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        oListaCliente.Add(new ClienteModel()
                        {
                            IdCliente = Convert.ToInt32(dr["IdCliente"]),
                            Nombre = dr["StrNombre"].ToString(),
                            NumDocumento = Convert.ToInt32(dr["NumDocumento"]),
                            Direccion = dr["StrDireccion"].ToString(),
                            Telefono = dr["StrTelefono"].ToString(),
                            Email = dr["StrEmail"].ToString()

                        });
                    }
                }
            }
            return oListaCliente;
        }

        public ClienteModel Obtenercliente(int IdContacto)
        {
            var oListaCliente = new ClienteModel();

            //Instancia de clase de conexión
            var cn = new ConexionData();

            //Creamos la conexión
            using (var conexion = new SqlConnection(cn.GetCadenaSQL()))
            {
                conexion.Open();
                string sentencia = $"select * from TBLCLIENTES where IdCliente = '{IdContacto}'";
                SqlCommand cmd = new SqlCommand(sentencia, conexion);
                

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        oListaCliente.IdCliente = Convert.ToInt32(dr["IdCliente"]);
                        oListaCliente.Nombre = dr["StrNombre"].ToString();
                        oListaCliente.NumDocumento = Convert.ToInt32(dr["NumDocumento"]);
                        oListaCliente.Direccion = dr["StrDireccion"].ToString();
                        oListaCliente.Telefono = dr["StrTelefono"].ToString();
                        oListaCliente.Email = dr["StrEmail"].ToString();
                    }
                    
                }
            }
            return oListaCliente;
        }

        public bool Guardarcliente(ClienteModel oCliente)
        {
            bool respuesta;
            try
            {
                //Instancia de clase de conexión
                var cn = new ConexionData();

                //Creamos la conexión
                using (var conexion = new SqlConnection(cn.GetCadenaSQL()))
                {
                    conexion.Open();
                    
                    SqlCommand cmd = new SqlCommand("actualizar_Cliente", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("IdCliente", 0);
                    cmd.Parameters.AddWithValue("StrNombre", oCliente.Nombre);
                    cmd.Parameters.AddWithValue("NumDocumento", oCliente.NumDocumento );
                    cmd.Parameters.AddWithValue("StrDireccion", oCliente.Direccion);
                    cmd.Parameters.AddWithValue("StrTelefono", oCliente.Telefono);
                    cmd.Parameters.AddWithValue("StrEmail", oCliente.Email);
                    cmd.Parameters.AddWithValue("StrUsuarioModifica", "Andre");
                    cmd.Parameters.AddWithValue("DtmFechaModifica", DateTime.Now);

                    cmd.ExecuteNonQuery();
            

                }
                respuesta = true;
            }
            catch (Exception ex)
            {
                string Msgerror = ex.Message;
                respuesta = false;
            }
            
            return respuesta ;
        }


        public bool EditarCliente(ClienteModel oCliente)
        {
            bool respuesta;
            try
            {
                //Instancia de clase de conexión
                var cn = new ConexionData();

                //Creamos la conexión
                using (var conexion = new SqlConnection(cn.GetCadenaSQL()))
                {
                    conexion.Open();

                    SqlCommand cmd = new SqlCommand("actualizar_Cliente", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("IdCliente", oCliente.IdCliente);
                    cmd.Parameters.AddWithValue("StrNombre", oCliente.Nombre);
                    cmd.Parameters.AddWithValue("NumDocumento", oCliente.NumDocumento);
                    cmd.Parameters.AddWithValue("StrDireccion", oCliente.Direccion);
                    cmd.Parameters.AddWithValue("StrTelefono", oCliente.Telefono);
                    cmd.Parameters.AddWithValue("StrEmail", oCliente.Email);
                    cmd.Parameters.AddWithValue("StrUsuarioModifica", "Andre");
                    cmd.Parameters.AddWithValue("DtmFechaModifica", DateTime.Now);

                    cmd.ExecuteNonQuery();


                }
                respuesta = true;
            }
            catch (Exception ex)
            {
                string Msgerror = ex.Message;
                respuesta = false;
            }

            return respuesta;
        }

        public bool EliminarCliente(int IdCliente)
        {
            bool respuesta;
            try
            {
                //Instancia de clase de conexión
                var cn = new ConexionData();

                //Creamos la conexión
                using (var conexion = new SqlConnection(cn.GetCadenaSQL()))
                {
                    conexion.Open();

                    SqlCommand cmd = new SqlCommand("Eliminar_Cliente", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("IdCliente", IdCliente);
                    
                    cmd.ExecuteNonQuery();

                } 
                respuesta = true;
            }
            catch (Exception ex)
            {
                string Msgerror = ex.Message;
                respuesta = false;
            }

            return respuesta;
        }

    }
}
