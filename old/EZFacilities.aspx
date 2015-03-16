<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EZFacilities.aspx.cs" Inherits="EZFacilities" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    

         <asp:UpdatePanel ID="UP1" runat="server">
            <ContentTemplate>
                <b>EZFacilities</b>
                <div>
                    <asp:ObjectDataSource ID="objectData" runat="server" SelectMethod="SelectBuilding" TypeName="TicketTrackingSystem.EmployeeUtilities"></asp:ObjectDataSource>
                    <asp:Panel ID="panel" runat="server">
                        <div>
                            Employee Number:
            <asp:TextBox ID="txtEmployeeNum" runat="server"></asp:TextBox>
                        </div>
                        <br />
                        <br></br>
                        <div>
                            <asp:Button ID="btnEnter" runat="server" OnClick="btnEnter_Click" Text="Validate Employee Number" />
                            <asp:Button ID="btnClear" runat="server" OnClick="btnClear_Click" Text="ClearAllFields" />
                            <asp:Button ID="btnMove" runat="server" OnClick="btnMove_Click" Text="Go to EZTicketManager System" />
                            <asp:Button ID="btnMove1" runat="server" OnClick="btnMove1_Click" Text="Go to EZMyTickets System" />
                        </div>
                        <br />
                        <br></br>
                        <div id="autopopup" runat="server" visible="false">
                            <b>Employee Infomation</b>
                            <table>
                                <tr>
                                    <td>First Name:</td>
                                    <td>
                                        <asp:TextBox ID="txtFirstName" runat="server"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>Last Name:</td>
                                    <td>
                                        <asp:TextBox ID="txtLastName" runat="server"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>Office Number:</td>
                                    <td>
                                        <asp:TextBox ID="txtOfficeNum" runat="server"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>Phone Number:</td>
                                    <td>
                                        <asp:TextBox ID="txtPhoneNum" runat="server"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>Email:</td>
                                    <td>
                                        <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
                                    </td>
                                </tr>
                            </table>
                            <b>Ticket Infomation</b>
                            <table>
                                <tr>
                                    <td>Current Date:</td>
                                    <td>
                                        <asp:TextBox ID="txtCurrentDate" runat="server" Enabled="false"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>Building with issue:</td>
                                    <td>
                                        <asp:DropDownList ID="ddlBuilding" runat="server" DataSourceID="objectData" DataTextField="BuildingName" DataValueField="BuildingId">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td>Issue Description:</td>
                                    <td>
                                        <asp:TextBox ID="txtIssue" runat="server"></asp:TextBox>
                                    </td>
                                </tr>
                            </table>
                            <asp:Label ID="lb1" runat="server" Text="Please submit the ticket"></asp:Label>
                            <br />
                            <br></br>
                            <asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" Text="Submit Ticket" />
                            <br />
                            <br></br>
                            <div id="Pin" runat="server" visible="false">
                                <table>
                                    <tr>
                                        <td>Pin Number:</td>
                                        <td>
                                            <asp:TextBox ID="txtPin" runat="server" Enabled="false"></asp:TextBox>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                            </br>
                            </br>
                        </div>
                        </br>
                        </br>
                    </asp:Panel>
                    <br />
                    <br></br>
                    <asp:Panel ID="panel1" runat="server">
                        <table>
                            <tr>
                                <td>PIN number: </td>
                                <td>
                                    <asp:TextBox ID="txtPinSearch" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <asp:Button ID="btnSearch" runat="server" OnClick="btnSearch_Click" Text="Search" />
                            </tr>
                        </table>
                        <asp:DetailsView ID="dtTicket" runat="server" OnDataBound="dtTicket_DataBound">
                        </asp:DetailsView>
                    </asp:Panel>
                    <br />
                    <br></br>
                    <asp:Panel ID="panel2" runat="server">
                        <table>
                            <tr>
                                <td>I forget the pin. Here is my email. </td>
                                <td>
                                    <asp:TextBox ID="txtEmail1" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <asp:Button ID="btnSearchByEmail" runat="server" OnClick="btnSearchByEmail_Click" Text="Search By Email" />
                            </tr>
                        </table>
                        <asp:GridView ID="gvTicketByEmail" runat="server" AutoGenerateColumns="false" OnRowDataBound="gvTicketByEmail_RowDataBound">
                            <Columns>
                                <asp:BoundField DataField="TicketId" HeaderText="Ticket Id" />
                                <asp:BoundField DataField="Email" HeaderText="Email" />
                                <asp:BoundField DataField="CurrentDate" HeaderText="Current Date" />
                                <asp:BoundField DataField="BuildingId" HeaderText="Building" />
                                <asp:BoundField DataField="IssueDescription" HeaderText="Issue Description" />
                                <asp:BoundField DataField="Status" HeaderText="Status" />
                            </Columns>
                        </asp:GridView>
                    </asp:Panel>
                    </br>
                    </br>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>


    </div>
    </form>
</body>
</html>
