using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace DataReader
{
    public partial class Form1 : Form
    {

        SqlConnection sql = new SqlConnection(@"Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=tutorial;Data Source=LeandroDuran");

     
        public Form1()
        {
            InitializeComponent();
        }

        private void Buscarbutton_Click(object sender, EventArgs e)
        {
            string cadSql = "Select * from vendedor where clave = '" + ClavetextBox.Text + "'";
            SqlCommand comando = new SqlCommand(cadSql,sql);
            sql.Open();

            SqlDataReader leer = comando.ExecuteReader();
            if (leer.Read() == true) {
                NombretextBox.Text = leer["Nombre"].ToString();
                ApellidotextBox.Text = leer["Apellido"].ToString();
                CiudadtextBox.Text = leer["Ciudad"].ToString();
            }
            else {
                MessageBox.Show("No se encontro Registro...");

                NombretextBox.Text = "";
                ApellidotextBox.Text = "";
                CiudadtextBox.Text = "";
                CiudadtextBox.Text = string.Empty;
            }
            sql.Close();
        }
    }
}
