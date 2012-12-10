using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace GrouponDesktop.Base
{
    class Proveedor
    {
        // CONSTRUCTORES
        public Proveedor()
        {
            this.UsuarioAsociado = new Usuario();
        }

        // PROPIEDADES
        public Int32 Idproveedor { get; set; }

        public String RazonSocial { get; set; }

        public String Mail { get; set; }

        public String Telefono { get; set; }

        public String Direccion { get; set; }

        public String CodPostal { get; set; }

        public Ciudad Ciudad { get; set; }

        public String Cuit { get; set; }

        public Rubro Rubro { get; set; }

        public String Contacto { get; set; }

        public Usuario UsuarioAsociado { get; set; }

        //METODOS
        internal short Grabar()
        {
            Int16 return_value = 0; //Supongo que todo está bien

            Dbaccess.DBConnect();
            SqlTransaction tran = Dbaccess.globalConn.BeginTransaction();

            try
            {

                Int16 return_parameter = this.UsuarioAsociado.Grabar(Dbaccess.globalConn, tran);

                if (return_value == 0) //Si no ay problemas
                {

                    SqlCommand cmd = new SqlCommand("Orion.Proveedores_Grabar", Dbaccess.globalConn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Transaction = tran;

                    cmd.Parameters.AddWithValue("@razonsocial", this.RazonSocial);
                    cmd.Parameters.AddWithValue("@mail", this.Mail);
                    cmd.Parameters.AddWithValue("@telefono", this.Telefono);
                    cmd.Parameters.AddWithValue("@direccion", this.Direccion);
                    cmd.Parameters.AddWithValue("@codpost", this.CodPostal);
                    cmd.Parameters.AddWithValue("@ciudad", this.Ciudad.Idciudad);
                    cmd.Parameters.AddWithValue("@cuit", this.Cuit);
                    cmd.Parameters.AddWithValue("@idrubro", this.Rubro.Idrubro);
                    cmd.Parameters.AddWithValue("@contacto", this.Contacto);

                    SqlParameter returnParameter = cmd.Parameters.Add("@ReturnVal", SqlDbType.Int);
                    returnParameter.Direction = ParameterDirection.ReturnValue;

                    SqlParameter idproveedorParam = cmd.Parameters.AddWithValue("@idproveedor", this.Idproveedor);
                    idproveedorParam.Direction = ParameterDirection.InputOutput;

                    cmd.ExecuteNonQuery();

                    return_value = Convert.ToInt16(returnParameter.Value);
                    this.Idproveedor = Convert.ToInt32(idproveedorParam.Value);

                    cmd.Dispose();

                    if (return_value == 0)
                    {
                    }
                        else
                        {
                            return_value = 2; //Datos duplicados
                            this.UsuarioAsociado.Idusuario = 0; //Reseteo el idusuario
                            tran.Rollback();
    
                        }
                    
                }
                else
                {
                    return_value = 1; //Usuarios ya existentes
                    this.UsuarioAsociado.Idusuario = 0; //Reseteo el idusuario
                    tran.Rollback();

                }

            }
            catch (Exception ex)
            {

                tran.Rollback();
                return_value = 3;

            }

            tran.Dispose();
            Dbaccess.DBDisconnect();

            return return_value;
        }


    }


}
