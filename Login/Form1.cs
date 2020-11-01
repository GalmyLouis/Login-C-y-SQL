using System;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;


namespace Login
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }
        public void Logins()
        {
            try
            {
                string Con = ConfigurationManager.ConnectionStrings["Con"].ConnectionString;
                using (SqlConnection Conexion=new SqlConnection(Con))
                {
                    Conexion.Open();
                    using (SqlCommand cmd=new SqlCommand("SELECT usuario,contrasenya FROM TblAdm where usuario='"+txtUser+"'AND contrasenya='" + txtpasswor + "'", Conexion))
                    {
                        SqlDataReader dr = cmd.ExecuteReader();
                        if (dr.Read())
                        {
                            MessageBox.Show("Login Exitoso");

                        }
                        else
                        {
                            MessageBox.Show("Usuario o Contraseña Incorreta");
                        }
                    }
                }

            }catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void BtnIniciar_Click(object sender, EventArgs e)
        {
            Logins();
        }
    }
}
