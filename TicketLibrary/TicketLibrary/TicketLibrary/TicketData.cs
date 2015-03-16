using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketLibrary
{
    public class TicketData
    {
        public List<Ticket> SelectAllTickets()
        {
            List<Ticket> Tickets = new List<Ticket>();

            string sql = "SELECT tic.TicketNumber, tic.EmployeeNumber, tic.DateSubmitted,tic.Building, tic.Description, tic.Status, tic.AssignedTo, em.FirstName, em.LastName From Tickets tic, Employees em Where tic.EmployeeNumber=em.EmployeeNumber";

            SqlConnection con = new SqlConnection(Connection.ConnectionString());
            SqlCommand cmd = new SqlCommand(sql, con);


            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {

                int assignTo = 0;
                if (!(reader["AssignedTo"] is DBNull))
                    assignTo = Convert.ToInt32(reader["AssignedTo"]);

                Employee e = new Employee(Convert.ToInt32(reader["EmployeeNumber"].ToString()),
                                        reader["FirstName"].ToString(),
                                        reader["LastName"].ToString());

                //Employee m = getEmployeeByAssigneToNum(Convert.ToInt32(reader["AssignedTo"].ToString()));
                Employee m = getEmployeeByAssigneToNum(assignTo);

                Ticket t = new Ticket(Convert.ToInt32(reader["TicketNumber"].ToString()),
                                                    Convert.ToDateTime(reader["DateSubmitted"]),
                                                    reader["Building"].ToString(),
                                                    reader["Description"].ToString(),
                                                    reader["Status"].ToString(),e, m);

                Tickets.Add(t);

            }
            con.Close();

            return Tickets;


        }

        public Employee SelectEmployeeByID(int empNum)
        {
            Employee m = null;

            string sql = "SELECT EmployeeNumber, FirstName, LastName, OfficeNumber, PhoneNumber, Email, JobDescription From Employees Where EmployeeNumber=@EmployeeNumber";

            SqlConnection con = new SqlConnection(Connection.ConnectionString());
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@EmployeeNumber", empNum);

            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {

                m = new Employee(Convert.ToInt32(reader["EmployeeNumber"]),
                    reader["FirstName"].ToString(),
                     reader["LastName"].ToString(),
                     Convert.ToInt32(reader["OfficeNumber"]),
                     reader["PhoneNumber"].ToString(),
                     reader["Email"].ToString(),
                     reader["JobDescription"].ToString());


            }
            con.Close();

            return m;
        }

        public Employee getEmployeeByAssigneToNum(int EmployeeNumber)
        {
            Employee m = null;

            string sql = "SELECT FirstName, LastName From Employees Where EmployeeNumber=@EmployeeNumber";

            SqlConnection con = new SqlConnection(Connection.ConnectionString());

            
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@EmployeeNumber", EmployeeNumber);

            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {

                m = new Employee(EmployeeNumber, reader["FirstName"].ToString(),
                     reader["LastName"].ToString());

            }
            con.Close();

            return m;
        }

        public Employee SelectAssignedToEmployeeNameByID(int empNum)
        {
            Employee m = null;

            string sql = @"SELECT ee.EmployeeNumber, ee.FirstName, ee.LastName 
                           From dbo.Employees ee, dbo.Tickets tt 
                           Where ee.EmployeeNumber=tt.AssignedTo";

            SqlConnection con = new SqlConnection(Connection.ConnectionString());
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@EmployeeNumber", empNum);

            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {

                m = new Employee(Convert.ToInt32(reader["EmployeeNumber"]),
                    reader["FirstName"].ToString(),
                     reader["LastName"].ToString());

            }
            con.Close();

            return m;
        }
 
        public int insertTicket(Ticket ticks)
        {
            int key=0;

            SqlConnection con = new SqlConnection(Connection.ConnectionString());
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "INSERT INTO Tickets(EmployeeNumber,DateSubmitted,Building,Description,Status,AssignedTo) VALUES (@EmployeeNumber,@DateSubmitted,@Building,@Description,@Status,@AssignedTo);SELECT SCOPE_IDENTITY();";//insert statment  

            cmd.Parameters.AddWithValue("EmployeeNumber", ticks.EmployeeNumber);
            cmd.Parameters.AddWithValue("DateSubmitted", ticks.DateSubmitted);
            cmd.Parameters.AddWithValue("Building", ticks.Building);
            cmd.Parameters.AddWithValue("Description", ticks.Description);
            cmd.Parameters.AddWithValue("Status", ticks.Status);
            cmd.Parameters.AddWithValue("AssignedTo", ticks.AssignedTo);
            

            con.Open();
            key = Convert.ToInt32(cmd.ExecuteScalar());
            con.Close();

            return key;

        }

        public int insertEmployee(Employee emp)
        {
            int key = 0;

            SqlConnection con = new SqlConnection(Connection.ConnectionString());
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "SET Identity_insert Employees ON INSERT INTO Employees(EmployeeNumber,LastName,FirstName,OfficeNumber,PhoneNumber,EMail,JobDescription) VALUES (@EmployeeNumber,@LastName,@FirstName,@OfficeNumber,@PhoneNumber,@EMail,@JobDescription);SELECT SCOPE_IDENTITY();";//insert statment  

            cmd.Parameters.AddWithValue("EmployeeNumber", emp.EmployeeNumber);
            cmd.Parameters.AddWithValue("LastName", emp.LastName);
            cmd.Parameters.AddWithValue("FirstName", emp.FirstName);
            cmd.Parameters.AddWithValue("OfficeNumber", emp.OfficeNumber);
            cmd.Parameters.AddWithValue("PhoneNumber", emp.PhoneNumber);
            cmd.Parameters.AddWithValue("EMail", emp.EMail);
            cmd.Parameters.AddWithValue("JobDescription", emp.JobDescription);


            con.Open();
            key=Convert.ToInt32(cmd.ExecuteScalar());
            SqlDataReader reader = cmd.ExecuteReader();
            con.Close();

            return key;

        }


        public Ticket SelectTicketByPin(int pN)
        {
            Ticket m = null;

            string sql = @"SELECT TicketNumber, EmployeeNumber, DateSubmitted, 
                                Building, Description, Status, AssignedTo 
                                From Tickets Where TicketNumber=@TicketNumber";

            SqlConnection con = new SqlConnection(Connection.ConnectionString());
            SqlCommand cmd = new SqlCommand(sql, con);

            cmd.Parameters.AddWithValue("@TicketNumber", pN);

            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {

                int assignTo = 0;
                if (!(reader["AssignedTo"] is DBNull))
                    assignTo = Convert.ToInt32(reader["AssignedTo"]);

                m = new Ticket(Convert.ToInt32(reader["TicketNumber"]),
                    Convert.ToInt32(reader["EmployeeNumber"]),
                    Convert.ToDateTime(reader["DateSubmitted"]),
                    reader["Building"].ToString(),
                    reader["Description"].ToString(),
                    reader["Status"].ToString());

                    Convert.ToInt32(reader["AssignedTo"]);

            }
            con.Close();

            return m;
        }



        public List<Ticket> SelectAllPinByEmail(string email)
        {
            List<Ticket> ticket = new List<Ticket>();

            string sql = "SELECT tic.TicketNumber From Tickets tic, Employees em Where tic.EmployeeNumber=em.EmployeeNumber AND em.Email=@Email ";

            SqlConnection con = new SqlConnection(Connection.ConnectionString());
            SqlCommand cmd = new SqlCommand(sql, con);
        
            cmd.Parameters.AddWithValue("@Email", email);

            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Ticket t = new Ticket(Convert.ToInt32(reader["TicketNumber"])
                  );

                ticket.Add(t);

            }
            con.Close();

            return ticket;

        }

        public List<Ticket> SelectAllSubmittedTickets()
        {
            List<Ticket> ti = new List<Ticket>();

            SqlConnection con = new SqlConnection(Connection.ConnectionString());

            String sql = "Select TicketNumber,EmployeeNumber,DateSubmitted,Building,Description,Status,AssignedTo from Tickets";

            SqlCommand cmd = new SqlCommand(sql, con);

            con.Open();

            //if asked to return a list....
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Ticket tick = new Ticket(Convert.ToInt32(reader["TicketNumber"]),
                                         Convert.ToInt32(reader["EmployeeNumber"]),
                                         Convert.ToDateTime(reader["DateSubmitted"]),
                                         reader["Building"].ToString(),
                                         reader["Description"].ToString(),
                                         reader["Status"].ToString(),
                                         Convert.ToInt32(reader["AssignedTo"]));


                ti.Add(tick);

            }
            con.Close();
            return ti;

        }

        //Trying to get submittedTo names and assignedTo names
