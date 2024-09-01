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
using System.Data.SqlTypes;

namespace NCAAA
{
    public partial class Approval : System.Web.UI.Page
    {
        DatabaseClass.Program objProgram = new DatabaseClass.Program();
        DatabaseClass.Program objProgram2 = new DatabaseClass.Program();

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    objProgram.gCheckUserInSession(lblUserId);
                    objProgram.gCheckUserType(lblUserType);
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
                    objProgram.strSql = "SELECT * FROM t_item_deletion WHERE id = " + RNumber.Text;
                    objProgram.drData = objProgram.gRetrieveRecord(objProgram.strSql);
                    if (objProgram.drData.Read())
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
                        Justification.Text = objProgram.drData["Justification"].ToString() ;
                    }
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
            try
            {
                DateTime currentDateTime = DateTime.Now; // this for t_item_deletion_approval
                string formattedDateTime = currentDateTime.ToString("dddd, dd MMMM yyyy hh: mm tt"); // this for t_item_deletion_approval
                string strItemDeletionId = string.Empty;
                if (Session["requestnumber"]!=null && Session["requestnumber"].ToString().Length>0)
                {
                    strItemDeletionId = Session["requestnumber"].ToString();
                }

                objProgram.Add("item_deletion_id", strItemDeletionId, "I");
                objProgram.Add("user_id", lblUserId.Text, "I");

                if (radAgree.Checked)                 
                {
                    objProgram.Add("agree", "Yes", "S");
                }
                else if (radDisagree.Checked)
                {
                    objProgram.Add("agree", "No", "S");
                }
                objProgram.Add("user_full_name",lblUserName.Text, "S");
                objProgram.Add("UserType", lblUserType.Text, "S");
                objProgram.Add("remarks", remark.Text.Trim() , "S");
                remark.Text = "";
                objProgram.InsertRecordStatement("t_item_deletion_remarks");
                if (strItemDeletionId != null)
                {
                    objProgram2.Add("item_deletion_id", strItemDeletionId, "S");
                    objProgram2.Add("user_id", lblUserId.Text, "S");
                    objProgram2.Add("UserType", lblUserType.Text, "S");
                    objProgram2.InsertRecordStatement("t_item_deletion_approval");
                    string people = "";
                    string currentnumberofpeople = "";
                    objProgram.strSql = "SELECT COUNT(*) FROM t_item_deletion_approval where item_deletion_id =" + RNumber.Text;
                    objProgram.drData = objProgram.gRetrieveRecord(objProgram.strSql);
                    if(objProgram.drData.Read())
                    {
                        currentnumberofpeople = objProgram.drData[""].ToString();
                    }
                    objProgram.drData.Close();
                    objProgram.strSql = "SELECT number_of_people from t_item_deletion where id =" + RNumber.Text;
                    objProgram.drData = objProgram.gRetrieveRecord(objProgram.strSql);
                    if( objProgram.drData.Read())
                    {
                        people = objProgram.drData["number_of_people"].ToString();
                    }
                    objProgram.drData.Close();
                    int p = Convert.ToInt32(people);
                    int cp = Convert.ToInt32(currentnumberofpeople);
                    if (p == cp)
                    {
                        string strToEmail = "hazmias@ksau-hs.edu.sa";
                        string strEmailSubject = "ITEM DELETION";
                        string strEmailBody = "Dears, <br> An ITEM DELETION has been requested: <br><b>Request #: "
                    + RNumber.Text + "<br>Request Date and Time: </b>" + requestdate.Text + "<br><b> Course Code: </b>" + courcecode.Text + "<br> <b>Course Name : </b>" + courseName.Text
                    + "<br> <b>Exam Type: </b>" + xamtype.Text + "<br><b>Exam Date and Time: </b>" + getdate.Text
                    + "<br> Please follow the <a href='http://aysar.ksau-hs.edu.sa/'>link</a> for your action. Your prompt feedback is highly required.  <br> Thank you.";
                        objProgram.SendMail("", strToEmail, strEmailSubject, strEmailBody);
                        objProgram.strSql = "UPDATE t_item_deletion SET status = 'AP2' WHERE id =" + RNumber.Text;
                        objProgram.gDeleteRecord(objProgram.strSql, "NT");

                    }
                }


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