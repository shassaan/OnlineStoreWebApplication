using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.IO;
namespace OnlineStoreWebApplication
{
    public partial class ItemTypeWebForm : System.Web.UI.Page
    {
        ConnectionClass cc = new ConnectionClass();
        ValidationClass Vc = new ValidationClass();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                cc.ConOpen();
            }
            catch (Exception er)
            {
                Response.Write("<script>alert('no connection')</script>");
            }
        }

        //-----------------------------------------------------

        public void Send(String TypeId , String ItemType , String ItemName , String path)
        {
            try
            {
                String Query = "INSERT INTO ItemType (type_id , type , name , ImagePath) VALUES ('"+TypeId+ "' , '" + ItemType + "' , '" + ItemName + "' , '"+path+"') ";
                cc.InsertUpdateDelete(Query);
                Response.Write("<script>alert('Data Saved !!')</script>");
            }
            catch(Exception e)
            {
                Response.Write("<script>alert('Something Went Wrong')</script>");
            }

        }


        protected void InsertItemTypeButton_Click(object sender, EventArgs e)
        {
            if(Vc.NotEmpty(ItemTypeIdTextBox) && Vc.NotEmpty(ItemTypeTextBox) && Vc.NotEmpty(ItemNameTextBox) && Vc.IntegerIsValid(ItemTypeIdTextBox))
            {
                try
                {
                    Send(ItemTypeIdTextBox.Text, ItemTypeTextBox.Text, ItemNameTextBox.Text,UploadImage(ItemTypeIdTextBox.Text));
                }
                catch(Exception er)
                {
                    Response.Write("<script>alert('Something Went Wrong')</script>");
                }
            }
            else
            {
                Response.Write("<script>alert('Fill Out All The Fields')</script>");
            }
        }

        protected String UploadImage(String id)
        {
            String FileName = Path.GetFileName(ImageFileUpload.PostedFile.FileName);
            if (ImageFileUpload.PostedFile.ContentLength < 300000)
            {//succes
                String at = FileName.Split('.')[1];
                String path = "~/Images/" + id + "." + at;
                ImageFileUpload.PostedFile.SaveAs(Server.MapPath(path));
                this.TypeImage.ImageUrl = path;
                return path;
            }
            else
            {//failed
                return "";
            }
        }
    }
}