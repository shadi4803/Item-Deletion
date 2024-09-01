<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="deletion.aspx.cs" Inherits="NCAAA.deletion" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="Tools" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        #qnumber {
            width: 184px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server" width="80%">
    <asp:Label ID="lblUserId" runat="server" Visible="false"></asp:Label>
        <asp:Label ID="lblUserType" runat="server" Visible="false"></asp:Label>
                <asp:Label ID="lblUserName" runat="server" Visible="false"></asp:Label>

    <fieldset>
<legend>
Item Deletion System 2023
</legend>
<br />
               <label for="ExamDate">Exam Date:</label>
               <telerik:RadDatePicker ID="dtpReportDate" runat="server" Width="220">
               </telerik:RadDatePicker>                              
<br />
<br />
               <label>Choose Exame Type:</label>
               <asp:DropDownList ID="type" runat="server" Height="17px" style="margin-left: 8px" Width="180px" OnSelectedIndexChanged="type_SelectedIndexChanged">
               <asp:ListItem></asp:ListItem>
               <asp:ListItem Text="Midterm Exam" Value="mid"/>
               <asp:ListItem Text="Final Exam" Value="final"/>
               </asp:DropDownList>
<br />
<br />
<br />
               <label> Course Name:</label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
               <asp:DropDownList ID="coursename"  runat="server" AutoPostBack="true" OnSelectedIndexChanged="coursename_SelectedIndexChanged" Height="17px" style="margin-left: 8px" Width="180px">
               <asp:ListItem></asp:ListItem>
               <asp:ListItem Text="English Communication Skills" Value="1"/>
               <asp:ListItem Text="English Grammar I" Value="2"/>
               <asp:ListItem Text="English Reading and Vocabulary" Value="3"/>
               <asp:ListItem Text="English Academic Writing for Health Sciences I" Value="4"/>  
               <asp:ListItem Text="English Grammar II" Value="5"/>
               <asp:ListItem Text="English Academic Writing for Health Sciences II" Value="6"/>
               <asp:ListItem Text="English Grammar III" Value="7"/> 
               <asp:ListItem Text="English Academic Writing for Health Sciences III" Value="8"/>
               <asp:ListItem Text="Islamic Culture" Value="9"/>
               <asp:ListItem Text="Arabic Language Skills I" Value="10"/> 
               <asp:ListItem Text="Arabic Language Skills II" Value="11"/> 
               <asp:ListItem Text="Physics for Health Sciences I" Value="12"/> 
               <asp:ListItem Text="Chemistry for Health Sciences I" Value="13"/> 
               <asp:ListItem Text="Chemistry for Health Sciences II" Value="14"/> 
               <asp:ListItem Text="Physics for Health Sciences II" Value="15"/> 
               <asp:ListItem Text="Biology for Health Sciences" Value="16"/> 
               <asp:ListItem Text="Biostatistics" Value="17"/> 
               <asp:ListItem Text="Medical Terminology" Value="18"/> 
               <asp:ListItem Text="Basic Biochemistry for Health Sciences" Value="19"/> 
               <asp:ListItem Text="Microbiology & Immunology for Medicine" Value="20"/>
               <asp:ListItem Text="Research Skills" Value="21"/>
               <asp:ListItem Text="Advanced Biochemistry for Medicine" Value="22"/>
               <asp:ListItem Text="Computer Science & Health Informatics" Value="23"/>
               <asp:ListItem Text="Anatomy for Medicine" Value="24"/>
               <asp:ListItem Text="Physiology for Medicine" Value="25"/>
               <asp:ListItem Text="Behavioral Science" Value="26"/>
               <asp:ListItem Text="Anatomy & Physiology for Nervous System" Value="27"/>
               <asp:ListItem Text="Pharmacology for Medicine" Value="28"/>
               <asp:ListItem Text="Pathology and Molecular Genetics for Medicine" Value="29"/>
               <asp:ListItem Text="Histology and Human Development" Value="30"/>
               <asp:ListItem Text="Ethics for Health Care Profession" Value="31"/>
               <asp:ListItem Text="Biostatistics" Value="32"/>
               <asp:ListItem Text="Microbiology & Immunology for Dentistry" Value="33"/>
               <asp:ListItem Text="Advanced Biochemistry for Dentistry" Value="34"/>
               <asp:ListItem Text="Anatomy for Dentistry" Value="35"/>
               <asp:ListItem Text="Physiology for Dentistry" Value="36"/>
               <asp:ListItem Text="Pharmacology for Dentistry" Value="37"/>
               <asp:ListItem Text="Pathology and Molecular Genetics for Dentistry" Value="38"/>
               <asp:ListItem Text="Microbiology & Immunology for Pharmacy" Value="39"/>
               <asp:ListItem Text="Advanced Biochemistry for Pharmacy" Value="40"/>
               <asp:ListItem Text="Anatomy for Pharmacy" Value="41"/>
               <asp:ListItem Text="Physiology for Pharmacy" Value="42"/>
               <asp:ListItem Text="Pharmacology for Pharmacy" Value="43"/>
               <asp:ListItem Text="Pathology and Molecular Genetics for Pharmacy" Value="44"/>
               <asp:ListItem Text="Pharmaceutical Organic Chemistry" Value="45"/>
               <asp:ListItem Text="Microbiology & Immunology for Applied Medical Sciences" Value="46"/>
               <asp:ListItem Text="Advanced Biochemistry for Applied Medical Sciences" Value="47"/>
               <asp:ListItem Text="Anatomy for Applied Medical Sciences" Value="48"/>
               <asp:ListItem Text="Physiology for Applied Medical Sciences" Value="49"/>
               <asp:ListItem Text="Apllied Health Professions Education" Value="50"/>
               <asp:ListItem Text="Pharmacology for Applied Medical Sciences" Value="51"/>
               <asp:ListItem Text="Pathology and Molecular Genetics for Applied Medical Sciences" Value="52"/>
               <asp:ListItem Text="Microbiology & Immunology for Health Informatics" Value="53"/>
               <asp:ListItem Text="Anatomy for Health Informatics" Value="54"/>
               <asp:ListItem Text="Physiology for Health Informatics" Value="55"/>
               <asp:ListItem Text="ntroduction to Health Informatic" Value="56"/>
               <asp:ListItem Text="Pharmacology for Health Informatics" Value="57"/>
               <asp:ListItem Text="Pathology and Molecular Genetics for Health Informatics" Value="58"/>
               <asp:ListItem Text="Basic Biochemistry for Nursing" Value="59"/>
               <asp:ListItem Text="Anatomy & Physiology for Nursing I" Value="60"/>
               <asp:ListItem Text="Fundamentals of Nursing I" Value="61"/>
               <asp:ListItem Text="Fundamentals of Nursing II" Value="62"/>
               <asp:ListItem Text="Pathophysiology for Nursing" Value="63"/>
               <asp:ListItem Text="Nutrition" Value="64"/>
               <asp:ListItem Text="Microbiology for Nursing" Value="65"/>
                
               </asp:DropDownList>
