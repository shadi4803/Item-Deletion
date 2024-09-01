using DatabaseClass;
using DocumentFormat.OpenXml.Office2013.Word;
using DocumentFormat.OpenXml.Wordprocessing;
using Microsoft.Ajax.Utilities;
using Org.BouncyCastle.Asn1.Esf;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace NCAAA
{
    public partial class deletion : System.Web.UI.Page
    {

        DatabaseClass.Program objProgram = new Program();
        DateTime currentDateTime = DateTime.Now;
        string autherName = null;
        string status = "AP1";
        int counter = 1;
        int NumberOfPeople = 0;
        string UserEmail = null;
        string checkrequestnumber = null;
        protected void Page_Load(object sender, EventArgs e)
        {

            try
            {
                if (!IsPostBack)
                {
                    objProgram.gCheckUserInSession(lblUserId);
                    objProgram.gCheckUserType(lblUserType);

                }
                objProgram.strSql = "select max(id) from t_item_deletion";
                objProgram.drData = objProgram.gRetrieveRecord(objProgram.strSql);
                if (objProgram.drData.Read())
                {
                    checkrequestnumber = objProgram.drData[""].ToString();
                }
                objProgram.drData.Close();
            }
            catch (Exception ex)
            {

            }
            finally
            {

            }



        }
        protected void btnConfirm_Click(object sender, EventArgs e)
        {

            Response.Redirect("YourPage.aspx");
            //or
            Server.Transfer("YourPage.aspx");
        }
        protected void type_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (type.SelectedItem.Value == "mid")
            {
                type.Text = "mid";
            }
            else if (type.SelectedItem.Value == "final")
            {
                type.Text = "final";
            }
        }
        protected void coursename_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (coursename.SelectedItem.Value == "1")
            {
                coursecode.Text = "ENGH 101";
            }
            else if (coursename.SelectedItem.Value == "2")
            {
                coursecode.Text = "ENGH 102 ";
            }
            else if (coursename.SelectedItem.Value == "3")
            {
                coursecode.Text = "ENGH 103";
            }
            else if (coursename.SelectedItem.Value == "4")
            {
                coursecode.Text = "ENGH 111 ";
            }
            else if (coursename.SelectedItem.Value == "5")
            {
                coursecode.Text = "ENGH 112";
            }
            else if (coursename.SelectedItem.Value == "6")
            {
                coursecode.Text = "ENGH 113";
            }
            else if (coursename.SelectedItem.Value == "7")
            {
                coursecode.Text = "ENGH 114";
            }
            else if (coursename.SelectedItem.Value == "8")
            {
                coursecode.Text = "ENGH 211";
            }
            else if (coursename.SelectedItem.Value == "9")
            {
                coursecode.Text = "ISLM 101";
            }
            else if (coursename.SelectedItem.Value == "10")
            {
                coursecode.Text = "ARBC 101";
            }
            else if (coursename.SelectedItem.Value == "11")
            {
                coursecode.Text = "ARBC 102";
            }
            else if (coursename.SelectedItem.Value == "12")
            {
                coursecode.Text = "PHYS 111";
            }
            else if (coursename.SelectedItem.Value == "13")
            {
                coursecode.Text = "CHEM 111";
            }
            else if (coursename.SelectedItem.Value == "14")
            {
                coursecode.Text = "CHEM 112";
            }
            else if (coursename.SelectedItem.Value == "15")
            {
                coursecode.Text = "PHYS 112";
            }
            else if (coursename.SelectedItem.Value == "16")
            {
                coursecode.Text = "BIOL 111";
            }
            else if (coursename.SelectedItem.Value == "17")
            {
                coursecode.Text = "BIOS 211";
            }
            else if (coursename.SelectedItem.Value == "18")
            {
                coursecode.Text = "TERM 211";
            }
            else if (coursename.SelectedItem.Value == "19")
            {
                coursecode.Text = "BCHM 211";
            }
            else if (coursename.SelectedItem.Value == "20")
            {
                coursecode.Text = "IMMC 211";
            }
            else if (coursename.SelectedItem.Value == "21")
            {
                coursecode.Text = "RESC 211";
            }
            else if (coursename.SelectedItem.Value == "22")
            {
                coursecode.Text = "BCHM 213";
            }
            else if (coursename.SelectedItem.Value == "23")
            {
                coursecode.Text = "COMP 211";
            }
            else if (coursename.SelectedItem.Value == "24")
            {
                coursecode.Text = "ANAT 211";
            }
            else if (coursename.SelectedItem.Value == "25")
            {
                coursecode.Text = "PHYG 211";
            }
            else if (coursename.SelectedItem.Value == "26")
            {
                coursecode.Text = "BEHS 211";
            }
            else if (coursename.SelectedItem.Value == "27")
            {
                coursecode.Text = "APNS 211";
            }
            else if (coursename.SelectedItem.Value == "28")
            {
                coursecode.Text = "PHRM 211";
            }
            else if (coursename.SelectedItem.Value == "29")
            {
                coursecode.Text = "PAMG 211";
            }
            else if (coursename.SelectedItem.Value == "30")
            {
                coursecode.Text = "HIHD 211";
            }
            else if (coursename.SelectedItem.Value == "31")
            {
                coursecode.Text = "ETHC 211";
            }
            else if (coursename.SelectedItem.Value == "32")
            {
                coursecode.Text = "BIOS 211";
            }
            else if (coursename.SelectedItem.Value == "33")
            {
                coursecode.Text = "IMMC 212";
            }
            else if (coursename.SelectedItem.Value == "34")
            {
                coursecode.Text = "BCHM 214";
            }
            else if (coursename.SelectedItem.Value == "35")
            {
                coursecode.Text = "ANAT 212";
            }
            else if (coursename.SelectedItem.Value == "36")
            {
                coursecode.Text = "PHYG 212";
            }
            else if (coursename.SelectedItem.Value == "37")
            {
                coursecode.Text = "PHRM 212";
            }
            else if (coursename.SelectedItem.Value == "38")
            {
                coursecode.Text = "PAMG 212";
            }
            else if (coursename.SelectedItem.Value == "39")
            {
                coursecode.Text = "IMMC 213";
            }
            else if (coursename.SelectedItem.Value == "40")
            {
                coursecode.Text = "BCHM 215";
            }
            else if (coursename.SelectedItem.Value == "41")
            {
                coursecode.Text = "ANAT 213";
            }
            else if (coursename.SelectedItem.Value == "42")
            {
                coursecode.Text = "PHYG 213";
            }
            else if (coursename.SelectedItem.Value == "43")
            {
                coursecode.Text = "PHRM 213";
            }
            else if (coursename.SelectedItem.Value == "44")
            {
                coursecode.Text = "PAMG 213";
            }
            else if (coursename.SelectedItem.Value == "45")
            {
                coursecode.Text = "PHBS 211";
            }
            else if (coursename.SelectedItem.Value == "46")
            {
                coursecode.Text = "IMMC 214";
            }
            else if (coursename.SelectedItem.Value == "47")
            {
                coursecode.Text = "BCHM 216";
            }
            else if (coursename.SelectedItem.Value == "48")
            {
                coursecode.Text = "ANAT 214";
            }
            else if (coursename.SelectedItem.Value == "49")
            {
                coursecode.Text = "PHYG 214";
            }
            else if (coursename.SelectedItem.Value == "50")
            {
                coursecode.Text = "AHPE 211";
            }
            else if (coursename.SelectedItem.Value == "51")
            {
                coursecode.Text = "PHRM 214";
            }
            else if (coursename.SelectedItem.Value == "52")
            {
                coursecode.Text = "PAMG 214";
            }
            else if (coursename.SelectedItem.Value == "53")
            {
                coursecode.Text = "IMMC 215";
            }
            else if (coursename.SelectedItem.Value == "54")
            {
                coursecode.Text = "ANAT 215";
            }
            else if (coursename.SelectedItem.Value == "55")
            {
                coursecode.Text = "PHYG 215";
            }
            else if (coursename.SelectedItem.Value == "56")
            {
                coursecode.Text = "HINF 201";
            }
            else if (coursename.SelectedItem.Value == "57")
            {
                coursecode.Text = "PHRM 215";
            }
            else if (coursename.SelectedItem.Value == "58")
            {
                coursecode.Text = "PAMG 215";
            }
            else if (coursename.SelectedItem.Value == "59")
            {
                coursecode.Text = "BCHM 212";
            }
            else if (coursename.SelectedItem.Value == "60")
            {
                coursecode.Text = "PNUR 211";
            }
            else if (coursename.SelectedItem.Value == "61")
            {
                coursecode.Text = "BNUR 211";
            }
            else if (coursename.SelectedItem.Value == "62")
            {
                coursecode.Text = "BNUR 212";
            }
            else if (coursename.SelectedItem.Value == "63")
            {
                coursecode.Text = "PNUR 213";
            }
            else if (coursename.SelectedItem.Value == "64")
            {
                coursecode.Text = "BNUR 213";
            }
            else if (coursename.SelectedItem.Value == "65")
            {
                coursecode.Text = "PNUR 214";
            }
            // We need to change values here 

        }
        protected void reason_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (reason.SelectedItem.Text == "Other")
            {
                other.Visible = true;
                other1.Visible = true;
            }
            else
            {
                other.Visible = false;
                other1.Visible = false;
            }

        }
        protected void radRiyadhM_CheckedChanged(object sender, EventArgs e)
        {
            if (radRiyadhM.Checked)
            {
                RM.Visible = true;
                RM.Text = "@ksau-hs.edu.sa";
            }
            else
            {
                RM.Visible = false;
                RM.Text = string.Empty;
            }
        }
        protected void radJeddahM_CheckedChanged(object sender, EventArgs e)
        {
            if (radJeddahM.Checked)
            {
                JM.Visible = true;
                JM.Text = "@ksau-hs.edu.sa";
            }
            else
            {
                JM.Visible = false;
                JM.Text = string.Empty;
            }
        }
        protected void radAlahsaM_CheckedChanged(object sender, EventArgs e)
        {
            if (radAlahsaM.Checked)
            {
                AM.Visible = true;
                AM.Text = "@ksau-hs.edu.sa";
            }
            else
            {
                AM.Visible = false;
                AM.Text = string.Empty;
            }
        }
        protected void radRiyadhF_CheckedChanged(object sender, EventArgs e)
        {
            if (radRiyadhF.Checked)
            {
                RF.Visible = true;
                RF.Text = "@ksau-hs.edu.sa";
            }
            else
            {
                RF.Visible = false;
                RF.Text = string.Empty;
            }
        }
        protected void radJeddahF_CheckedChanged(object sender, EventArgs e)
        {
            if (radJeddahF.Checked)
            {
                JF.Visible = true;
                JF.Text = "@ksau-hs.edu.sa";
            }
            else
            {
                JF.Visible = false;
                JF.Text = string.Empty;
            }
        }
        protected void radAlahsaF_CheckedChanged(object sender, EventArgs e)
        {
            if (radAlahsaF.Checked)
            {
                AF.Visible = true;
                AF.Text = "@ksau-hs.edu.sa";
            }
            else
            {
                AF.Visible = false;
                AF.Text = string.Empty;
            }
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {

            objProgram.strSql = "SELECT * from t_users where id =" + lblUserId.Text;
            objProgram.drData = objProgram.gRetrieveRecord(objProgram.strSql);
            if (objProgram.drData.Read())
            {
                lblUserName.Text = objProgram.drData["user_full_name"].ToString();
                UserEmail = objProgram.drData["email"].ToString();
            }
            objProgram.drData.Close();
            string RequestNumber = null;
            string formattedDateTime = currentDateTime.ToString("dddd, dd MMMM yyyy hh: mm tt");
            // all of this down are for emails
            string examdate = dtpReportDate.SelectedDate.ToString();
            string date = formattedDateTime.ToString();
            string courceName = coursename.SelectedItem.ToString();
            string courcecode = coursecode.Text.ToString();
            string qnumber1 = qnumber.Value.ToString();
            string Thequestion = question.InnerText.ToString();
            string Thereason = reason.SelectedItem.Text.ToString();
            string otherreason = other.Text.ToString();
            string Justification1 = Justification.ToString();
            string riyadhmaleMail = RM.Text.ToString();
            string jeddahmaleMail = JM.Text.ToString();
            string ahsaamaleMail = AM.Text.ToString();
            string riyadhfemaleMail = RF.Text.ToString();
            string jeddahfemaleMail = JF.Text.ToString();
            string ahsaafemaleMail = AF.Text.ToString();
            string examtype = type.Text.ToString();
            string username = lblUserName.Text.ToString();

            if (radAlahsaF.Checked)
            {
                NumberOfPeople += counter;
            }
            if (radRiyadhM.Checked)
            {
                NumberOfPeople += counter;
            }
            if (radJeddahM.Checked)
            {
                NumberOfPeople += counter;
            }
            if (radAlahsaM.Checked)
            {
                NumberOfPeople += counter;
            }
            if (radJeddahF.Checked)
            {
                NumberOfPeople += counter;
            }
            if (radRiyadhF.Checked)
            {
                NumberOfPeople += counter;
            }
            try
            {
                objProgram.Add("number_of_people", NumberOfPeople.ToString(), "S");
                objProgram.Add("status", status.ToString(), "S");
                objProgram.Add("exam_date", dtpReportDate.SelectedDate.ToString(), "D");
                objProgram.Add("course_name", coursename.SelectedItem.Text, "S");
                objProgram.Add("course_code", coursecode.Text, "S");
                objProgram.Add("question_id", qnumber.Value, "I");
                objProgram.Add("question", question.InnerText, "S");
                objProgram.Add("reason", reason.SelectedItem.Text, "S");
                objProgram.Add("other_reason", other.Text, "S");
                objProgram.Add("Justification", Justification.InnerText, "S");
                objProgram.Add("RM", RM.Text, "S");
                objProgram.Add("JM", JM.Text, "S");
                objProgram.Add("AM", AM.Text, "S");
                objProgram.Add("RF", RF.Text, "S");
                objProgram.Add("JF", JF.Text, "S");
                objProgram.Add("AF", AF.Text, "S");
                objProgram.Add("exam_type", type.Text, "S");
                objProgram.Add("request_date", formattedDateTime, "S");
                objProgram.Add("auther_name", lblUserName.Text, "S");

                objProgram.InsertRecordStatement("t_item_deletion");

                coursename.SelectedIndex = 0;
                coursecode.Text = "";
                question.InnerText = "";
                reason.SelectedIndex = 0;
                other.Text = "";
                Campus.Text = "";
                Justification.InnerText = "";
                RM.Text = "";
                JM.Text = "";
                AM.Text = "";
                RF.Text = "";
                JF.Text = "";
                AF.Text = "";
                type.Text = "";
                formattedDateTime = "";
                autherName = "";
                objProgram.strSql = "select max(id) from t_item_deletion";
                objProgram.drData = objProgram.gRetrieveRecord(objProgram.strSql);
                if (objProgram.drData.Read())
                {
                    RequestNumber = objProgram.drData[""].ToString();
                }
                objProgram.drData.Close();
                int oldRN = Convert.ToInt32(checkrequestnumber);
                int newRN = Convert.ToInt32(RequestNumber);
                if (oldRN != newRN)
                {
                    
                    string strToEmail = UserEmail; // to the author
                    string strEmailSubject = "ITEM DELETION";
                    string strEmailBody = "Dear, " + username + "<br> Your request for <b>ITEM DELETION</b> has been initiated. <br> <b>Request #: "
                        + RequestNumber + "<br>Request Date and Time: </b>" + date + "<br><b> Course Code: </b>" + courcecode + "<br> <b>Course Name : </b>" + courceName
                        + "<br> <b>Exam Type: </b>" + examtype + "<br><b>Exam Date and Time: </b>" + examdate + "<br> Thank you";
                    objProgram.SendMail("", strToEmail, strEmailSubject, strEmailBody);
                    strToEmail = "tajuddinr@ksau-hs.edu.sa"; // to AU email
                    strEmailBody = "Dears, <br> An <b>ITEM DELETION</b> has been requested: <br> <b>Request #: "
                        + RequestNumber + "<br>Request Date and Time: </b>" + date + "<br><b> Course Code: </b>" + courcecode + "<br> <b>Course Name : </b>" + courceName
                        + "<br> <b>Exam Type: </b>" + examtype + "<br><b>Exam Date and Time: </b>" + examdate
                        + "<br> Kindly stop the marking process for this exam, until further notice. <br> Thank you.";
                    objProgram.SendMail("", strToEmail, strEmailSubject, strEmailBody);
                    objProgram.SendMail("", "khans@ksau-hs.edu.sa", strEmailSubject, strEmailBody);


                    if (radAlahsaF.Checked)
                    {
                        strToEmail = ahsaafemaleMail;
                        strEmailBody = "Dears, <br> An ITEM DELETION has been requested: <br><b>Request #: "
                        + RequestNumber + "<br>Request Date and Time: </b>" + date + "<br><b> Course Code: </b>" + courcecode + "<br> <b>Course Name : </b>" + courceName
                        + "<br> <b>Exam Type: </b>" + examtype + "<br><b>Exam Date and Time: </b>" + examdate
                        + "<br> Please follow the <a href='http://aysar.ksau-hs.edu.sa/'>link</a> for your action. Your prompt feedback is highly required.  <br> Thank you.";
                        objProgram.SendMail("", strToEmail, strEmailSubject, strEmailBody);
                    }
                    if (radRiyadhM.Checked)
                    {
                        strToEmail = riyadhmaleMail;
                        strEmailBody = "Dears, <br> An ITEM DELETION has been requested: <br><b>Request #: "
                        + RequestNumber + "<br>Request Date and Time: </b>" + date + "<br><b> Course Code: </b>" + courcecode + "<br> <b>Course Name : </b>" + courceName
                        + "<br> <b>Exam Type: </b>" + examtype + "<br><b>Exam Date and Time: </b>" + examdate
                        + "<br> Please follow the <a href='http://aysar.ksau-hs.edu.sa/'>link</a> for your action. Your prompt feedback is highly required.  <br> Thank you.";
                        objProgram.SendMail("", strToEmail, strEmailSubject, strEmailBody);
                    }
                    if (radJeddahM.Checked)
                    {
                        strToEmail = jeddahmaleMail;
                        strEmailBody = "Dears, <br> An ITEM DELETION has been requested: <br><b>Request #: "
                        + RequestNumber + "<br>Request Date and Time: </b>" + date + "<br><b> Course Code: </b>" + courcecode + "<br> <b>Course Name : </b>" + courceName
                        + "<br> <b>Exam Type: </b>" + examtype + "<br><b>Exam Date and Time: </b>" + examdate
                        + "<br> Please follow the <a href='http://aysar.ksau-hs.edu.sa/'>link</a> for your action. Your prompt feedback is highly required.  <br> Thank you.";
                        objProgram.SendMail("", strToEmail, strEmailSubject, strEmailBody);
                    }
                    if (radAlahsaM.Checked)
                    {
                        strToEmail = ahsaamaleMail;
                        strEmailBody = "Dears, <br> An ITEM DELETION has been requested: <br><b>Request #: "
                        + RequestNumber + "<br>Request Date and Time: </b>" + date + "<br><b> Course Code: </b>" + courcecode + "<br> <b>Course Name : </b>" + courceName
                        + "<br> <b>Exam Type: </b>" + examtype + "<br><b>Exam Date and Time: </b>" + examdate
                        + "<br> Please follow the <a href='http://aysar.ksau-hs.edu.sa/'>link</a> for your action. Your prompt feedback is highly required.  <br> Thank you.";
                        objProgram.SendMail("", strToEmail, strEmailSubject, strEmailBody);
                    }
                    if (radJeddahF.Checked)
                    {
                        strToEmail = jeddahfemaleMail;
                        strEmailBody = "Dears, <br> An ITEM DELETION has been requested: <br><b>Request #: "
                        + RequestNumber + "<br>Request Date and Time: </b>" + date + "<br><b> Course Code: </b>" + courcecode + "<br> <b>Course Name : </b>" + courceName
                        + "<br> <b>Exam Type: </b>" + examtype + "<br><b>Exam Date and Time: </b>" + examdate
                        + "<br> Please follow the <a href='http://aysar.ksau-hs.edu.sa/'>link</a> for your action. Your prompt feedback is highly required.  <br> Thank you.";
                        objProgram.SendMail("", strToEmail, strEmailSubject, strEmailBody);
                    }
                    if (radRiyadhF.Checked)
                    {
                        strToEmail = riyadhfemaleMail;
                        strEmailBody = "Dears, <br> An ITEM DELETION has been requested: <br><b>Request #: "
                        + RequestNumber + "<br>Request Date and Time: </b>" + date + "<br><b> Course Code: </b>" + courcecode + "<br> <b>Course Name : </b>" + courceName
                        + "<br> <b>Exam Type: </b>" + examtype + "<br><b>Exam Date and Time: </b>" + examdate
                         + "<br> Please follow the <a href='http://aysar.ksau-hs.edu.sa/'>link</a> for your action. Your prompt feedback is highly required.  <br> Thank you.";
                        objProgram.SendMail("", strToEmail, strEmailSubject, strEmailBody);
                    }
                    Response.Redirect("sent.aspx", true);
                }
                else
                {
                    Response.Redirect("Default.aspx", true);
                }

            }
            catch (Exception exp)
            {

            }
            finally
            {

            }
        }
        
    }
}