//        public List<Ticket> SelectAllSubmittedTickets()
//        {
//            List<Ticket> Tickets = new List<Ticket>();

//            string sql = @"SELECT tic.TicketNumber, tic.EmployeeNumber, tic.Building, tic.Description, tic.AssignedTo, 
//                                    em.FirstName, em.LastName 
//                          From Tickets tic
//                          left outer join Employees em on
//                          tic.EmployeeNumber=em.EmployeeNumber
//                          
//                          Where tic.EmployeeNumber=em.EmployeeNumber ";
//            //String sql = "Select TicketNumber,EmployeeNumber,DateSubmitted,Building,Description,Status,AssignedTo from Tickets where Status=@Status";

//            SqlConnection con = new SqlConnection(Connection.ConnectionString());
//            SqlCommand cmd = new SqlCommand(sql, con);


//            con.Open();
//            SqlDataReader reader = cmd.ExecuteReader();
//            while (reader.Read())
//            {
//                Employee e = new Employee(Convert.ToInt32(reader["EmployeeNumber"].ToString()),
//                                        reader["FirstName"].ToString(),
//                                        reader["LastName"].ToString());

//                Employee m = SelectAssignedToEmployeeNameByID(Convert.ToInt32(reader["AssignedTo"].ToString()));

//                //Ticket t = new Ticket(Convert.ToInt32(reader["TicketNumber"].ToString()),
//                //                                    reader["Building"].ToString(),
//                //                                    reader["Description"].ToString(), e, m);

