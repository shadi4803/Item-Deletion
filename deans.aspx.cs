using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Xml.Linq;
using System.Data.SqlClient;
using System.Drawing;

namespace NCAAA
{
    public partial class deans : System.Web.UI.Page
    {
        DatabaseClass.Program objProgram = new DatabaseClass.Program();      

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    objProgram.gCheckUserInSession(lblUserId);
                    objProgram.strSql = "SELECT user_full_name from t_users where id =" + lblUserId.Text;
                    objProgram.drData = objProgram.gRetrieveRecord(objProgram.strSql);
                    if (objProgram.drData.Read())
                    {
                        lblUserName.Text = objProgram.drData["user_full_name"].ToString();
                    }
                    objProgram.drData.Close();
                }

                if (Session["requestnumber"] != null && Session["requestnumber"].ToString().Trim().Length > 0)
                {
                    RNumber.Text = Session["requestnumber"].ToString();
                    objProgram.strSql = "select agree,remarks,user_full_name from t_item_deletion_remarks where item_deletion_id = " + RNumber.Text;
                    objProgram.drData = objProgram.gRetrieveRecord(objProgram.strSql);
                    gridview1.DataSource = objProgram.drData;
                    gridview1.DataBind();
                    objProgram.drData.Close();

                    objProgram.strSql = "SELECT * FROM t_item_deletion WHERE id = " + RNumber.Text;
                    objProgram.drData = objProgram.gRetrieveRecord(objProgram.strSql);
                    if(objProgram.drData.Read())
                    {
                        requestdate.Text = objProgram.drData["request_date"].ToString();
                        getdate.Text = objProgram.drData["exam_date"].ToString();
                        courseName.Text = objProgram.drData["course_name"].ToString();
                        courcecode.Text = objProgram.drData["course_code"].ToString();
                        Questionid.Text = objProgram.drData["question_id"].ToString();
                        deletion.Text = objProgram.drData["reason"].ToString();
                        Q.Text = objProgram.drData["question"].ToString();
                        xamtype.Text = objProgram.drData["exam_type"].ToString();
                        AutherName.Text = objProgram.drData["auther_name"].ToString();
                        Justification.Text = objProgram.drData["Justification"].ToString();
                    }
                    objProgram.drData.Close();
                    objProgram.strSql = "select agree,remarks,user_full_name from t_item_deletion_remarks_AP2 where item_deletion_id = " + RNumber.Text;
                    objProgram.drData = objProgram.gRetrieveRecord(objProgram.strSql);
                    gridview2.DataSource = objProgram.drData;
                    gridview2.DataBind();
                    objProgram.drData.Close();
                }
            }
            catch (Exception exp)
            {

            }
            finally
            {

            }
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string RiyadhMale = null;
            string RiyadhFemale = null;
            string JeddahMale = null;
            string JeddahFemale = null;
            string AhsaMale = null;
            string AhsaFemale =null;
            try
            {
                objProgram.strSql = "SELECT * FROM t_item_deletion WHERE id = " + RNumber.Text;
                objProgram.drData = objProgram.gRetrieveRecord(objProgram.strSql);
                if(objProgram.drData.Read())
                {
                     RiyadhMale = objProgram.drData["RM"].ToString();
                     RiyadhFemale = objProgram.drData["RF"].ToString();
                     JeddahMale = objProgram.drData["JM"].ToString();
                     JeddahFemale = objProgram.drData["JF"].ToString();
                     AhsaMale = objProgram.drData["AM"].ToString();
                     AhsaFemale = objProgram.drData["AF"].ToString();
                }
                objProgram.drData.Close();
                string strItemDeletionId = string.Empty;

                if (Session["requestnumber"] != null && Session["requestnumber"].ToString().Length > 0)
                {
                    strItemDeletionId = Session["requestnumber"].ToString();
                }

                objProgram.Add("item_deletion_id", strItemDeletionId, "I");
                objProgram.Add("user_id", lblUserId.Text, "I");

                if (radAgree.Checked)
                {
                    objProgram.Add("agree", "Yes", "S");
                    string strToEmail = "tajuddinr@ksau-hs.edu.sa"; 
                    string strEmailSubject = "ITEM DELETION APPROVED";
                    string strEmailBody = "Dears, <br> The ITEM DELETION : <br><b>Request #: "
                    + RNumber.Text + "<br>Request Date and Time: </b>" + requestdate.Text + "<br><b> Course Code: </b>" 
                    + courcecode.Text + "<br> <b>Course Name : </b>" + courseName.Text
                    + "<br> <b>Exam Type: </b>" + xamtype.Text + "<br><b>Exam Date and Time: </b>" + getdate.Text
                    + "<br><b> Has been APPROVED for :</b>" +"Question # : " + Questionid.Text + "<br> <b>The Question: </b>" + Q.Text 
                    + "<br>Kindly  take out the mention question from the marking process. And finalize marking the exam.<br> Thank you. ";
                    objProgram.SendMail("", strToEmail, strEmailSubject, strEmailBody); // this for AU
                    strEmailBody = "Dears, <br> The ITEM DELETION : <br><b>Request #: "
                    + RNumber.Text + "<br>Request Date and Time: </b>" + requestdate.Text + "<br><b> Course Code: </b>"
                    + courcecode.Text + "<br> <b>Course Name : </b>" + courseName.Text
                    + "<br> <b>Exam Type: </b>" + xamtype.Text + "<br><b>Exam Date and Time: </b>" + getdate.Text
                    + "<br><b> Has been APPROVED for :</b>" +"Question # : </b>" + Questionid.Text + "<br> <b>The Question: </b>" + Q.Text
                    + "<br>This is for your information.<br>Thank you.";
                    objProgram.SendMail("", "jefferya@ksau-hs.edu.sa", strEmailSubject, strEmailBody); // this for the others
                    objProgram.SendMail("", "hazmias@ksau-hs.edu.sa", strEmailSubject, strEmailBody);
                    objProgram.SendMail("", "aldhubaibann@ksau-hs.edu.sa", strEmailSubject, strEmailBody);
                    objProgram.SendMail("", RiyadhMale, strEmailSubject, strEmailBody);
                    objProgram.SendMail("", RiyadhFemale, strEmailSubject, strEmailBody);
                    objProgram.SendMail("", JeddahMale, strEmailSubject, strEmailBody);
                    objProgram.SendMail("", JeddahFemale, strEmailSubject, strEmailBody);
                    objProgram.SendMail("", AhsaMale, strEmailSubject, strEmailBody);
                    objProgram.SendMail("", AhsaFemale, strEmailSubject, strEmailBody);


                }
                else if (radDisagree.Checked)
                {
                    objProgram.Add("agree", "No", "S");
                    string strToEmail = "tajuddinr@ksau-hs.edu.sa"; //assismet unit
                    string strEmailSubject = "ITEM DELETION REJUCTED";
                    string strEmailBody = "Dears, <br> The ITEM DELETION : <br><b>Request #: "
                    + RNumber.Text + "<br>Request Date and Time: </b>" + requestdate.Text + "<br><b> Course Code: </b>"
                    + courcecode.Text + "<br> <b>Course Name : </b>" + courseName.Text
                    + "<br> <b>Exam Type: </b>" + xamtype.Text + "<br><b>Exam Date and Time: </b>" + getdate.Text
                    + "<br><b>Has been REJUCTED.</b><br>Kindly continue the marking process for this exam.<br> Thank you. ";
                    objProgram.SendMail("", strToEmail, strEmailSubject, strEmailBody); // this for AU
                    strEmailBody = "Dears, <br> The ITEM DELETION : <br><b>Request #: "
                    + RNumber.Text + "<br>Request Date and Time: </b>" + requestdate.Text + "<br><b> Course Code: </b>"
                    + courcecode.Text + "<br> <b>Course Name : </b>" + courseName.Text
                    + "<br> <b>Exam Type: </b>" + xamtype.Text + "<br><b>Exam Date and Time: </b>" + getdate.Text
                    + "<br><b>Has been REJUCTED.</b> <br>This is for your information.<br>Thank you.";
                    objProgram.SendMail("", "jefferya@ksau-hs.edu.sa", strEmailSubject, strEmailBody); // this for the others
                    objProgram.SendMail("", "hazmias@ksau-hs.edu.sa", strEmailSubject, strEmailBody);
                    objProgram.SendMail("", "aldhubaibann@ksau-hs.edu.sa", strEmailSubject, strEmailBody);
                    objProgram.SendMail("", RiyadhMale, strEmailSubject, strEmailBody);
                    objProgram.SendMail("", RiyadhFemale, strEmailSubject, strEmailBody);
                    objProgram.SendMail("", JeddahMale, strEmailSubject, strEmailBody);
                    objProgram.SendMail("", JeddahFemale, strEmailSubject, strEmailBody);
                    objProgram.SendMail("", AhsaMale, strEmailSubject, strEmailBody);
                    objProgram.SendMail("", AhsaFemale, strEmailSubject, strEmailBody);
                }
                objProgram.Add("user_full_name", lblUserName.Text, "S");
                objProgram.Add("remarks", remark.Text.Trim(), "S");
                objProgram.InsertRecordStatement("t_item_deletion_remarks");
                remark.Text = "";

                Response.Redirect("sent.aspx", true);
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