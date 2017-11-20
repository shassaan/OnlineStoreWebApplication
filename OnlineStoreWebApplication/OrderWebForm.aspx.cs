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
    public partial class OrderWebForm : System.Web.UI.Page
    {
        DataTable dt = new DataTable();
        ConnectionClass cc = new ConnectionClass();
        SqlDataReader Sdr = null;
        String Query = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            cc.ConOpen();
            if (Request.QueryString["c_id"].ToString() != null)
            {
                UseridLabel.Text = "Welcome " + Request.QueryString["c_id"].ToString();
            }
            if (!IsPostBack)
           {
                FillDropDownList();
           }
            
        }

        protected void FillDropDownList()
        {
            try
            {

                Query = "select type_id , name from ItemType";
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

        protected void SearchItems_Click(object sender, EventArgs e)
        {
            try
            {
                Query = "select ItemType.name , Items.Quantity , Items.Price ,Items.Item_id, ItemType.ImagePath from ItemType INNER JOIN Items ON ItemType.type_id = Items.Type_id AND Items.Type_id = '"+TypeDropDownList.SelectedItem.Value+"'";
                dt = cc.GetData(Query);
                ItemsDataList.DataSource = dt;
                ItemsDataList.DataBind();
            }
            catch(Exception ex)
            {
                Response.Write(ex.Message);
            }
        }
        

        protected void ItemsDataList_ItemCommand(object source, DataListCommandEventArgs e)
        {
            try
            {
                ItemIdLabel.Text = e.CommandArgument.ToString();
                Query = "select * from Items where Item_id = '"+e.CommandArgument.ToString()+"'";
                Sdr = cc.GetDataSdr(Query);
                while(Sdr.Read())
                {
                    ItemWeightLabel.Text = Sdr["Quantity"].ToString();
                    PriceLabel.Text = Sdr["Price"].ToString();
                }
            }
            catch(Exception ex)
            {
                Response.Write(ex.Message);
            }

        }

        protected void BuyButton_Click(object sender, EventArgs e)
        {
            try
            {
                TotalPriceLabel.Text = float.Parse(PriceLabel.Text) * int.Parse(QuantitiTextBox.Text) + "";
                Query = "insert into CustomerOrder(Cust_id , Type_id,Item_id,Quantity,OrderDate,Bill,status) values('"+UseridLabel.Text.Split(' ')[1]+"' , '" + TypeDropDownList.SelectedItem.Value + "' , '" + ItemIdLabel.Text + "' , '" + QuantitiTextBox.Text + "' , '" + DateTime.Now.ToString() + "' , '" + TotalPriceLabel.Text + "' , '0')";
                cc.InsertUpdateDelete(Query);
                Response.Write("<script>alert('Your Order Is Recived And Waiting To Be Shipped')</script>");
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }

        }
    }
}