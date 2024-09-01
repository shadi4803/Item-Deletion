using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NCAAA
{
    public partial class WebForm102 : System.Web.UI.Page
    {
        DatabaseClass.Program objProgram = new DatabaseClass.Program();

        protected void Page_Load(object sender, EventArgs e)
        {

        }
     
        protected void btnSearch_Clicked(object sender, EventArgs e)
        {

            objProgram.strSql = "SELECT * FROM t_item_deletion";
            objProgram.drData = objProgram.gRetrieveRecord(objProgram.strSql);
            
                gridview1.DataSource = objProgram.drData;
                gridview1.DataBind();
            objProgram.drData.Close();
            gridview1.Visible = true;
            btnSave.Visible = false;
            btnreset.Visible = true;


        }
        protected void btnreset_Clicked(object sender, EventArgs e)
        {
            Response.Redirect("Item_Deletion_Admin_Menu.aspx", true);
        }

        protected void gridview1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                int RowIndex = 0;
                Label lblTemp = null;

                GridViewRow gvr = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);
                RowIndex = gvr.RowIndex;

                lblTemp = (Label)gridview1.Rows[RowIndex].FindControl("lblId");

                if (lblTemp != null)
                {
                    Session["RequestId"] = lblTemp.Text;
                    Response.Redirect("Approval.aspx", true);

                }



            }
            catch (Exception exp)
            {

            }
            finally
            {

            }
        }

        protected void btnCreateUsers_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("~/Admin_User_Master.aspx",true);
            }
            catch(Exception ex)
            {

            }
            finally
            {

            }
        }
    }
}