<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Item_Deletion_Admin_Menu.aspx.cs" Inherits="NCAAA.WebForm102" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:Panel id="pnlMain" runat="server" Width="80%" GroupingText="Item Deletion Admin Menu">
<asp:GridView ID="gridview1" runat="server" AutoGenerateColumns="false" OnRowCommand="gridview1_RowCommand">
        <Columns>

            <asp:TemplateField Visible="false" HeaderText="Edit">
                <ItemTemplate>
                    <asp:Label ID="lblId" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "id") %>'
                                        Visible="false"></asp:Label>
                </ItemTemplate>
           </asp:TemplateField>

            <asp:BoundField DataField="id" HeaderText="Request_ID" />
            <asp:BoundField DataField="course_name" HeaderText="Course_name" />
            <asp:BoundField DataField="course_code" HeaderText="Course_code" />
            <asp:BoundField DataField="question" HeaderText="Question" />
            <asp:BoundField DataField="reason" HeaderText="Reason" />
            <asp:BoundField DataField="other_reason" HeaderText="Other_Reason" />
            <asp:BoundField DataField="RM" HeaderText="RiyadhM" />
            <asp:BoundField DataField="JM" HeaderText="JeddahM" />
            <asp:BoundField DataField="AM" HeaderText="Al AhsaM" />
            <asp:BoundField DataField="RF" HeaderText="RiyadhF" />
            <asp:BoundField DataField="AF" HeaderText="JeddahF" />
            <asp:BoundField DataField="JF" HeaderText="Al AhsaF" />

            <asp:TemplateField Visible="true" HeaderText="Edit">
                <ItemTemplate>
                    <asp:LinkButton ID="lblEdit" runat="server" CommandName="Modify" Text="Edit"></asp:LinkButton>
                </ItemTemplate>
           </asp:TemplateField>


        </Columns>
    </asp:GridView>
<%--  <asp:GridView ID="gridview2" runat="server" AutoGenerateColumns="false">
        <Columns>
            <asp:BoundField DataField="id" HeaderText="User ID" />
            <asp:BoundField DataField="User_Name" HeaderText="User_Name" />
            <asp:BoundField DataField="User_Email" HeaderText="User_Email" />
            <asp:BoundField DataField="UserType" HeaderText="UserType" />
            <asp:BoundField DataField="UserRole" HeaderText="UserRole" />
            <asp:BoundField DataField="Is_active" HeaderText="Activity" />
            <asp:BoundField DataField="Created_date" HeaderText="Created_date" />
            <asp:BoundField DataField="UserFlag" HeaderText="UserFlag" />

        </Columns>
    </asp:GridView>--%>
<br />
             
                <asp:Button ID="btnSave" runat="server" Text="Requests Search" OnClick="btnSearch_Clicked" Height="28px" Width="185px" style="margin-left: 384px" />

<%--                <asp:Button ID="btnsearch" runat="server" Text="Update Users" OnClick="btnSearch_Clicked1" Height="28px" Width="185px" style="margin-left: 384px" />--%>
    <br />
                <asp:Button ID="btnreset" runat="server" Text="Reset" Visible="false" OnClick="btnreset_Clicked" Height="28px" Width="185px" style="margin-left: 384px" />
<br />
                <asp:Button ID="btnCreateUsers" runat="server" Text="Create Users" OnClick="btnCreateUsers_Click" Height="28px" Width="185px" style="margin-left: 384px" />

        

    </asp:Panel>

</asp:Content>
