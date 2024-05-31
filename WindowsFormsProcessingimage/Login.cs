using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsProcessingimage
{
    public partial class Login : Form
    {
        MySqlConnection sqlConn = new MySqlConnection();
        MySqlCommand sqlCmd = new MySqlCommand();
        DataTable sqlDt = new DataTable();
        MySqlDataAdapter sqlDta = new MySqlDataAdapter();
        MySqlDataReader sqlDd;
        DataSet DS = new DataSet();

        string sqlQuery;

        string server = "localhost";
        string username = "root";
        string password = "123456789";
        string database = "processingimage";
        public Login()
        {
            InitializeComponent();
            CenterToScreen();
        }
       
        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username1 = txtUser.Text;

            sqlConn.ConnectionString = "server=" + server + ";" + "username=" + username + ";" + "password=" + password + ";" + "database=" + database;
            try
            {
                sqlConn.Open();


                // Xây dựng câu truy vấn kiểm tra tài khoản
                string sqlQuery = "SELECT COUNT(*) FROM users WHERE username = @Username AND password = @Password";

                MySqlCommand sqlCmd = new MySqlCommand(sqlQuery, sqlConn);
                sqlCmd.Parameters.AddWithValue("@Username", txtUser.Text);
                sqlCmd.Parameters.AddWithValue("@Password", txtPass.Text);

                // Thực thi câu truy vấn
                int count = Convert.ToInt32(sqlCmd.ExecuteScalar());

                if (count > 0)
                {
                    Form1 mainForm = new Form1(username1);
                    mainForm.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                sqlConn.Close();
            }


        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        //chuyển sang mục đăng nhập
        private void linkLogin_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            groupBox1.Visible = false;
            grLogin.Visible = true;
            
        }
        //đăng ký tài khoản
        private void button1_Click(object sender, EventArgs e)
        {
            string username = txtUserDangky.Text;
            string password = txtPassDangKy.Text;
            string confirmPassword = txtComfirm.Text;

            if (password != confirmPassword)
            {
                MessageBox.Show("Mật khẩu và xác nhận mật khẩu không khớp!");
                return;
            }

            MySqlConnection sqlConn = new MySqlConnection();
            sqlConn.ConnectionString = $"server={server};username={this.username};password={this.password};database={database}";

            try
            {
                sqlConn.Open();

                // Check if the username already exists
                string checkUserQuery = "SELECT COUNT(*) FROM users WHERE username = @Username";
                MySqlCommand checkUserCmd = new MySqlCommand(checkUserQuery, sqlConn);
                checkUserCmd.Parameters.AddWithValue("@Username", username);
                int userCount = Convert.ToInt32(checkUserCmd.ExecuteScalar());

                if (userCount > 0)
                {
                    MessageBox.Show("Tên đăng nhập đã tồn tại!");
                    return;
                }

                // Insert new user
                string sqlQuery = "INSERT INTO users (username, password) VALUES (@Username, @Password)";
                MySqlCommand sqlCmd = new MySqlCommand(sqlQuery, sqlConn);
                sqlCmd.Parameters.AddWithValue("@Username", username);
                sqlCmd.Parameters.AddWithValue("@Password", password);
                sqlCmd.ExecuteNonQuery();

                MessageBox.Show("Đăng ký thành công!");

                // Optionally, close the registration form and show the login form
                groupBox1.Visible = false;
                grLogin.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                sqlConn.Close();
            }
        
    }
        //chuyển sang đăng ký
        private void linkRegister_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            groupBox1.Visible=true;
            grLogin.Visible=false;
        }
    }
        
    
}