//                Ticket t = new Ticket(Convert.ToInt32(reader["TicketNumber"]),
//                                         Convert.ToInt32(reader["EmployeeNumber"]),
//                                         Convert.ToDateTime(reader["DateSubmitted"]),
//                                         reader["Building"].ToString(),
//                                         reader["Description"].ToString(),
//                                         reader["Status"].ToString(),
//                                         Convert.ToInt32(reader["AssignedTo"]),e,m);

//                Tickets.Add(t);

//            }
//            con.Close();

//            return Tickets;

//        }




        public List<Ticket> SelectTicketFilterByStatus(String status)
        {
            List<Ticket> ti = new List<Ticket>();

            SqlConnection con = new SqlConnection(Connection.ConnectionString());

           
            String sql = "Select TicketNumber,EmployeeNumber,DateSubmitted,Building,Description,Status,AssignedTo from Tickets where Status=@Status";

            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@Status", status);
            con.Open();

            //if asked to return a list....
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Ticket tick = new Ticket(Convert.ToInt32(reader["TicketNumber"]),
                                         Convert.ToInt32(reader["EmployeeNumber"]),
                                         Convert.ToDateTime(reader["DateSubmitted"]),
                                         reader["Building"].ToString(),
                                         reader["Description"].ToString(),
                                         reader["Status"].ToString(),
                                         Convert.ToInt32(reader["AssignedTo"]));


                ti.Add(tick);

            }
            con.Close();
            return ti;

        }

        public List<Ticket> SelectAllTicketByLastName()
        {
            List<Ticket> Tickets = new List<Ticket>();

            string sql = "SELECT tic.TicketNumber, tic.EmployeeNumber, tic.Building, tic.Description, tic.AssignedTo, em.FirstName, em.LastName From Tickets tic, Employees em Where tic.EmployeeNumber=em.EmployeeNumber";

            SqlConnection con = new SqlConnection(Connection.ConnectionString());
            SqlCommand cmd = new SqlCommand(sql, con);


            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Employee e = new Employee(Convert.ToInt32(reader["EmployeeNumber"].ToString()),
                                        reader["FirstName"].ToString(),
                                        reader["LastName"].ToString());

                Employee m = SelectEmployeeByID(Convert.ToInt32(reader["AssignedTo"].ToString()));

                Ticket t = new Ticket(Convert.ToInt32(reader["TicketNumber"].ToString()),
                                                    reader["Building"].ToString(),
                                                    reader["Description"].ToString(), e, m);

                Tickets.Add(t);

            }
            con.Close();

            return Tickets;


        }

        public List<Ticket> SelectAllStatus()
        {
            List<Ticket> Tickets = new List<Ticket>();

            string sql = "SELECT distinct Status From Tickets";

            SqlConnection con = new SqlConnection(Connection.ConnectionString());
            SqlCommand cmd = new SqlCommand(sql, con);
            
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {

                Ticket ti = new Ticket(reader["Status"].ToString());

                Tickets.Add(ti);
            }
            con.Close();

            return Tickets;
        }

        public List<Employee> SelectAllLastName()
        {
            List<Employee> Employeess = new List<Employee>();

            string sql = "SELECT LastName, EmployeeNumber From Employees";

            SqlConnection con = new SqlConnection(Connection.ConnectionString());
            SqlCommand cmd = new SqlCommand(sql, con);

            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {

                Employee em = new Employee(reader["LastName"].ToString(),
                                           Convert.ToInt32(reader["EmployeeNumber"]));

                Employeess.Add(em);
            }
            con.Close();

            return Employeess;
        }


        public List<Employee> SelectAssignedAllLastName()
        {
            List<Employee> Employeess = new List<Employee>();

            string sql = "SELECT LastName, EmployeeNumber From Employees Where JobDescription= 'Maintenance' ";

            SqlConnection con = new SqlConnection(Connection.ConnectionString());
            SqlCommand cmd = new SqlCommand(sql, con);

            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {

                Employee em = new Employee(reader["LastName"].ToString(),  Convert.ToInt32(reader["EmployeeNumber"]));

                Employeess.Add(em);            
            }
            con.Close();

            return Employeess;
        }


        public List<Ticket> SelectFilterByStatus(string status)
        {
            List<Ticket> Tickets = new List<Ticket>();

            string sql = "SELECT * From Tickets where Status=@Status";

            SqlConnection con = new SqlConnection(Connection.ConnectionString());
            SqlCommand cmd = new SqlCommand(sql, con);

            cmd.Parameters.AddWithValue("@Status", status);

            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {

                Ticket ti = new Ticket(Convert.ToInt32(reader["TicketNumber"]),
                                         Convert.ToInt32(reader["EmployeeNumber"]),
                                         Convert.ToDateTime(reader["DateSubmitted"]),
                                         reader["Building"].ToString(),
                                         reader["Description"].ToString(),
                                         reader["Status"].ToString(),
                                         Convert.ToInt32(reader["AssignedTo"]));

                Tickets.Add(ti);
            }
            con.Close();

            return Tickets;
        }

        public List<Ticket> SelectFilterByStatus(string status)
        {
            List<Ticket> Tickets = new List<Ticket>();

            string sql = "SELECT tic.TicketNumber, tic.EmployeeNumber, tic.DateSubmitted,tic.Building, tic.Description, tic.Status, tic.AssignedTo, em.FirstName, em.LastName From Tickets tic, Employees em Where tic.EmployeeNumber=em.EmployeeNumber and tic.Status=@Status";

            SqlConnection con = new SqlConnection(Connection.ConnectionString());
            SqlCommand cmd = new SqlCommand(sql, con);

            cmd.Parameters.AddWithValue("@Status", status);

            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Employee e = new Employee(Convert.ToInt32(reader["EmployeeNumber"].ToString()),
                                        reader["FirstName"].ToString(),
                                        reader["LastName"].ToString());

                Employee m = getEmployeeByAssigneToNum(Convert.ToInt32(reader["AssignedTo"].ToString()));

                Ticket t = new Ticket(Convert.ToInt32(reader["TicketNumber"].ToString()),
                                                    Convert.ToDateTime(reader["DateSubmitted"]),
                                                    reader["Building"].ToString(),
                                                    reader["Description"].ToString(),
                                                    reader["Status"].ToString(), e, m);

                Tickets.Add(t);

            }
            con.Close();

            return Tickets;


        }


        public List<Ticket> SelectFilterByEmpNum(int empNum)
        {
            List<Ticket> Tickets = new List<Ticket>();

            string sql = "SELECT t.TicketNumber,t.EmployeeNumber,t.DateSubmitted,t.Building,t.Description,t.Status,t.AssignedTo, e.LastName From Tickets t, Employees e where t.EmployeeNumber = e.EmployeeNumber and e.EmployeeNumber=@employeeNumber";

            SqlConnection con = new SqlConnection(Connection.ConnectionString());
            SqlCommand cmd = new SqlCommand(sql, con);
         
                cmd.Parameters.AddWithValue("@employeeNumber", empNum);

            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                       Ticket ti = new Ticket(Convert.ToInt32(reader["TicketNumber"]),
                                         Convert.ToInt32(reader["EmployeeNumber"]),
                                         Convert.ToDateTime(reader["DateSubmitted"]),
                                         reader["Building"].ToString(),
                                         reader["Description"].ToString(),
                                         reader["Status"].ToString(),
                                         Convert.ToInt32(reader["AssignedTo"]));

                Tickets.Add(ti);
            }
            con.Close();

            return Tickets;
        }

        public List<Ticket> SelectFilterByLastName(int empNum)
        {
            List<Ticket> Tickets = new List<Ticket>();

            string sql = @"SELECT tic.TicketNumber, tic.EmployeeNumber, 
                            tic.DateSubmitted,tic.Building, tic.Description, 
                            tic.Status, tic.AssignedTo, em.FirstName, em.LastName 
                           From Tickets tic, Employees em Where tic.EmployeeNumber=em.EmployeeNumber and em.EmployeeNumber=@employeeNumber";

            SqlConnection con = new SqlConnection(Connection.ConnectionString());
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@employeeNumber", empNum);

            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Employee e = new Employee(Convert.ToInt32(reader["EmployeeNumber"].ToString()),
                                        reader["FirstName"].ToString(),
                                        reader["LastName"].ToString());

                Employee m = getEmployeeByAssigneToNum(Convert.ToInt32(reader["AssignedTo"].ToString()));

                Ticket t = new Ticket(Convert.ToInt32(reader["TicketNumber"].ToString()),
                                                    Convert.ToDateTime(reader["DateSubmitted"]),
                                                    reader["Building"].ToString(),
                                                    reader["Description"].ToString(),
                                                    reader["Status"].ToString(), e, m);

                Tickets.Add(t);

            }
            con.Close();

            return Tickets;


        }


