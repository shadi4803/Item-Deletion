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
using DocumentFormat.OpenXml.Drawing.Charts;

namespace NCAAA
{
    public partial class addean : System.Web.UI.Page
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
                            Justification.Text = objProgram.drData["Justification"].ToString();
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
                string people = "1";
                string currentnumberofpeople = "";
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
                }
                else if (radDisagree.Checked)
                {
                    objProgram.Add("agree", "No", "S");
                }
                objProgram.Add("user_full_name", lblUserName.Text, "S");
                objProgram.Add("remarks", remark.Text.Trim(), "S");
                objProgram.InsertRecordStatement("t_item_deletion_remarks_AP2");
                remark.Text = "";
                objProgram.strSql = "SELECT COUNT(*) FROM t_item_deletion_remarks_AP2 where item_deletion_id =" + RNumber.Text;
                objProgram.drData = objProgram.gRetrieveRecord(objProgram.strSql);
                if (objProgram.drData.Read())
                {
                    currentnumberofpeople = objProgram.drData[""].ToString();
                }
                objProgram.drData.Close();
                int p = Convert.ToInt32(people);
                int cp = Convert.ToInt32(currentnumberofpeople);
                if (p == cp)
                {
                    string strToEmail = "aldhubaibann@ksau-hs.edu.sa";
                    string strEmailSubject = "ITEM DELETION";
                    string strEmailBody = "Dears, <br> An ITEM DELETION has been requested: <br><b>Request #: "
                    + RNumber.Text + "<br>Request Date and Time: </b>" + requestdate.Text + "<br><b> Course Code: </b>" + courcecode.Text + "<br> <b>Course Name : </b>" + courseName.Text
                    + "<br> <b>Exam Type: </b>" + xamtype.Text + "<br><b>Exam Date and Time: </b>" + getdate.Text
                    + "<br> Please follow the <a href='http://aysar.ksau-hs.edu.sa/'>link</a> for your action. Your prompt feedback is highly required.  <br> Thank you."; 
                    objProgram.SendMail("", strToEmail, strEmailSubject, strEmailBody);
                    
                    objProgram.strSql = "UPDATE t_item_deletion SET status = 'Dean' WHERE id =" + RNumber.Text;
                    objProgram.gDeleteRecord(objProgram.strSql, "NT");
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