<br />
<br />
<br />  
               Course code:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:textbox type="text" id="coursecode" runat="server" Width="187px" MaxLength="50" AutoPostBack="true"></asp:textbox>
<br />
<br />
<br />
               <label>Enter ID Question : </label>
               <input type="number" id="qnumber" runat="server"></input>     
<br />
<br />
               <br /> Write the Question : 
        <br />
        <br /> 
               <textarea type="text" id="question" runat="server" style="height:100px;width:50%;"></textarea>
<br />
<br />
<br />
               <label>  Reason for item deletion:</label>
               <asp:DropDownList ID="reason" runat="server" AutoPostBack="true" OnSelectedIndexChanged="reason_SelectedIndexChanged" Width="165px" style="margin-left: 0px">
               <asp:ListItem></asp:ListItem>
               <asp:ListItem   Text="Item not covered" Value="Item"/>
               <asp:ListItem   Text="Two correct answers" Value="Two"/>
               <asp:ListItem   Text="Educational Affairs" Value="Nocorrect"/>
               <asp:ListItem   Text="Other" Value="Other"/>
               </asp:DropDownList> 
<br />
<br />
<br />
<br />
               <asp:Label ID="other1" runat="server" Visible="false" Text="For Other: "></asp:Label>     
<br />
<br />
               <asp:textbox id="other" runat="server" visible="false"  style="height:100px; width:50%; text-align: inherit"></asp:textbox>
