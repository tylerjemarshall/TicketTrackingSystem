using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class EZTicketManager : System.Web.UI.Page
{

    EmployeeUtilities eu = new EmployeeUtilities();
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnSelect_Click(object sender, EventArgs e)
    {
        if (ddlFilter.SelectedIndex == 0)
        {
            status.Visible = true;
            lastname.Visible = false;
        }
        else
        {
            lastname.Visible = true;
            status.Visible = false;
            if (ddlFilter.SelectedIndex == 2)
            {
                lbLastName.Text = "Please enter last name of IT employee:";

            }
            else
            {
                lbLastName.Text = "Please enter last name of people who submitted this ticket:";

            }
        }
        btnSearch.Visible = true;
        btnSelect.Visible = false;
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        panel1.Visible = true;
        List<Ticket> ticket = new List<Ticket>();
        if (status.Visible)
        {
            ticket = eu.SelectTicketByStatus(ddlStatus.SelectedItem.Text);
        }
        else if (lbLastName.Text != "Please enter last name of IT employee:")
        {
            ticket = eu.SelectTicketByClientName(txtLastName.Text);
        }
        else
        {
            ticket = eu.SelectTicketByEmployeeName(txtLastName.Text);
        }
        gvTicket.DataSource = ticket;
        gvTicket.DataBind();
    }

    protected void ddlFilter_SelectedIndexChanged(object sender, EventArgs e)
    {
        btnSearch.Visible = false;
        btnSelect.Visible = true;
    }

    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/EZFacilities.aspx");
    }

    protected void gvTicket_RowDataBound(object sender, GridViewRowEventArgs e)
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
}