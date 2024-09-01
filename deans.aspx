<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="deans.aspx.cs" Inherits="NCAAA.deans" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  <asp:Label ID="lblUserId" runat="server" Visible="false"></asp:Label>
        <asp:Label ID="lblUserType" runat="server" Visible="false"></asp:Label>
                <asp:Label ID="lblUserName" runat="server" Visible="false"></asp:Label>

    <fieldset>
<legend>
Item Deletion System 2023
</legend>
       <label>Request Number : </label> <asp:Label ID="RNumber" runat="server" Text=""></asp:Label> 
<br />
       <label>Request Date : </label>
       <asp:Label ID="requestdate" runat="server" Text=""></asp:Label>
<br>
       <label>Exam Date :</label>
       <asp:Label ID="getdate" runat="server" Text=""></asp:Label>
<br />
       <label>Course Code : </label> <asp:Label ID="courcecode" runat="server" Text=""></asp:Label>
<br />
       <label> Exam Type : </label> <asp:Label ID="xamtype" runat="server" Text=""></asp:Label>
<br>  
       <label id="AN1">Auther Name : </label><asp:Label ID="AutherName" runat="server" Text=""></asp:Label>
<br>
       <label id="CN1"> course Name : </label> <asp:Label ID="courseName" runat="server" Text=""></asp:Label>
<br>  
      <label> ID Question : </label> <asp:Label ID="Questionid" runat="server" Text=""></asp:Label>  
<br />
       <label>Reason For Deletion :</label>
       <asp:label id="deletion" runat="server"   style="height:100px; width:50%; text-align: inherit"></asp:label>
<br />
       <label> <strong>The Question :</strong><br /><br /></label>
       <asp:label ID="Q" runat="server" style="height:100px; width:50%; text-align: inherit" ></asp:label>        
<br>
<br>
       <h4> <label> Justification : </label>
       </h4><asp:Label ID="Justification" runat="server" Text=""></asp:Label>  
<br> 
<br> 


                <asp:Label ID ="AP1" runat="server" Text="Approval level 1"></asp:Label>
<br />
          <asp:GridView ID="gridview1" runat="server" AutoGenerateColumns="false">
        <Columns>

            <asp:BoundField DataField="user_full_name" HeaderText="Name" />
            <asp:BoundField DataField="agree" HeaderText="The agreement" />
            <asp:BoundField DataField="remarks" HeaderText="The remark" />
        </Columns>
    </asp:GridView>
<br />
        <asp:Label ID ="AP2" runat="server" Text="Approval level 2"></asp:Label>
<br />
         <asp:GridView ID="gridview2" runat="server" AutoGenerateColumns="false">
        <Columns>

            <asp:BoundField DataField="user_full_name" HeaderText="Name" />
            <asp:BoundField DataField="agree" HeaderText="The agreement" />
            <asp:BoundField DataField="remarks" HeaderText="The remark" />
        </Columns>
    </asp:GridView>
<br />
         <h4>Agreement:</h4>
        <asp:RadioButton ID="radAgree" runat="server" Text="Approve" GroupName="radAgreement" Checked="true" /><br />
        <asp:RadioButton ID="radDisagree" runat="server" Text="Decline" GroupName="radAgreement" />
<br />
         <h4> Your Remark : </h4> 
       <asp:textbox id="remark" runat="server"   style="height:100px; width:50%; text-align: inherit"></asp:textbox>
<br />
        <center>
                   <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click"OnClientClick="this.disabled = true; this.value = 'Submit in progress...';" UseSubmitBehavior="false" />

        </center> 
</asp:Content>
