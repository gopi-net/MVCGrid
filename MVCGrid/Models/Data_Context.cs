using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace MVCGrid.Models
{
   public class Data_Context
    {
        SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MVCConnection"].ToString());
        SqlDataAdapter da;
        string command;
        public List<Register> GetUsers()
        {
            List<Register> data = new List<Register>();
            try
            {
                command = "select * from Registers";
                da = new SqlDataAdapter(command, connection);
                DataTable dt = new DataTable();
                da.Fill(dt);
                foreach (DataRow item in dt.Rows)
                {
                    Register newReg = new Register();
                    newReg.Name = (string)item["Name"];
                    newReg.Email = (string)item["Email"];
                    newReg.Mobile = (string)item["Mobile"];
                    newReg.Username = (string)item["Username"];
                    data.Add(newReg);
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
            return data;
        }
        public Register GetUser(string userName)
        {
            Register newData = new Register();
            try
            {
                command = "select * from Registers where Username='"+userName+"'";
                da = new SqlDataAdapter(command, connection);
                DataTable dt = new DataTable();
                da.Fill(dt);
                newData.Name = dt.Rows[0].Field<string>("Name");
                newData.Email = dt.Rows[0].Field<string>("Email");
                newData.Mobile = dt.Rows[0].Field<string>("Mobile");
                newData.Username = dt.Rows[0].Field<string>("Username");
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return newData;
        }
        public int AddUser(Register newReg)
        {
            int result=default(int);
            try
            {
                command = string.Format("Insert into Registers values('{0}','{1}','{2}','{3}','{4}')",newReg.Username,newReg.Name,newReg.Email,newReg.Mobile,newReg.Password);
                SqlCommand commander = new SqlCommand(command, connection);
                connection.Open();
               result=commander.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                connection.Close();
                throw ex;
            }
            return result;
        }
        public int UpdateUser(Register newReg)
        {
            int result = default(int);
            try
            {
                command = string.Format("Update Registers set Name='{0}',Email='{1}',Mobile='{2}'", newReg.Name, newReg.Email, newReg.Mobile);
                SqlCommand commander = new SqlCommand(command, connection);
                connection.Open();
                result = commander.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                connection.Close();
                throw ex;
            }
            return result;
        }
        public int DeleteUser(Register deleteData)
        {
            int result = default(int);
            try
            {
                command = string.Format("Delete From Registers where Username='"+ deleteData.Username + "'");
                SqlCommand commander = new SqlCommand(command, connection);
                connection.Open();
                result = commander.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                connection.Close();
                throw ex;
            }
            return result;
        }
    }
}
