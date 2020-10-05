using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using WebApplication5.Models;
using System.Net.Mail;
using System.Web;
namespace WebApplication5.Models
{ //Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=table;Integrated Security=True
    //Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=table;Integrated Security=True;
    public class employeedb
    {
        SqlConnection con = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=table;Integrated Security=True");
        public string Saverecord(employee emp)
        {
            try
            {
                SqlCommand com = new SqlCommand("Sp_Employee_Add", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@email", emp.email);
                com.Parameters.AddWithValue("@fname", emp.fname);
                com.Parameters.AddWithValue("@lname", emp.lname);
                com.Parameters.AddWithValue("@country", emp.country);
                com.Parameters.AddWithValue("@freq", emp.freq);
                //------------------------------------------------------------
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                //note to use this we have granted third party access from Google account and also do some settings
                //in gmail account. I am hiding the password of my email.Hope you will understand.
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new System.Net.NetworkCredential("yaaddhugga@gmail.com", "AUDI@a44");
                smtp.EnableSsl = true;
                MailMessage msg = new MailMessage();
                msg.Subject = "Hi " + emp.fname;
                msg.Body = "Thank you for the subscription.";
                string toaddress = emp.email;
                msg.To.Add(toaddress);//yaaddhuggaId is for refernce.
                string fromaddress = " Avinoor Singh <yaaddhugga@gmail.com>";
                msg.From = new MailAddress(fromaddress);
                try
                {
                    smtp.Send(msg);
                }
                catch (Exception)
                {
                    return ("Please enable third party access from Google account from the ID you are using to send emails. ");
                }
                //------------------------------------------------------------
                con.Open();
                com.ExecuteNonQuery();
                con.Close();
                return ("Your data has been stored in our database!!! please check your email.");
            }
            catch (Exception ex)
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                return (ex.Message.ToString());
            }
       
        }
    }
}
