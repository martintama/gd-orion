using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Collections;

namespace GrouponDesktop
{
    class clsLogin
    {
        public static void ValidarUsuario(String usuario, String passhashed)
        {
            clsMain.objInfoSesion = new InfoSesion();

            Dbaccess.DBConnect();

            SqlCommand sqlc = new SqlCommand("orion.LoguearUsuario", Dbaccess.globalConn);
            sqlc.CommandType = System.Data.CommandType.StoredProcedure;

            sqlc.Parameters.AddWithValue("@username", usuario);
            sqlc.Parameters.AddWithValue("@passhashed", passhashed);

            SqlDataReader dr1 = sqlc.ExecuteReader();

            if (dr1.Read())
            {
                clsMain.objInfoSesion.Idusuario = Convert.ToInt32(dr1["idusuario"]);
                clsMain.objInfoSesion.Idrol = Convert.ToInt32(dr1["idrol"]);
                clsMain.objInfoSesion.Idusuario_tipo = Convert.ToInt16(dr1["idusuario_tipo"]);
                
                dr1.Close();
                dr1.Dispose();

                clsMain.objInfoSesion.Funcionalidades = obtenerFuncionalidades(clsMain.objInfoSesion.Idrol);


            }
            else
            {
                throw new Exception("Error conectando a base de datos");
            }

            dr1.Close();
            dr1.Dispose();

            Dbaccess.DBConnect();

        }

        public static Array obtenerFuncionalidades(int idrol)
        {
            ArrayList arrFunc = new ArrayList();

            String sqlstr = "select idfuncionalidad from ORION.roles_funcionalidades where idrol = @idrol and habilitado = 1";
            SqlCommand sqlc = new SqlCommand(sqlstr, Dbaccess.globalConn);
            sqlc.Parameters.AddWithValue("@idrol", idrol);

            SqlDataReader dr1 = sqlc.ExecuteReader();

            while (dr1.Read())
            {
                arrFunc.Add(dr1["idfuncionalidad"]);
            }

            dr1.Close();

            dr1.Dispose();

           return arrFunc.ToArray();
        }
    }
}
