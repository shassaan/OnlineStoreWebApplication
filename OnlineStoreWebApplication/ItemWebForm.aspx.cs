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
    public partial class ItemWebForm : System.Web.UI.Page
    {
        ConnectionClass cc = new ConnectionClass();
        ValidationClass Vc = new ValidationClass();
        DataTable dt = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            cc.ConOpen();
            if (!IsPostBack)
            {

                FillDropDownList(TypeDropDownList);
                
            }
        }

        protected void FillDropDownList(DropDownList inst)
        {
            try
            {

                String Query = "select type_id , name from ItemType";
                dt = cc.GetData(Query);
                TypeDropDownList.DataValueField = "type_id";
                TypeDropDownList.DataTextField = "name";
                TypeDropDownList.DataSource = dt;
                TypeDropDownList.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }

        protected void send(String ItemType, String Item_id, String Wieght, String UnitPrice)
        {
            try
            {
                String Query = "INSERT INTO Items (Type_id , Item_Id , Quantity , Price) VALUES ('" + ItemType + "' , '" + Item_id + "' , '" + Wieght + "' , '" + UnitPrice + "')";
                cc.InsertUpdateDelete(Query);
                Response.Write("<script>alert('Data Saved!!');</script>");
            }
            catch (Exception ex)
            {

                Response.Write("<script>alert('Something WEnt Wrong!!');</script>");
            }
        }



        protected void InsertItemButton_Click(object sender, EventArgs e)
        {
            if(TypeDropDownList.SelectedIndex.Equals(0))
            {
                Response.Write("<script>alert('Select The Valid Item');</script>");
            }
            else
            {
                send(TypeDropDownList.SelectedItem.Value, ItemIdTextBox.Text, WieghtSizeTextBox.Text, UnitPriceTextBox.Text);
            }
        }
    }
}