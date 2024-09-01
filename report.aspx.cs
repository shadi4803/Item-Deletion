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
using DocumentFormat.OpenXml.Spreadsheet;

namespace NCAAA
{
    public partial class report : System.Web.UI.Page
    {

        DatabaseClass.Program objProgram = new DatabaseClass.Program();
        protected void Page_Load(object sender, EventArgs e)
        {

            try
            {
                if (!IsPostBack)
                {
                    objProgram.gCheckUserInSession(lblUserId);
                    objProgram.gCheckUserType(lblUserType);
                }
               
            }
            catch(Exception ex)
            {

            }
            finally
            {

            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string lblTemp = null;
            string userid = lblUserId.Text;
            try
            {
               
                lblTemp = requestnumber.Text;
                if (requestnumber.Text.Trim().Length > 0)
                {
                    if (lblUserType.Text.ToUpper().Equals("U-DELL1"))
                    {
                        if (!mCheckDateConstraint(requestnumber.Text.Trim()))
                        {
                            AlreadySubmited.Text = "The maximum number of allowed days to edit this item has been passed.";
                            AlreadySubmited.Visible = true;
                            return;
                        }
                    }
                    else if (lblUserType.Text.ToUpper().Equals("U-DELL2"))
                    {
                        if (!mCheckDateConstraintAP2(requestnumber.Text.Trim()))
                        {
                            AlreadySubmited.Text = "The maximum number of allowed days to edit this item has been passed.";
                            AlreadySubmited.Visible = true;
                            return;
                        }
                    }
                    else if (lblUserType.Text.ToUpper().Equals("U-DELL3"))
                    {
                        if (!mCheckDateConstraintAP3(requestnumber.Text.Trim()))
                        {
                            AlreadySubmited.Text = "The maximum number of allowed days to edit this item has been passed.";
                            AlreadySubmited.Visible = true;
                            return;
                        }
                    }
                    objProgram.strSql = "SELECT * FROM t_item_deletion WHERE id = " + requestnumber.Text;
                    objProgram.drData = objProgram.gRetrieveRecord(objProgram.strSql);
                    if (objProgram.drData.Read()) {
                        objProgram.drData.Close();
                        objProgram.strSql = "SELECT user_id,item_deletion_id from t_item_deletion_remarks where user_id = " + userid +" and item_deletion_id ="+ requestnumber.Text; 
                        objProgram.drData = objProgram.gRetrieveRecord(objProgram.strSql);
                        if(objProgram.drData.Read())
                        {
                            string Check = objProgram.drData["user_id"].ToString();// check if user is already submitted
                            if (Check == userid)
                            {
                                AlreadySubmited.Visible = true;
                            }
                        }
                        else
                        {
                            Session["requestnumber"] = lblTemp;
                            if (lblUserType.Text.ToUpper().Equals("U-DELL1"))
                            {
                                Session["UserId"] = lblUserId.Text;
                                Response.Redirect("Approval.aspx", true);
                            }
                            else if (lblUserType.Text.ToUpper().Equals("U-DELL2"))
                            {
                                Session["UserId"] = lblUserId.Text;
                                Response.Redirect("addean.aspx", true);
                            }
                            else if (lblUserType.Text.ToUpper().Equals("U-DELL3"))
                            {
                                Session["UserId"] = lblUserId.Text;
                                Response.Redirect("deans.aspx", true);
                            }
                        }

                    }
                    else
                    {
                        Invalid.Visible = true;
                    }



                }
                
            }
            catch(Exception ex)
            {

            }
            finally
            {

            }
        }
        private bool mCheckDateConstraint(string strItemId)
        {
            bool blnResult = true;
            DateTime dtItemCreatedDate = DateTime.Now;
            DateTime dtItemApprovalDateLimit = DateTime.Now;
            int intDifferenceOfDays = 0;
            try
            {
                objProgram.strSql = "SELECT exam_type, request_date FROM t_item_deletion WHERE id = " + strItemId;
                objProgram.drData = objProgram.gRetrieveRecord(objProgram.strSql);
                if (objProgram.drData.Read())
                {
                    if (objProgram.drData["exam_type"] != null && objProgram.drData["exam_type"].ToString().Length>0 && objProgram.drData["exam_type"].ToString().ToUpper().Equals("MID"))
                    {
                        dtItemCreatedDate = Convert.ToDateTime(objProgram.drData["request_date"].ToString());
                        dtItemApprovalDateLimit = dtItemCreatedDate.AddDays(1);

                        intDifferenceOfDays = DateTime.Now.Subtract(dtItemApprovalDateLimit).Days;

                        if (intDifferenceOfDays > 0) blnResult = false;

                    }
                    else if (objProgram.drData["exam_type"] != null && objProgram.drData["exam_type"].ToString().Length > 0 && objProgram.drData["exam_type"].ToString().ToUpper().Equals("FINAL"))
                    {
                        dtItemCreatedDate = Convert.ToDateTime(objProgram.drData["request_date"].ToString());
                        dtItemApprovalDateLimit = dtItemCreatedDate.AddHours(1);

                        intDifferenceOfDays = DateTime.Now.Subtract(dtItemApprovalDateLimit).Days;

                        if (intDifferenceOfDays > 0) blnResult = false;
                    }

                    


                }
                objProgram.drData.Close();

                return blnResult;
                // return true;
            }
            catch (Exception exp) 
            {
                return false;
            }
            finally
            {

            }

        }
        private bool mCheckDateConstraintAP2(string strItemId)
        {
            bool blnResult = true;
            DateTime dtItemCreatedDate = DateTime.Now;
            DateTime dtItemApprovalDateLimit = DateTime.Now;
            int intDifferenceOfDays = 0;
            try
            {
                objProgram.strSql = "SELECT exam_type, request_date FROM t_item_deletion WHERE id = " + strItemId;
                objProgram.drData = objProgram.gRetrieveRecord(objProgram.strSql);
                if (objProgram.drData.Read())
                {
                    if (objProgram.drData["exam_type"] != null && objProgram.drData["exam_type"].ToString().Length > 0 && objProgram.drData["exam_type"].ToString().ToUpper().Equals("MID"))
                    {
                        dtItemCreatedDate = Convert.ToDateTime(objProgram.drData["request_date"].ToString());
                        dtItemApprovalDateLimit = dtItemCreatedDate.AddDays(2);

                        intDifferenceOfDays = DateTime.Now.Subtract(dtItemApprovalDateLimit).Days;

                        if (intDifferenceOfDays > 0) blnResult = false;

                    }
                    else if (objProgram.drData["exam_type"] != null && objProgram.drData["exam_type"].ToString().Length > 0 && objProgram.drData["exam_type"].ToString().ToUpper().Equals("FINAL"))
                    {
                        dtItemCreatedDate = Convert.ToDateTime(objProgram.drData["request_date"].ToString());
                        dtItemApprovalDateLimit = dtItemCreatedDate.AddHours(2);

                        intDifferenceOfDays = DateTime.Now.Subtract(dtItemApprovalDateLimit).Days;

                        if (intDifferenceOfDays > 0) blnResult = false;
                    }




                }
                objProgram.drData.Close();

                return blnResult;
                //return true;
            }
            catch (Exception exp)
            {
                return false;
            }
            finally
            {

            }

        }
        private bool mCheckDateConstraintAP3(string strItemId)
        {
            bool blnResult = true;
            DateTime dtItemCreatedDate = DateTime.Now;
            DateTime dtItemApprovalDateLimit = DateTime.Now;
            int intDifferenceOfDays = 0;
            try
            {
                objProgram.strSql = "SELECT exam_type, request_date FROM t_item_deletion WHERE id = " + strItemId;
                objProgram.drData = objProgram.gRetrieveRecord(objProgram.strSql);
                if (objProgram.drData.Read())
                {
                    if (objProgram.drData["exam_type"] != null && objProgram.drData["exam_type"].ToString().Length > 0 && objProgram.drData["exam_type"].ToString().ToUpper().Equals("MID"))
                    {
                        dtItemCreatedDate = Convert.ToDateTime(objProgram.drData["request_date"].ToString());
                        dtItemApprovalDateLimit = dtItemCreatedDate.AddDays(3);

                        intDifferenceOfDays = DateTime.Now.Subtract(dtItemApprovalDateLimit).Days;

                        if (intDifferenceOfDays > 0) blnResult = false;

                    }
                    else if (objProgram.drData["exam_type"] != null && objProgram.drData["exam_type"].ToString().Length > 0 && objProgram.drData["exam_type"].ToString().ToUpper().Equals("FINAL"))
                    {
                        dtItemCreatedDate = Convert.ToDateTime(objProgram.drData["request_date"].ToString());
                        dtItemApprovalDateLimit = dtItemCreatedDate.AddHours(3);

                        intDifferenceOfDays = DateTime.Now.Subtract(dtItemApprovalDateLimit).Days;

                        if (intDifferenceOfDays > 0) blnResult = false;
                    }




                }
                objProgram.drData.Close();

                return blnResult;
                //return true;
            }
            catch (Exception exp)
            {
                return false;
            }
            finally
            {

            }

        }
    }

}