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
using System.Net;
using DocumentFormat.OpenXml.Drawing;

namespace NCAAA
{
    public partial class WebForm107 : System.Web.UI.Page

    {
        DatabaseClass.Program objProgram = new DatabaseClass.Program();

        protected void Page_Load(object sender, EventArgs e)
        {
           
        }
        protected void btnSearch_Clicked(object sender, EventArgs e)
        {
            
            objProgram.strSql = "SELECT * FROM t_item_deletion";
            objProgram.drData = objProgram.gRetrieveRecord(objProgram.strSql);
            if (objProgram.drData.Read())
            {
                gridview1.DataSource = objProgram.drData;
                gridview1.DataBind();
                
            }
            objProgram.drData.Close();
            gridview1.Visible = true;
            gridview2.Visible = false;
            btnSave.Visible = false;
            btnsearch.Visible = false;
            btnreset.Visible = true;


        }

        protected void btnSearch_Clicked1(object sender, EventArgs e)
        {
            objProgram.strSql = "SELECT * FROM Users_ItemDeletion1";
            objProgram.drData = objProgram.gRetrieveRecord(objProgram.strSql);
            if (objProgram.drData.Read())
            {
                gridview2.DataSource = objProgram.drData;
                gridview2.DataBind();

            }
            objProgram.drData.Close();
            gridview2.Visible = true;
            gridview1.Visible = false;
            btnSave.Visible = false;
            btnsearch.Visible = false;
            btnreset.Visible = true;
        }

        protected void btnreset_Clicked(object sender, EventArgs e)
        {
            Response.Redirect("deletionAd.aspx", true);
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

                if(lblTemp!=null)
                {
                    Session["RequestId"] = lblTemp.Text;
                    Response.Redirect("Approval.aspx", true);

                }



            }
            catch(Exception exp)
            {

            }
            finally
            {

            }
        }
    }
}