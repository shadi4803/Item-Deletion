<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="report.aspx.cs" Inherits="NCAAA.report" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server"></asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Panel id="Date" runat="server" Width="80%" GroupingText="Item Deletion Menu">
  <asp:Label ID="lblUserId" runat="server" Visible="true"></asp:Label>
        <asp:Label ID="lblUserType" runat="server" Visible="true"></asp:Label>
 
<br />
<br />
        <asp:Label ID="Requst_Number" runat="server" Text="Requst Number"></asp:Label> <asp:TextBox ID="requestnumber" runat="server" Text=""></asp:TextBox>
        <asp:Label ID="Invalid" runat="server" Text="The Request Number Is Invalid" Visible="False" ForeColor="Red" ></asp:Label>
<br />
        <asp:Label ID="AlreadySubmited" runat="server" Text="You are Already submit in this request" Visible="False" ForeColor="Red" ></asp:Label>
<br />
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Edit" Width="70px" />
<br />
<br />
 
</asp:Panel>
</asp:Content>