//        public List<Ticket> SelectFilterByAssignedLastName(int empNum)
//        {
//            List<Ticket> Tickets = new List<Ticket>();

//            string sql = @"SELECT t.TicketNumber,t.EmployeeNumber,t.DateSubmitted,t.Building,t.Description,
//                        t.Status,t.AssignedTo, e.LastName From Tickets t, 
//                        Employees e where t.EmployeeNumber = e.EmployeeNumber and t.AssignedTo=@employeeNumber";

//            SqlConnection con = new SqlConnection(Connection.ConnectionString());
//            SqlCommand cmd = new SqlCommand(sql, con);

//            cmd.Parameters.AddWithValue("@employeeNumber", empNum);
           

//            con.Open();
//            SqlDataReader reader = cmd.ExecuteReader();
//            while (reader.Read())
//            {

//                Ticket ti = new Ticket(Convert.ToInt32(reader["TicketNumber"]),
//                                         Convert.ToInt32(reader["EmployeeNumber"]),
//                                         Convert.ToDateTime(reader["DateSubmitted"]),
//                                         reader["Building"].ToString(),
//                                         reader["Description"].ToString(),
//                                         reader["Status"].ToString(),
//                                         Convert.ToInt32(reader["AssignedTo"]));

//                Tickets.Add(ti);
//            }
//            con.Close();

