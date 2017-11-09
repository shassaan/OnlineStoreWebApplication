using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace OnlineStoreWebApplication
{
    public partial class CustomerGalleryWebForm : System.Web.UI.Page
    {
        ConnectionClass cc = new ConnectionClass();
        DataTable dt = null;
        String Query = "";
        SqlDataReader sdr = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            cc.ConOpen();
            if(!IsPostBack)
            {
                String Query = "select distinct Gender from Customer";
                sdr = cc.DisplayInfo(Query);
                while (sdr.Read())
                {
                    GenderDropDownList.Items.Add(sdr["Gender"].ToString());
                }
            }
        }

        protected void FillDropDownList(DropDownList inst)
        {
            try
            {

                String Query = "select distinct Gender from Customer";
                dt = cc.GetData(Query);
                inst.DataValueField = "type_id";
                inst.DataTextField = "name";
                inst.DataSource = dt;
                inst.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }
        protected void DisplayButton_Click(object sender, EventArgs e)
        {
            try
            {
                PopulateDataList();
            }
            catch (Exception err)
            {
                Response.Write("<script>alert('" + err.Message + "');</script>");
            }
        }
        protected void PopulateDataList()
        {   //ImagePath , Cust_id
            Query = "select * from Customer where Gender = '"+GenderDropDownList.SelectedItem.Value+"'";
            dt = cc.GetData(Query);
            if(dt.Rows.Count == 0)
            {
               ErrorLabel.Visible = true;
               ErrorLabel.Text = "No Data Available";
            }
            else
            {
                ErrorLabel.Visible = false;
                ErrorLabel.Text = "";
                ImageDataList.DataSource = dt;
                ImageDataList.DataBind();
            }
        }

        protected void ImageDataList_ItemCommand(object source, DataListCommandEventArgs e)
        {
            IdLabel.Text = e.CommandArgument.ToString();
        }

        protected void SearchButton_Click(object sender, EventArgs e)
        {
            Query = "select F_name+' '+L_name as FullName , Email from Customer where Cust_id='" + IdLabel.Text + "'";
            sdr = cc.DisplayInfo(Query);
            while(sdr.Read())
            {
                FNLabel.Text = sdr["FullName"].ToString();
                EmailLabel.Text = sdr["Email"].ToString();
            }
        }

    }
}