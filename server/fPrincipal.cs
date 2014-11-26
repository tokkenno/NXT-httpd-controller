using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace NXTRemoteSC
{
    public partial class fPrincipal : Form
    {

        public fPrincipal()
        {
            InitializeComponent();
            Manager.Initialize();
        }

        private void bConectar_Click(object sender, EventArgs e)
        {
            try
            {
                if (Manager.ConnectCOM(System.Convert.ToInt32(this.tbCOM.Text)))
                    this.bConectar.Text = "Desconectar";
            }
            catch { }
        }

        private void bDerecha_Click(object sender, EventArgs e)
        {
            Manager.Derecha();
        }

        private void tbAcce_ValueChanged(object sender, EventArgs e)
        {
            switch (this.tbAcce.Value)
            {
                case 0:
                    Manager.Atras();
                    break;
                case 1:
                    Manager.Frenar();
                    break;
                case 2:
                    Manager.Acelerar();
                    break;
                default:
                    Manager.Frenar();
                    break;
            }
        }

        private void bIzquierda_Click(object sender, EventArgs e)
        {
            Manager.Izquierda();
        }

        private void bStop_Click(object sender, EventArgs e)
        {
            this.tbAcce.Value = 1;
        }

        private void bParar_Click(object sender, EventArgs e)
        {
            Manager.Centrar();
        }

        private void bIDHTTP_Click(object sender, EventArgs e)
        {
            Manager.ConnectHTTP(0);
        }
    }
}
