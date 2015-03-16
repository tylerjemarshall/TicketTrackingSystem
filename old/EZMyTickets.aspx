<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EZMyTickets.aspx.cs" Inherits="EZMyTickets" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
   <b>EZMyTickets</b>
        <div>
            <asp:Panel runat="server">
                <div>
                    Please enter your last name:
             <asp:TextBox ID="txtLastName" runat="server"></asp:TextBox>
                    <br />
                    <br />
             <div>
                 <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click" />
                 <asp:Button ID="btnBack" Visible="true" Text="Back Home Page" runat="server" OnClick="btnBack_Click" />
             </div>
                </div>
            </asp:Panel>
            <br />
            <asp:GridView ID="gvTicketList" OnRowDataBound="gvTicketList_RowDataBound" AutoGenerateColumns="false" runat="server">
                <Columns>
                    <asp:TemplateField>
                        <HeaderTemplate>
                            Ticket ID
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:HyperLink
                                ID="lnkTicket"
                                Text='<%#Eval("TicketId")%>'
                                NavigateUrl='<%#Eval("TicketId","ShowQueryStringParameterDetails.aspx?id={0}&type=1")%>'
                                runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField HeaderText="Building" DataField="BuildingId" />
                    <asp:BoundField HeaderText="Issue Description" DataField="IssueDescription" />
                    <asp:BoundField HeaderText="Status" DataField="Status" />
                </Columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>
