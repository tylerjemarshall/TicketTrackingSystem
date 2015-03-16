using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class EZFacilities : System.Web.UI.Page
{
    int employeeNumber;
        EmployeeUtilities eu = new EmployeeUtilities();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnEnter_Click(object sender, EventArgs e)
        {
            if (txtEmployeeNum.Text != string.Empty && int.TryParse(txtEmployeeNum.Text, out employeeNumber) == true)
            {
                autopopup.Visible = true;
                txtCurrentDate.Text = DateTime.Now.ToLongDateString();
            }
            else
                autopopup.Visible = false;
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (txtIssue.Text != string.Empty && txtEmail.Text != string.Empty)
            {
                Employee employee = new Employee();
                employee.FirstName = txtFirstName.Text;
                employee.LastName = txtLastName.Text;
                employee.OfficeNumber = txtOfficeNum.Text;
                employee.PhoneNumber = txtPhoneNum.Text;
                employee.Email = txtEmail.Text;
                employee.EmployeeNumber = int.Parse(txtEmployeeNum.Text);
                eu.InsertEmployee(employee);
                Ticket ticket = new Ticket();
                ticket.Email = txtEmail.Text;
                ticket.CurrentDate = Convert.ToDateTime(txtCurrentDate.Text);
                ticket.BuildingId = int.Parse(ddlBuilding.SelectedItem.Value);
                ticket.IssueDescription = txtIssue.Text;
                ticket.Status = CommonCode.Status.Submitted.ToString();
                ticket.ClientName = txtLastName.Text;
                int ticketId = eu.InsertTicket(ticket);
                txtPin.Text = ticketId.ToString();
                lb1.Text = "Ticket is summited sucessfully. This is the new PIN";
                Pin.Visible = true;
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            int pin  = 0;
            if (int.TryParse(txtPinSearch.Text,out pin) == true)
            {
                List<Ticket> ticket = new List<Ticket>();
                ticket = eu.SelectTicketByPin(pin);
                dtTicket.DataSource = ticket;
                dtTicket.DataBind();
            }
        }

        protected void btnSearchByEmail_Click(object sender, EventArgs e)
        {
            if (txtEmail1.Text != string.Empty)
            {
                List<Ticket> ticket = new List<Ticket>();
                ticket = eu.SelectTicketByEmail(txtEmail1.Text);
                gvTicketByEmail.DataSource = ticket;
                gvTicketByEmail.DataBind();
            }
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            txtEmail.Text = txtEmail1.Text = txtEmployeeNum.Text = txtFirstName.Text = txtIssue.Text = txtLastName.Text =
                txtOfficeNum.Text = txtPhoneNum.Text = txtPin.Text = txtPinSearch.Text = string.Empty;
            autopopup.Visible = false;
        }

        protected void btnMove_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/EZTicketManager.aspx");
        }

        protected void btnMove1_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/EZMyTickets.aspx");
        }

        protected void gvTicketByEmail_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                switch (e.Row.Cells[3].Text)
                {
                    case "1":
                        e.Row.Cells[3].Text = "Main office";
                        break;
                    case "2":
                        e.Row.Cells[3].Text = "Warehouse A";
                        break;
                    case "3":
                        e.Row.Cells[3].Text = "Warehouse B";
                        break;
                    case "4":
                        e.Row.Cells[3].Text = "West Annex";
                        break;
                    case "5":
                        e.Row.Cells[3].Text = "Downtown office";
                        break;
                    case "6":
                        e.Row.Cells[3].Text = "Transport pool";
                        break;
                }
            }
        }

        protected void dtTicket_DataBound(object sender, EventArgs e)
        {
            switch (dtTicket.Rows[2].Cells[1].Text)
                {
                    case "1":
                        dtTicket.Rows[2].Cells[1].Text = "Main office";
                        break;
                    case "2":
                        dtTicket.Rows[2].Cells[1].Text = "Warehouse A";
                        break;
                    case "3":
                        dtTicket.Rows[2].Cells[1].Text = "Warehouse B";
                        break;
                    case "4":
                        dtTicket.Rows[2].Cells[1].Text = "West Annex";
                        break;
                    case "5":
                        dtTicket.Rows[2].Cells[1].Text = "Downtown office";
                        break;
                    case "6":
                        dtTicket.Rows[2].Cells[1].Text = "Transport pool";
                        break;
                }
        }
    }
