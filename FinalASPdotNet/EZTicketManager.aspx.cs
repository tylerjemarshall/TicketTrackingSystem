using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TicketLibrary;

public partial class EZTicketManager : System.Web.UI.Page
{

    //Page_PreRender
    protected void Page_PreRender(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            TicketUtilities tu = new TicketUtilities();

            DropDownList1.DataSource = tu.GetAllStatus();
            DropDownList1.DataBind();
            DropDownList1.Items.Insert(0, "-Filter by Status-");

            DropDownList2.DataTextField = "LastName";
            DropDownList2.DataValueField = "EmployeeNumber";
            DropDownList2.DataSource = tu.GetAllLastName();
            DropDownList2.DataBind();
            DropDownList2.Items.Insert(0, new ListItem("-Filter Submitted by Last Name-","-1"));

            DropDownList3.DataTextField = "LastName";
            DropDownList3.DataValueField = "EmployeeNumber";
            DropDownList3.DataSource = tu.GetAllAssignedLastName();
            DropDownList3.DataBind();
            DropDownList3.Items.Insert(0, new ListItem("-Filter AssignedTo by Last Name-", "-1"));

            //DropDownList ddl1 = ((DropDownList)GridView1.Rows[e.].FindControl("DropDownList4"));

        }
    }
    

    protected void btuViewAll_Click(object sender, EventArgs e)
    {
        
        TicketUtilities tu = new TicketUtilities();
        List<Ticket> ticks =TicketUtilities.GetAllTickets();
        GridView1.DataSource = ticks;
        GridView1.DataBind();



    }

    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
       
        TicketUtilities tu = new TicketUtilities();
        List<Ticket> ti = tu.GetFilterByStatus(DropDownList1.Text);
        GridView1.DataSource = ti;
        GridView1.DataBind();

    }
    protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
    {
        TicketUtilities tu = new TicketUtilities();
        List<Ticket> ti = tu.GetFilterByLastName(Convert.ToInt32(DropDownList2.SelectedValue));
        GridView1.DataSource = ti;
        GridView1.DataBind();
    }

    protected void DropDownList3_SelectedIndexChanged(object sender, EventArgs e)
    {
        TicketUtilities tu = new TicketUtilities();
        List<Ticket> ti = tu.GetFilterByAssignedLN(Convert.ToInt32(DropDownList3.SelectedValue));
        GridView1.DataSource = ti;
        GridView1.DataBind();

    }
  
    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {
        GridView1.EditIndex = e.NewEditIndex;
        TicketUtilities tu = new TicketUtilities();

        DropDownList ddl1 = ((DropDownList)GridView1.Rows[e.NewEditIndex].FindControl("DropDownList4"));
        ddl1.Items.Add("Unassigned");
        ddl1.Items.Add("Assigned");
        ddl1.Items.Add("Completed");
        ddl1.Items.Add("Submitted");
        ddl1.Items.Add("Canceled");
        

        DropDownList ddl = ((DropDownList)GridView1.Rows[e.NewEditIndex].FindControl("DropDownList5"));
        ddl.DataTextField = "LastName";
        ddl.DataValueField = "EmployeeNumber";
        ddl.DataSource = tu.GetAllAssignedLastName();
        ddl.DataBind();

    }
    protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        GridView1.EditIndex = -1;
    }
    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        int assignedToNum=0;
        if(e.NewValues["AssignedToEm.EmployeeNumber"]!=null)
            assignedToNum = Convert.ToInt32(e.NewValues["AssignedToEm.EmployeeNumber"].ToString());
        
        int tickNum = Convert.ToInt32(e.Keys["TicketNumber"].ToString());

        if (assignedToNum != 0)
        {
            TicketUtilities atn = new TicketUtilities();
            atn.UpdateAssign(assignedToNum, tickNum, "Assigned");
        }
        else
        {
            string stat = (e.NewValues["Status"].ToString());

            if (stat == "Cancelled" || stat == "Completed" || stat == "Submitted")
            {
                TicketUtilities tu = new TicketUtilities();
                tu.UpdateStat(Convert.ToInt32(DropDownList1.SelectedValue), tickNum, stat);
            }
        }

        GridView1.EditIndex = -1;
        GridView1.DataBind();
    }



    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}