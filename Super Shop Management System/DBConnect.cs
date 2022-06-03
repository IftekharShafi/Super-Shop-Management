using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Super_Shop_Management_System
{
    class DBConnect
    {
        SqlConnection con  = new SqlConnection();
        SqlDataReader reader = null;
        public DBConnect()
        {

            con.ConnectionString = "data source = DESKTOP-BCHDK8B\\SQLEXPRESS;" +
                                       "database = Management;" +
                                         "integrated security = SSPI";

      
       }
        public void insertData(String query)
        {
            try
            {
                con.Open();
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            finally
            {
                try
                {
                    {
                        SqlCommand cmd = con.CreateCommand();
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = query;
                        cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    ex.ToString();
                    MessageBox.Show("un");
                }
            }

     
        }
        public SqlDataReader getData(string query)
        {
            try
            {
                con.Open();
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            finally
            {
                try
                {
                    SqlCommand cmd = new SqlCommand(query, con);
                    reader = cmd.ExecuteReader();
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.ToString());
                }
            }
           
            return reader;
        }
        
        public void executeQ(string query)
        {   
            try
            {
                con.Open();
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            finally
            {
                try
                {
                    {
                        //SqlCommand cmd = con.CreateCommand();
                        //cmd.CommandType = CommandType.Text;
                        //cmd.CommandText = query;
                        //cmd.ExecuteNonQuery();
                        SqlDataAdapter ad = new SqlDataAdapter(query, con);
                        ad.SelectCommand.ExecuteNonQuery();
                        MessageBox.Show("Successfully Deleted");
                    }
                }
                catch (Exception ex)
                {
                    ex.ToString();
                    MessageBox.Show("Unsuccessfull !!!");
                }
            }
            con.Close();
        }
        public SqlDataReader getComboItem(string query)
        {
            con.Open();
            try
            {
                SqlCommand cmd = new SqlCommand(query, con);
                reader = cmd.ExecuteReader();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
            return reader;
        }


    }
}