<br />
<br />
<br />
              <br /> Write Justification : 
        <br />
        <br />    <textarea type="text" ID="Justification" runat="server" style="height:100px;width:50%;"></textarea>        
<br />
<br />
<br />       
<asp:UpdatePanel ID="uptMain" runat="server">      
<ContentTemplate>
<asp:Table ID="tblMain" runat="server" Width="80%"> 
<asp:TableRow>
<asp:TableCell style="vertical-align:central;" Width="20%"></asp:TableCell>
<asp:TableCell Width="80%"></asp:TableCell>
</asp:TableRow>
<asp:TableRow>
<asp:TableCell style="vertical-align:central;" Width="20%">
            <asp:Label ID="Campus" runat="server" Text="Choose Campus:"></asp:Label>
</asp:TableCell>

            <asp:TableCell Width="80%">
            <asp:checkbox ID="radRiyadhM" runat="server" Text ="COSHP Riyadh Male"  OnCheckedChanged="radRiyadhM_CheckedChanged" AutoPostBack="true" />&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp
            <asp:Label ID="Label4" runat="server" Text="Course coordinator email :"></asp:Label>
            <asp:textbox type="text" id="RM" runat="server" Visible="false" style="height:20px;width:35%;"></asp:textbox>
<br >
<br >
            <asp:checkbox ID="radJeddahM" runat="server" Text ="COSHP Jeddah Male" OnCheckedChanged="radJeddahM_CheckedChanged" AutoPostBack="true" />&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp
            <asp:Label ID="Label5" runat="server" Text="Course coordinator email :"></asp:Label> 
            <asp:textbox type="text" id="JM" runat="server" Visible="false" style="height:20px;width:35%;"></asp:textbox>
<br >
<br >
            <asp:checkbox ID="radAlahsaM" runat="server" Text ="COSHP Al Ahsa Male" OnCheckedChanged="radAlahsaM_CheckedChanged" AutoPostBack="true"/>&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp
            <asp:Label ID="Label6" runat="server" Text="Course coordinator email :"></asp:Label> 
            <asp:textbox type="text" id="AM" runat="server" Visible="false" style="height:20px;width:35%;"></asp:textbox>
<br >
<br >
            <asp:checkbox ID="radRiyadhF" runat="server" Text ="COSHP Riyadh Female" OnCheckedChanged="radRiyadhF_CheckedChanged" AutoPostBack="true" />&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp
            <asp:Label ID="Label1" runat="server" Text="Course coordinator email :"></asp:Label>
            <asp:textbox type="text" id="RF" runat="server" Visible="false" style="height:20px;width:35%;"></asp:textbox>
<br >
<br >
            <asp:checkbox ID="radJeddahF" runat="server" Text ="COSHP Jeddah Female" OnCheckedChanged="radJeddahF_CheckedChanged" AutoPostBack="true" />&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp
            <asp:Label ID="Label2" runat="server" Text="Course coordinator email :"></asp:Label> 
            <asp:textbox type="text" id="JF" runat="server" Visible="false" style="height:20px;width:35%;"></asp:textbox>
<br >
<br >
            <asp:checkbox ID="radAlahsaF" runat="server" Text ="COSHP Al Ahsa Female" OnCheckedChanged="radAlahsaF_CheckedChanged" AutoPostBack="true"/>&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp
            <asp:Label ID="Label7" runat="server" Text="Course coordinator email :"></asp:Label> 
            <asp:textbox type="text" id="AF" runat="server" Visible="false" style="height:20px;width:35%;"></asp:textbox>

</asp:TableCell>
</asp:TableRow>         
<asp:TableRow>
            <asp:TableCell ColumnSpan="2" style="text-align:center;">
<br >
<br >
<br >
            <asp:Button ID="btnSave" runat="server" Text="Send" Visible="true" OnClick="btnSave_Click" OnClientClick="this.disabled = true; this.value = 'Submit in progress...';" UseSubmitBehavior="false" />
</form>                          
</asp:TableCell>
</asp:TableRow>
</asp:Table>
</ContentTemplate>
</asp:UpdatePanel>
</fieldset>
</asp:Content>


