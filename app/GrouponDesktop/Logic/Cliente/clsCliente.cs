using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using GrouponDesktop.Logic.Global;

namespace GrouponDesktop.Logic
{
    public class clsCliente
    {
        
        public List<Cliente> GetClientes()
        {
            //Va -1 porque el usuario no puede cargar numeros negativos
            return this.GetClientes("", "", -1, "");
        }

        public List<Cliente> GetClientes(String nombre, String apellido, Int32 dni, String email)
        {
            List<Cliente> listaClientes = new List<Cliente>();

            Dbaccess.DBConnect();

            String sqlwhere = "c.idusuario > 0 ";
            if (nombre != "")
                sqlwhere += "and c.nombre like @nombre ";

            if (apellido != "")
                sqlwhere += "and c.apellido like @apellido ";

            if (dni >= 0)
                sqlwhere += "and c.dni = @dni ";

            if (email != "")
                sqlwhere += "and c.email like @email ";

            String sqlstr = "select c.idcliente, c.nombre, c.apellido, c.dni, c.email, c.telefono, c.direccion, c.codigo_postal, ";
            sqlstr += "Convert(char(10),c.fecha_nacimiento,102) fecha_nacimiento, u.idusuario, u.clave, c.credito_actual, c.habilitado, ";
            sqlstr += "cc.idciudad, ci.descripcion ciudad, u.idusuario, u.username, u.habilitado as usuariohabilitado from ORION.clientes c  ";
            sqlstr += "left join ORION.clientes_ciudades cc on cc.idcliente = c.idcliente left join ORION.ciudades ci on ci.idciudad = cc.idciudad ";
            sqlstr += "left join ORION.usuarios u on u.idusuario = c.idusuario ";
            sqlstr += "where " + sqlwhere + " order by c.nombre, c.apellido, c.dni";

            SqlCommand sqlc = new SqlCommand(sqlstr, Dbaccess.globalConn);

            if (nombre != "")
                sqlc.Parameters.AddWithValue("@nombre", "%" + nombre + "%");

            if (apellido != "")
                sqlc.Parameters.AddWithValue("@apellido", "%" + apellido + "%");

            if (dni >= 0)
                sqlc.Parameters.AddWithValue("@dni", dni);

            if (email != "")
                sqlc.Parameters.AddWithValue("@email", "%" + email + "%");

            SqlDataReader dr1 = sqlc.ExecuteReader();

            //Hago un corte de control para cargar las ciudades
            Boolean hayDatos;
            Int32 idcliente_actual = 0;

            if (dr1.Read())
            {
                idcliente_actual = Convert.ToInt32(dr1["idcliente"]);
                hayDatos = true;
            }
            else
                hayDatos = false;

            while (hayDatos)
            {
                Cliente unCliente = new Cliente();
                unCliente.Idcliente = idcliente_actual;
                unCliente.Nombre = dr1["nombre"].ToString();
                unCliente.Apellido = dr1["apellido"].ToString();
                unCliente.Mail = dr1["email"].ToString();
                unCliente.DNI = Convert.ToInt32(dr1["dni"]);
                unCliente.Direccion = dr1["direccion"].ToString();
                unCliente.CodPostal = dr1["codigo_postal"].ToString();
                unCliente.Telefono = dr1["telefono"].ToString();

                unCliente.FechaNacimiento = DateTime.ParseExact(dr1["fecha_nacimiento"].ToString(), "yyyy.MM.dd", null);
                unCliente.Habilitado = Convert.ToBoolean(dr1["habilitado"]);
                unCliente.UsuarioAsociado.Idusuario = Convert.ToInt32(dr1["idusuario"].ToString());
                unCliente.UsuarioAsociado.Username = dr1["username"].ToString();
                unCliente.UsuarioAsociado.Habilitado = Convert.ToBoolean(dr1["usuariohabilitado"].ToString());
                

                while (hayDatos && unCliente.Idcliente == idcliente_actual)
                {

                    unCliente.Ciudades.Add(new Ciudad(Convert.ToInt32(dr1["idciudad"]), dr1["ciudad"].ToString()));

                    if (dr1.Read())
                    {
                        idcliente_actual = Convert.ToInt32(dr1["idcliente"]);
                    }
                    else
                    {
                        hayDatos = false;
                    }
                }

                listaClientes.Add(unCliente);
            }

            dr1.Close();
            dr1.Dispose();

            sqlc.Dispose();

            Dbaccess.DBConnect();

            return listaClientes ;
        }

    }
}
