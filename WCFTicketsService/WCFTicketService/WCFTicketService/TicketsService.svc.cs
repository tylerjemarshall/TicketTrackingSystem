using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Web.Configuration;

namespace WCFTicketService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "TicketsService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select TicketsService.svc or TicketsService.svc.cs at the Solution Explorer and start debugging.
  
  public class TicketsService : ITicketsService
    {
        public void DoWork()
        {
        }

        public List<Ticket> SelectByEmpNum(int assignedToNum)
        {
            List<Ticket> ti = new List<Ticket>();

            string connectionString = WebConfigurationManager.ConnectionStrings["EZDB"].ConnectionString;

            String sql = "Select TicketNumber from Tickets where AssignedTo=@assignedTo";
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@assignedTo", assignedToNum);

            con.Open();

            //if asked to return a list....
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Ticket tick = new Ticket(Convert.ToInt32(reader["TicketNumber"]));
                ti.Add(tick);

            }
            con.Close();
            return ti;
        }

        public Ticket SelectTicketByID(int ticNum)
        {
            Ticket t = null;

            string sql = "SELECT TicketNumber,Building,Description,Status From Tickets where TicketNumber=@TicketNumber";

            string connectionString = WebConfigurationManager.ConnectionStrings["EZDB"].ConnectionString;
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@TicketNumber", ticNum);

            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {

                 t = new Ticket(Convert.ToInt32(reader["TicketNumber"]),
                    reader["Building"].ToString(),
                     reader["Description"].ToString(),
                     reader["Status"].ToString());

             
            }
            con.Close();

            return t;
        }

        public void UpdateCompleted(string completed, int ticketNum)
        {
            string connectionString = WebConfigurationManager.ConnectionStrings["EZDB"].ConnectionString;
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "UPDATE Tickets SET Status=@Status where EmployeeNumber=EmployeeNumber and TicketNumber=@TicketNumber";
            cmd.Parameters.AddWithValue("@Status", completed);
            cmd.Parameters.AddWithValue("@TicketNumber", ticketNum);
              
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }


    }
}
