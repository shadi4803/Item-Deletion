<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Approval.aspx.cs" Inherits="NCAAA.Approval" %>
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
      <h4> <label> Justification : </label> </h4><asp:Label ID="Justification" runat="server" Text=""></asp:Label>  
<br>
       <h4>Agreement:</h4>
        <asp:RadioButton ID="radAgree" runat="server" Text="Agree" GroupName="radAgreement" Checked="true" /><br />
        <asp:RadioButton ID="radDisagree" runat="server" Text="Disagree" GroupName="radAgreement" />
<br />
<br>
<br>
       <h4> Your Remark : </h4> 
       <asp:textbox id="remark" runat="server"   style="height:100px; width:50%; text-align: inherit"></asp:textbox>
<center>
<br />
<br />
<br />
<br />    

       <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click"OnClientClick="this.disabled = true; this.value = 'Submit in progress...';" UseSubmitBehavior="false" />
</center>
<br />
<br />
<br />
</fieldset>
</asp:Content>