//            return Tickets;
//        }

        public List<Ticket> SelectFilterByAssignedLastName(int empNum)
        {
            List<Ticket> Tickets = new List<Ticket>();

            string sql = @"SELECT tic.TicketNumber, tic.EmployeeNumber, tic.DateSubmitted,tic.Building, 
                           tic.Description, tic.Status, tic.AssignedTo, em.FirstName, em.LastName 
                           From Tickets tic, Employees em Where tic.EmployeeNumber=em.EmployeeNumber and tic.AssignedTo=@employeeNumber";

            SqlConnection con = new SqlConnection(Connection.ConnectionString());
            SqlCommand cmd = new SqlCommand(sql, con);

            cmd.Parameters.AddWithValue("@employeeNumber", empNum);

            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Employee e = new Employee(Convert.ToInt32(reader["EmployeeNumber"].ToString()),
                                        reader["FirstName"].ToString(),
                                        reader["LastName"].ToString());

                Employee m = getEmployeeByAssigneToNum(Convert.ToInt32(reader["AssignedTo"].ToString()));

                Ticket t = new Ticket(Convert.ToInt32(reader["TicketNumber"].ToString()),
                                                    Convert.ToDateTime(reader["DateSubmitted"]),
                                                    reader["Building"].ToString(),
                                                    reader["Description"].ToString(),
                                                    reader["Status"].ToString(), e, m);

                Tickets.Add(t);

            }
            con.Close();

            return Tickets;


        }

        public void UpdateAssigned(int assigNum, int tickNum, string status)
        {
            SqlConnection con = new SqlConnection(Connection.ConnectionString());
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "UPDATE Tickets SET AssignedTo=@AssignedTo, Status=@Status where TicketNumber=@ticketNumber";

            cmd.Parameters.AddWithValue("@AssignedTo", assigNum);
            cmd.Parameters.AddWithValue("@TicketNumber", tickNum);
            cmd.Parameters.AddWithValue("@Status", status);
           

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void UpdateStatus(int assigNum, int tickNum, string status)
        {
            SqlConnection con = new SqlConnection(Connection.ConnectionString());
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "UPDATE Tickets SET Status=@Status, AssignedTo=@AssignedTo where TicketNumber=@TicketNumber";

            cmd.Parameters.AddWithValue("@Status", status);
            cmd.Parameters.AddWithValue("@TicketNumber", tickNum);
            cmd.Parameters.AddWithValue("@AssignedTo", assigNum);

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }


        internal List<Ticket> SelectFilterByStatus()
        {
            throw new NotImplementedException();
        }
    }
}
