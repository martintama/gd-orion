﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GrouponDesktop.Base;
using GrouponDesktop.UI;
using System.Data.SqlClient;

namespace GrouponDesktop
{
    public partial class frmLogin : Form
    {

        Boolean flagMensajeVisto = false;

        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnAcceder_Click(object sender, EventArgs e)
        {
            lblErrorMsg.Visible = false;
            int ret = loguearSistema(txtUsuario.Text, txtPassword.Text);

            switch (ret)
            {
                case 0: //Todo OK. Loguear!
                    {
                        this.Hide();
                        
                        frmMain main = new frmMain();
                        //Guardo la ventana actual
                        main.parentLogin = this;

                        main.ShowDialog();
                        break;
                    }
                case 1: //Usuario y clave incorrecta
                    {
                        lblErrorMsg.Text = "Usuario o clave incorrecta";
                        lblErrorMsg.Visible = true;

                        break;
                    }
                case 2: //Falta ingresar usuario o contraseña
                    {
                        lblErrorMsg.Text = "Ingrese correctamente su usuario y contraseña antes de continuar";
                        lblErrorMsg.Visible = true;
                        break;
                    }
                case 3: //Usuario inhabilitado
                    {
                        //la 1ra vez es falso, luego true
                        if (!flagMensajeVisto)
                        {
                            MessageBox.Show("Su usuario ha sido inhabilitado por exceso de intentos fallidos de logueos. Todavía podrá acceder al sistema con su clave correcta, pero deberá contactarse con la administración para que procedan a rehabilitar su usuario");
                            this.flagMensajeVisto = true;
                        }
                        lblErrorMsg.Text = "Usuario inhabilitado";
                        lblErrorMsg.Visible = true;
                        break;
                    }
                default:
                    {
                        lblErrorMsg.Text = "Error";
                        lblErrorMsg.Visible = true;
                        break;
                    }
            }

            txtUsuario.Text = "";
            txtPassword.Text = "";
            txtUsuario.Focus();
           
        }

        private int loguearSistema(String usuario, String password)
        {
            int return_status;

            if (txtUsuario.Text != "" && txtPassword.Text != ""){

                string passHashed = Hasher.ConvertirSHA256(password);

                try
                {
                    Sesion.ValidarUsuario(usuario, passHashed);
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Ha ocurrido un error: " + ex.Message + ". El programa se cerrará.");
                    Application.Exit();
                }
                return Convert.ToInt32(Sesion.EstadoLogin);

            }
            else
            {
                return_status = 2;
            }

            return return_status;
        }

        private void lnkRegistro_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmSeleccionTipoUsuario frmSeleccion = new frmSeleccionTipoUsuario();
            frmSeleccion.ShowDialog();
            
        }
    }
       
}
