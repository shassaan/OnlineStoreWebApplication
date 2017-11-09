using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace OnlineStoreWebApplication
{
    public partial class ItemSearchWebForm : System.Web.UI.Page
    {
        ConnectionClass cc = new ConnectionClass();
        DataTable dt = new DataTable();
        String Query = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            cc.ConOpen();
            if(!IsPostBack)
            {
                FillDropDownList(ItemNameDropDownList);
            }
        }

        protected void FillDropDownList(DropDownList inst)
        {
            try
            {
                Query = "select  type_id , type  from ItemType";
                dt = cc.GetData(Query);
                inst.DataValueField = "type_id";
                inst.DataTextField = "type";
                inst.DataSource = dt;
                inst.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }

        protected void SearchItems()
        {
            if(ItemNameDropDownList.SelectedIndex.Equals(0))
            {
                ErrorLabel.Text = "Select The Valid Item";
                ErrorLabel.Visible = true;
            }
            else
            {
                Query = "select ItemType.name , Items.Quantity , Items.Price , ItemType.ImagePath from ItemType INNER JOIN Items ON ItemType.type_id = Items.Type_id AND Items.Type_id = '"+ItemNameDropDownList.SelectedItem.Value+"'";
                dt = cc.GetData(Query);
                if (dt.Rows.Count == 0)
                {
                    ErrorLabel.Visible = true;
                    ErrorLabel.Text = "No Data Available";
                    ItemsDataList.Visible = false;
                }
                else
                {
                    ErrorLabel.Visible = false;
                    ErrorLabel.Text = "";
                    ItemsDataList.Visible = true;
                    ItemsDataList.DataSource = dt;
                    ItemsDataList.DataBind();
                }
            }
        }

        protected void DisplayButton_Click(object sender, EventArgs e)
        {
            try
            {
                SearchItems();
            }
            catch(Exception er)
            {
                Response.Write("<script>alert('" + er.Message + "');</script>");
            }
        }
    }
}