using MVC_Contactos.Models;
using System.Data;
using System.Data.SqlClient;

namespace MVC_Contactos.Data
{
    public class EmpleadoData
    {
        public List<EmpleadoModel> ListarEmpleados()
        {
            var oListaEmpleado = new List<EmpleadoModel>();

            //Instancia de clase de conexión
            var cn = new ConexionData();

            //Creamos la conexión
            using (var conexion = new SqlConnection(cn.GetCadenaSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("Select * from TBLEMPLEADO", conexion);

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        oListaEmpleado.Add(new EmpleadoModel()
                        {
                            IdEmpleado = Convert.ToInt32(dr["IdEmpleado"]),
                            Nombre = dr["StrNombre"].ToString(),
                            NumDocumento = Convert.ToInt32(dr["NumDocumento"]),
                            Direccion = dr["StrDireccion"].ToString(),
                            Telefono = dr["StrTelefono"].ToString(),
                            Email = dr["StrEmail"].ToString()

                        });
                    }
                }
            }
            return oListaEmpleado;
        }

        public EmpleadoModel ObtenerEmpleado(int IdEmpleado)
        {
            var olistaEmpleado = new EmpleadoModel();

            //Instancia de clase de conexión
            var cn = new ConexionData();

            //Creamos la conexión
            using (var conexion = new SqlConnection(cn.GetCadenaSQL()))
            {
                conexion.Open();
                string sentencia = $"select * from TBLCLIENTES where IdCliente = '{IdEmpleado}'";
                SqlCommand cmd = new SqlCommand(sentencia, conexion);


                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        olistaEmpleado.IdEmpleado = Convert.ToInt32(dr["IdCliente"]);
                        olistaEmpleado.Nombre = dr["StrNombre"].ToString();
                        olistaEmpleado.NumDocumento = Convert.ToInt32(dr["NumDocumento"]);
                        olistaEmpleado.Direccion = dr["StrDireccion"].ToString();
                        olistaEmpleado.Telefono = dr["StrTelefono"].ToString();
                        olistaEmpleado.Email = dr["StrEmail"].ToString();
                    }

                }
            }
            return olistaEmpleado;
        }

        public bool GuardarEmpleado(EmpleadoModel oEmpleado)
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
                    cmd.Parameters.AddWithValue("StrNombre", oEmpleado.Nombre);
                    cmd.Parameters.AddWithValue("NumDocumento", oEmpleado.NumDocumento);
                    cmd.Parameters.AddWithValue("StrDireccion", oEmpleado.Direccion);
                    cmd.Parameters.AddWithValue("StrTelefono", oEmpleado.Telefono);
                    cmd.Parameters.AddWithValue("StrEmail", oEmpleado.Email);
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


        public bool EditarEmpleado(EmpleadoModel oEmpleado)
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
                    cmd.Parameters.AddWithValue("IdCliente", oEmpleado.IdEmpleado);
                    cmd.Parameters.AddWithValue("StrNombre", oEmpleado.Nombre);
                    cmd.Parameters.AddWithValue("NumDocumento", oEmpleado.NumDocumento);
                    cmd.Parameters.AddWithValue("StrDireccion", oEmpleado.Direccion);
                    cmd.Parameters.AddWithValue("StrTelefono", oEmpleado.Telefono);
                    cmd.Parameters.AddWithValue("StrEmail", oEmpleado.Email);
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

        public bool EliminarEmpleado(int IdEmpleado)
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
                    cmd.Parameters.AddWithValue("IdEmpleado", IdEmpleado);

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


