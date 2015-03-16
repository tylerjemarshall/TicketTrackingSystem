using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class EZMyTickets : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        ServiceReference1.Service1Client client = new ServiceReference1.Service1Client();
        ServiceReference.ServiceReference1.Ticket[] tickets = client.GetTicket(txtLastName.Text);
        List<Ticket> listticket = new List<Ticket>();
        foreach (var item in tickets)
        {
            Ticket ticket = new Ticket();
            ticket.TicketId = item.TicketId;
            ticket.BuildingId = item.BuildingId;
            ticket.IssueDescription = item.IssueDescription;
            ticket.Status = item.Status;
            listticket.Add(ticket);
        }
        gvTicketList.DataSource = listticket;
        gvTicketList.DataBind();
    }

    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/EZFacilities.aspx");
    }

    protected void gvTicketList_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            switch (e.Row.Cells[1].Text)
            {
                case "1":
                    e.Row.Cells[1].Text = "Main office";
                    break;
                case "2":
                    e.Row.Cells[1].Text = "Warehouse A";
                    break;
                case "3":
                    e.Row.Cells[1].Text = "Warehouse B";
                    break;
                case "4":
                    e.Row.Cells[1].Text = "West Annex";
                    break;
                case "5":
                    e.Row.Cells[1].Text = "Downtown office";
                    break;
                case "6":
                    e.Row.Cells[1].Text = "Transport pool";
                    break;
            }
        }
    }

}