<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EZTicketManager.aspx.cs" Inherits="EZTicketManager" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
      <b>EZTicketManager</b>
        <div>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <asp:Panel ID="panel" runat="server">
                        <div>
                            Filter By:
            <asp:DropDownList ID="ddlFilter" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlFilter_SelectedIndexChanged">
                <asp:ListItem>Status</asp:ListItem>
                <asp:ListItem>Last Name of Client</asp:ListItem>
                <asp:ListItem>Last Name of IT engineer</asp:ListItem>
            </asp:DropDownList>
                        </div>
                        </br>
        <div id="status" runat="server" visible="false">
            Status:
             <asp:DropDownList ID="ddlStatus" runat="server">
                 <asp:ListItem>Submitted</asp:ListItem>
                 <asp:ListItem>Cancelled</asp:ListItem>
                 <asp:ListItem>Assigned</asp:ListItem>
                 <asp:ListItem>Completed</asp:ListItem>
             </asp:DropDownList>
        </div>
                        <div id="lastname" runat="server" visible="false">
                            <asp:Label ID="lbLastName" runat="server" Text="Please enter last name of people who submitted this ticket:"></asp:Label>
                            <asp:TextBox ID="txtLastName" runat="server"></asp:TextBox>
                        </div>
                        </br>
                        <asp:Button ID="btnSelect" Text="Select" runat="server" OnClick="btnSelect_Click" />
                        <asp:Button ID="btnSearch" Visible="false" Text="Search" runat="server" OnClick="btnSearch_Click" />
                        <asp:Button ID="btnBack" Visible="true" Text="Back Home Page" runat="server" OnClick="btnBack_Click" />
                    </asp:Panel>
                    </br>
    <asp:Panel ID="panel1" Visible="false" runat="server">
        <asp:GridView ID="gvTicket" OnRowDataBound="gvTicket_RowDataBound" AutoGenerateColumns="false" runat="server">
            <Columns>
                <asp:TemplateField>
                    <HeaderTemplate>
                        Ticket ID
                    </HeaderTemplate>
                     <ItemTemplate>
                    <asp:HyperLink
                        ID="lnkTicket"
                        Text='<%#Eval("TicketId")%>'
                        NavigateUrl='<%#Eval("TicketId","ShowQueryStringParameterDetails.aspx?id={0}")%>'
                        runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>  
                <asp:BoundField HeaderText="Email" DataField="Email" />
                <asp:BoundField HeaderText="Current Date" DataField="CurrentDate" />
                <asp:BoundField HeaderText="Building" DataField="BuildingId" />
                <asp:BoundField HeaderText="Issue Description" DataField="IssueDescription" />
                <asp:BoundField HeaderText="Status" DataField="Status" />
            </Columns>
        </asp:GridView>
    </asp:Panel>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </form>
</body>
</html>
