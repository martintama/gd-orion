﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace GrouponDesktop.Base
{
    public class Usuario
    {
        // CONTRUCTORES
        public Usuario()
        {
            this.RolAsociado = new Rol();
            this.TipoUsuarioAsociado = new TipoUsuario();
        }

        // PROPIEDADES
        public int Idusuario { get; set; }

        public String Username { get; set; }

        public String Clave { get; set; }

        public Rol RolAsociado { get; set; }

        public TipoUsuario TipoUsuarioAsociado { get; set; }

        public Boolean Habilitado { get; set; }

        // METODOS
        public Int16 Grabar(SqlConnection sqlconn, SqlTransaction sqltran){
            SqlCommand cmd = new SqlCommand("Orion.Usuarios_Grabar", sqlconn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Transaction = sqltran;
            
            cmd.Parameters.AddWithValue("@username", this.Username);
            if (this.Clave != "")
            {
                cmd.Parameters.AddWithValue("@pass", Hasher.ConvertirSHA256(this.Clave));
            }
            cmd.Parameters.AddWithValue("@idrol", this.RolAsociado.Idrol);
            cmd.Parameters.AddWithValue("@idtipo_usuario", this.TipoUsuarioAsociado.Idtipo_usuario);

            SqlParameter returnParameter;
            returnParameter = cmd.Parameters.Add("@ReturnVal", SqlDbType.Int);
            returnParameter.Direction = ParameterDirection.ReturnValue;

            SqlParameter idusuarioParameter;
            idusuarioParameter = cmd.Parameters.AddWithValue("@idusuario", this.Idusuario);
            idusuarioParameter.Direction = ParameterDirection.InputOutput;

            cmd.ExecuteNonQuery();
            cmd.Dispose();

            this.Idusuario = Convert.ToInt32(idusuarioParameter.Value);
            return Convert.ToInt16(returnParameter.Value);
            
        }

        internal void Inhabilitar()
        {
            if (this.Idusuario > 0)
            {
                Dbaccess.DBConnect();

                String sqlstr = "update orion.usuarios set habilitado = 0 where idusuario = @idusuario";

                SqlCommand sqlc = new SqlCommand(sqlstr, Dbaccess.globalConn);
                sqlc.Parameters.AddWithValue("@idusuario", this.Idusuario);

                sqlc.ExecuteNonQuery();

                sqlc.Dispose();

                Dbaccess.DBDisconnect();
            }
        }

        internal void Habilitar()
        {
            if (this.Idusuario > 0)
            {
                Dbaccess.DBConnect();

                String sqlstr = "update orion.usuarios set habilitado = 1 where idusuario = @idusuario";

                SqlCommand sqlc = new SqlCommand(sqlstr, Dbaccess.globalConn);
                sqlc.Parameters.AddWithValue("@idusuario", this.Idusuario);

                sqlc.ExecuteNonQuery();

                sqlc.Dispose();

                Dbaccess.DBDisconnect();
            }
        }

        internal short CambiarClave(string claveActual, string claveNueva)
        {
            Int16 result = 0;

            Dbaccess.DBConnect();

            SqlCommand sqlc = new SqlCommand("ORION.Usuarios_CambiarClave", Dbaccess.globalConn);
            sqlc.CommandType = CommandType.StoredProcedure;

            sqlc.Parameters.AddWithValue("@idusuario", Sesion.GetUsuarioAsociado().Idusuario);
            sqlc.Parameters.AddWithValue("@claveactual", Hasher.ConvertirSHA256(claveActual));
            sqlc.Parameters.AddWithValue("@clavenueva", Hasher.ConvertirSHA256(claveNueva));

            SqlParameter returnParameter = sqlc.Parameters.Add("@ReturnVal", SqlDbType.Int);
            returnParameter.Direction = ParameterDirection.ReturnValue;

            sqlc.ExecuteNonQuery();

            result = Convert.ToInt16(returnParameter.Value);

            
            Dbaccess.DBDisconnect();

            return result;
        }

        internal void GetDatosUsuario()
        {
            if (this.Idusuario > 0)
            {
                Dbaccess.DBConnect();

                String sqlstr = "select username, idrol, idtipo_usuario from orion.usuarios where idusuario = @idusuario";

                SqlCommand sqlc = new SqlCommand(sqlstr, Dbaccess.globalConn);
                sqlc.Parameters.AddWithValue("@idusuario", this.Idusuario);

                SqlDataReader dr1 = sqlc.ExecuteReader();

                if (dr1.Read())
                {
                    this.Username = dr1["username"].ToString();
                    this.TipoUsuarioAsociado = new TipoUsuario(Convert.ToInt16(dr1["idtipo_usuario"]), "");
                    this.RolAsociado = new Rol(Convert.ToInt32(dr1["idrol"]), "");

                }

                sqlc.Dispose();

                Dbaccess.DBDisconnect();
            }
        }

    }
}
