<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StudentEntryUI.aspx.cs" Inherits="UniversityApp.StudentEntryUI" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table>
                <tr>
                    <td colspan="2">
                        <h2>Student Entry</h2>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label1" runat="server" Text="Reg. No."></asp:Label></td>
                    <td>
                        <asp:TextBox ID="regNoTextBox" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label2" runat="server" Text="Name"></asp:Label></td>
                    <td>
                        <asp:TextBox ID="nameTextBox" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label3" runat="server" Text="Email"></asp:Label></td>
                    <td>
                        <asp:TextBox ID="emailTextBox" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label4" runat="server" Text="Department"></asp:Label></td>
                    <td>
                        <asp:DropDownList runat="server" ID="departmentDropDown" />
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td>
                        <asp:Button ID="saveButton" runat="server" Text="Save" OnClick="saveButton_Click" />
                        <asp:Button ID="showButton" runat="server" Text="Show" OnClick="showButton_Click" />
                        <asp:Button ID="deleteButton" runat="server" Text="Delete" OnClick="deleteButton_Click"/>


                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:Label ID="messageLabel" runat="server"></asp:Label></td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:GridView ID="studentGridView" runat="server" AutoGenerateColumns="False">
                            <Columns>
                                <asp:TemplateField HeaderText="Name">
                                    <ItemTemplate>
                                        <%#Eval("Name") %>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                 <asp:TemplateField HeaderText="Reg No">
                                    <ItemTemplate>
                                        <%#Eval("RegNo") %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                
                                <asp:TemplateField HeaderText="Email">
                                    <ItemTemplate>
                                        <%#Eval("Email") %>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Department">
                                    <ItemTemplate>
                                        <%#Eval("Department") %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                
                                <asp:TemplateField HeaderText="">
                                    <ItemTemplate>
                                        <asp:HyperLink runat="server" NavigateUrl='<%# String.Concat("~/UI/StudentEntryUI.aspx?id=", Eval("Id") ) %>' Text="Edit"></asp:HyperLink>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
