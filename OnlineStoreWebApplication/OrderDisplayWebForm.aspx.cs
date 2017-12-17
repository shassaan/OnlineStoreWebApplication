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
    public partial class OrderDisplayWebForm : System.Web.UI.Page
    {
        ConnectionClass cc = new ConnectionClass();
        DataTable dt = new DataTable();
        String Query = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            cc.ConOpen();
        }

        protected void DisplayButton_Click(object sender, EventArgs e)
        {
            try
            {
                Query = "select Customer.Cust_id as Customer,ItemType.type as Category , ItemType.name as Item , CustomerOrder.OrderDate as Date , CustomerOrder.status as status from ItemType Inner Join CustomerOrder ON ItemType.type_id = CustomerOrder.Type_id inner Join Customer On Customer.Cust_id = CustomerOrder.Cust_id where CustomerOrder.OrderDate = '"+Calendar.SelectedDate.ToString().Split(' ')[0]+"'";
                dt = cc.GetData(Query);
                if(dt.Rows.Count > 0)
                {
                    OrdersGridView.DataSource = dt;
                    OrdersGridView.DataBind();
                }
                else
                {
                    throw new Exception("No Date Available");
                }
            }
            catch (Exception ex)
            {

                Response.Write("<script>alert('"+ex.Message+"')</script>");
            }
        }

        protected void OrdersGridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
           
        }
    }
}