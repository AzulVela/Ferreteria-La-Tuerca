﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TpLaTuerca.LogicaNegocio;

namespace TpLaTuerca.Presentación.Login
{
    public partial class frmLogin : Form
    {
        private readonly UsuarioService usuarioService;

        public string UsuarioLogueado { get; internal set; }

        public frmLogin()
        {
            InitializeComponent();
            usuarioService = new UsuarioService();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            //Validamos que se haya ingresado un usuario.
            if ((txtUsuario.Text == ""))
            {
                MessageBox.Show("Se debe ingresar un usuario.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            //Validamos que se haya ingresado una password
            if ((txtContraseña.Text == ""))
            {
                MessageBox.Show("Se debe ingresar una contraseña.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            var usr = usuarioService.ValidarUsuario(txtUsuario.Text, txtContraseña.Text);
            //Controlamos que las creadenciales sean las correctas. 
            if (usr != null)
            {
                // Login OK
                UsuarioLogueado = usr.NombreUsuario;

                frmPrincipal principal = new frmPrincipal();
                principal.ShowDialog();
                Close();
            }
            else
            {
                //Limpiamos el campo password, para que el usuario intente ingresar un usuario distinto.
                txtContraseña.Text = "";
                // Enfocamos el cursor en el campo password para que el usuario complete sus datos.
                txtContraseña.Focus();
                //Mostramos un mensaje indicando que el usuario/password es invalido.
                MessageBox.Show("Debe ingresar usuario y/o contraseña válidos", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {
            this.CenterToParent();
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblfecha.Text ="Fecha: " + DateTime.Now.ToShortDateString();
            lblhora.Text = "Hora: " + DateTime.Now.ToString("HH:mm");
        }

        //Al presionar enter en la caja de usuario baja hacia la contraseña
        private void txtUsuario_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        //Al presionar enter en la caja de contraseña selecciona ingresar
        private void txtContraseña_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                btnIngresar.PerformClick();
            }
        }

<<<<<<< HEAD
        private void FrmLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }

        private void btnIngresar_MouseClick(object sender, MouseEventArgs e)
        {

        }
=======
        //private void FrmLogin_FormClosing(object sender, FormClosingEventArgs e)
        //{
        //    DialogResult rpta;
        //    rpta = MessageBox.Show("¿Seguro que desea salir?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        //    if (rpta == DialogResult.No)
        //        e.Cancel = true;
        //}
>>>>>>> 339bf3fefbe84d461ccb2f30ca48f9291dc7131f
    }
}
