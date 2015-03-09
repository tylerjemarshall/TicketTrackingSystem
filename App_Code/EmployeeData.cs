using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;

/// <summary>
/// Summary description for EmployeeData
/// </summary>
public class EmployeeData
{
    public List<Building> SelectBuilding()
    {
        List<Building> buildings = new List<Building>();
        //SqlConnection con = new SqlConnection(Connections.ConnectionString());
        string conString = WebConfigurationManager.ConnectionStrings["EZTicket11"].ConnectionString;

        SqlConnection con = new SqlConnection(conString);

        SqlCommand cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandText = "SELECT BuildingId, BuildingName FROM Building";
        using (con)
        {
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                buildings.Add(new Building(
                    (int)reader["BuildingId"],
                    (string)reader["BuildingName"]));
            }
        }
        return buildings;
    }
    public List<Employee> SelectMainternanceEmployee()
    {
        List<Employee> buildings = new List<Employee>();
        string conString = WebConfigurationManager.ConnectionStrings["EZTicket11"].ConnectionString;
        SqlConnection con = new SqlConnection(conString);
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandText = "SELECT Id,LastName from Employee where Type ='Maintenance'";
        using (con)
        {
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                buildings.Add(new Employee(
                    (int)reader["Id"],
                    (string)reader["LastName"]));
            }
        }
        return buildings;
    }
    public List<Ticket> SelectTicketByPin(int id)
    {
        List<Ticket> ticket = new List<Ticket>();
        string conString = WebConfigurationManager.ConnectionStrings["EZTicket11"].ConnectionString;
        SqlConnection con = new SqlConnection(conString);
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandText = "SELECT TicketId,Email,CurrentDate,BuildingId,IssueDescription,Status FROM Ticket where TicketId = @id";
        cmd.Parameters.AddWithValue("@id", id);
        using (con)
        {
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                ticket.Add(new Ticket(
                    (int)reader["TicketId"],
                    (DateTime)reader["CurrentDate"],
                    (int)reader["BuildingId"],
                    (string)reader["IssueDescription"],
                     (string)reader["Status"],
                    (string)reader["Email"]));
            }
        }
        return ticket;
    }
    public List<Ticket> SelectTicketByEmail(string email)
    {
        List<Ticket> ticket = new List<Ticket>();
        string conString = WebConfigurationManager.ConnectionStrings["EZTicket11"].ConnectionString;
        SqlConnection con = new SqlConnection(conString);
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandText = "SELECT TicketId,Email,CurrentDate,BuildingId,IssueDescription,Status FROM Ticket where Email = @email";
        cmd.Parameters.AddWithValue("@email", email);
        using (con)
        {
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                ticket.Add(new Ticket(
                    (int)reader["TicketId"],
                    (DateTime)reader["CurrentDate"],
                    (int)reader["BuildingId"],
                    (string)reader["IssueDescription"],
                     (string)reader["Status"],
                    (string)reader["Email"]));
            }
        }
        return ticket;
    }
    public List<Ticket> SelectTicketByStatus(string status)
    {
        List<Ticket> ticket = new List<Ticket>();
        string conString = WebConfigurationManager.ConnectionStrings["EZTicket11"].ConnectionString;
        SqlConnection con = new SqlConnection(conString);
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandText = "SELECT TicketId,Email,CurrentDate,BuildingId,IssueDescription,Status FROM Ticket where Status = @status";
        cmd.Parameters.AddWithValue("@status", status);
        using (con)
        {
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                ticket.Add(new Ticket(
                    (int)reader["TicketId"],
                    (DateTime)reader["CurrentDate"],
                    (int)reader["BuildingId"],
                    (string)reader["IssueDescription"],
                     (string)reader["Status"],
                    (string)reader["Email"]));
            }
        }
        return ticket;
    }
    public List<Ticket> SelectTicketByClientName(string clientName)
    {
        List<Ticket> ticket = new List<Ticket>();
        string conString = WebConfigurationManager.ConnectionStrings["EZTicket11"].ConnectionString;
        SqlConnection con = new SqlConnection(conString);
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandText = "SELECT TicketId,Email,CurrentDate,BuildingId,IssueDescription,Status FROM Ticket where ClientName = @clientName";
        cmd.Parameters.AddWithValue("@clientName", clientName);
        using (con)
        {
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                ticket.Add(new Ticket(
                    (int)reader["TicketId"],
                    (DateTime)reader["CurrentDate"],
                    (int)reader["BuildingId"],
                    (string)reader["IssueDescription"],
                     (string)reader["Status"],
                    (string)reader["Email"]));
            }
        }
        return ticket;
    }
    public List<Ticket> SelectTicketByEmployeeName(string employeeName)
    {
        List<Ticket> ticket = new List<Ticket>();
        string conString = WebConfigurationManager.ConnectionStrings["EZTicket11"].ConnectionString;
        SqlConnection con = new SqlConnection(conString);
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandText = "SELECT TicketId,Email,CurrentDate,BuildingId,IssueDescription,Status FROM Ticket where EmployeeName = @employeeName";
        cmd.Parameters.AddWithValue("@employeeName", employeeName);
        using (con)
        {
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                ticket.Add(new Ticket(
                    (int)reader["TicketId"],
                    (DateTime)reader["CurrentDate"],
                    (int)reader["BuildingId"],
                    (string)reader["IssueDescription"],
                     (string)reader["Status"],
                    (string)reader["Email"]));
            }
        }
        return ticket;
    }
    public List<Ticket> SelectTicketById(int id)
    {
        List<Ticket> ticket = new List<Ticket>();
        string conString = WebConfigurationManager.ConnectionStrings["EZTicket11"].ConnectionString;
        SqlConnection con = new SqlConnection(conString);
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandText = "SELECT TicketId,Email,CurrentDate,BuildingId,IssueDescription,Status,EmployeeName FROM Ticket where TicketId = @id";
        cmd.Parameters.AddWithValue("@id", id);
        using (con)
        {
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                if (reader["EmployeeName"] == DBNull.Value)
                {
                    ticket.Add(new Ticket(
                    (int)reader["TicketId"],
                    (DateTime)reader["CurrentDate"],
                    (int)reader["BuildingId"],
                    (string)reader["IssueDescription"],
                     (string)reader["Status"],
                    (string)reader["Email"],
                    string.Empty));
                }
                else
                {
                    ticket.Add(new Ticket(
                        (int)reader["TicketId"],
                        (DateTime)reader["CurrentDate"],
                        (int)reader["BuildingId"],
                        (string)reader["IssueDescription"],
                         (string)reader["Status"],
                        (string)reader["Email"],
                        (string)reader["EmployeeName"]));
                }
            }
        }
        return ticket;
    }
    public void UpdateTicket(int id, string status, string employeeName)
    {
        string conString = WebConfigurationManager.ConnectionStrings["EZTicket11"].ConnectionString;
        SqlConnection con = new SqlConnection(conString);
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandText = "Update Ticket set Status = @status, EmployeeName=@EmployeeName where TicketId=@Id";
        cmd.Parameters.AddWithValue("Status", status);
        cmd.Parameters.AddWithValue("EmployeeName", employeeName);
        cmd.Parameters.AddWithValue("Id", id);
        con.Open();
        cmd.ExecuteNonQuery();
        con.Close();

    }
    public void UpdateStatusTicket(int id, string status)
    {
        string conString = WebConfigurationManager.ConnectionStrings["EZTicket11"].ConnectionString;
        SqlConnection con = new SqlConnection(conString);
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandText = "Update Ticket set Status = @status where TicketId=@Id";
        cmd.Parameters.AddWithValue("Status", status);
        cmd.Parameters.AddWithValue("Id", id);
        con.Open();
        cmd.ExecuteNonQuery();
        con.Close();

    }
    public void InsertEmployee(Employee employee)
    {
        string conString = WebConfigurationManager.ConnectionStrings["EZTicket11"].ConnectionString;
        SqlConnection con = new SqlConnection(conString);
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandText = "INSERT INTO Employee(FirstName, LastName, OfficeNumber, PhoneNumber, Email, EmployeeNumber) VALUES (@FirstName, @LastName, @OfficeNumber, @PhoneNumber, @Email, @EmployeeNumber)";//insert statment  

        cmd.Parameters.AddWithValue("FirstName", employee.FirstName);
        cmd.Parameters.AddWithValue("LastName", employee.LastName);
        cmd.Parameters.AddWithValue("OfficeNumber", employee.OfficeNumber);
        cmd.Parameters.AddWithValue("PhoneNumber", employee.PhoneNumber);
        cmd.Parameters.AddWithValue("Email", employee.Email);
        cmd.Parameters.AddWithValue("EmployeeNumber", employee.EmployeeNumber);
        con.Open();
        cmd.ExecuteNonQuery();
        con.Close();

    }
    public int InsertTicket(Ticket ticket)
    {
        int result = -1;
        string conString = WebConfigurationManager.ConnectionStrings["EZTicket11"].ConnectionString;
        SqlConnection con = new SqlConnection(conString);
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandText = "INSERT INTO Ticket(Email, CurrentDate, BuildingId, IssueDescription, Status, ClientName) output INSERTED.TicketId VALUES (@Email, @CurrentDate, @BuildingId, @IssueDescription, @Status,@ClientName)";//insert statment  

        cmd.Parameters.AddWithValue("Email", ticket.Email);
        cmd.Parameters.AddWithValue("CurrentDate", ticket.CurrentDate);
        cmd.Parameters.AddWithValue("BuildingId", ticket.BuildingId);
        cmd.Parameters.AddWithValue("IssueDescription", ticket.IssueDescription);
        cmd.Parameters.AddWithValue("Status", ticket.Status);
        cmd.Parameters.AddWithValue("ClientName", ticket.ClientName);
        try
        {
            con.Open();
            result = int.Parse(cmd.ExecuteScalar().ToString());
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        con.Close();
        return result;
    }

    //public void deleteCoor(int id)
    //{
    //    SqlConnection con = new SqlConnection(Connections.ConnectionString());
    //    SqlCommand cmd = new SqlCommand();
    //    cmd.Connection = con;

    //    cmd.CommandText = "Delete from Reports where id=@id";

    //    cmd.Parameters.AddWithValue("id", id);

    //    con.Open();
    //    cmd.ExecuteNonQuery();
    //    con.Close();

    //}

}