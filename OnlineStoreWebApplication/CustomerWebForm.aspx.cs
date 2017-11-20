using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace OnlineStoreWebApplication
{
    public partial class CustomerWebForm : System.Web.UI.Page
    {
        String FileName = "";
        char gender = 'M';
        SqlDataReader sdr = null;
        String[] SplittedEmail = new String[2];
        ConnectionClass cc = new ConnectionClass();
        ValidationClass vc = new ValidationClass();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                cc.ConOpen();
            }
            catch (Exception er)
            {
                Response.Write("<script>alert('Not Connecting To Database Server!!');</script>");
            }
        }

        protected void LoginButton_Click(object sender, EventArgs e)
        {
            String query = "select * from Customer where Cust_id = '"+UserIdTextBox.Text+"' AND Pasword = '"+PasswordLoginTextBox.Text+"'";
            if(cc.Verify(query))
            {
                Response.Redirect("OrderWebform.aspx?c_id="+UserIdTextBox.Text+"");
            }
            else
            {
                Response.Write("<script>alert('Invalid Username Or Password');</script>");
            }
            cc.ConClose();
        }
        protected void SignupButton_Click(object sender, EventArgs e)
        {

            try
            {
                String cus_id = "";
                cus_id = GenerateId(EmailTextBox.Text);
                if (PaswordMatched(PasswordTextBox.Text, ConfirmPasswordTextBox.Text) && HaveStandardLength() && EmailIsValid())
                {
                    DecideGender();//it will check that which radio btn is selected
                    String path = UploadImage(cus_id);// it will upload the image to server and return the path of that image
                    if(path == "")
                    {
                        throw new Exception("Content You are Uploading Is Very Big In Size");
                    }
                    send(cus_id, FirstNameTextBox.Text, LastNameTextBox.Text, gender, EmailTextBox.Text, ConfirmPasswordTextBox.Text , path);
                    WaitForIdLabel.Text = "Your Login Id Is : " + cus_id;
                }
                else
                {
                    throw new Exception("Data You Entered is not Valid!!");
                }
            }
            catch (Exception err)
            {
                Response.Write("<script>alert('"+err.Message+"');</script>");
            }
        }
        protected String GenerateId(String Email)
        {
            SplittedEmail = Email.Split('@');
            return SplittedEmail[0];
        }


        protected void send(String Cus_id, String F_name, String L_name, char Gender, String Email, String Pasword , String Path)
        {
            try
            {
                String Query = "INSERT INTO Customer (Cust_id , F_name , L_name , Gender , Email , Pasword , ImagePath) VALUES ('" + Cus_id + "' , '" + F_name + "' , '" + L_name + "' , '" + Gender + "' , '" + Email + "' , '" + Pasword + "', '"+Path+"')";
                cc.InsertUpdateDelete(Query);
                cc.ConClose();
                Response.Write("<script>alert('Thankyou! You are Registered Succesfully!!');</script>");
            }
            catch (Exception ex)
            {

                Response.Write("<script>alert('Something WEnt Wrong!!');</script>");
            }
        }

        protected Boolean PaswordMatched(String Password, String ConfirmPassword)
        {
            if (Password.Equals(ConfirmPassword))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        protected void RdBtnM_CheckedChanged(object sender, EventArgs e)
        {
            if (RdBtnM.Checked == true)
            {
                RdBtnF.Checked = false;
            }
        }

        protected void DecideGender()
        {
            if (RdBtnM.Checked == true)
            {
                gender = 'M';
            }
            else
            {
                gender = 'F';
            }
        }

        protected Boolean EmailIsValid()
        {
            if (SplittedEmail[1].Equals("gmail.com"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        protected Boolean HaveStandardLength()
        {
            if(PasswordTextBox.Text.Length > 8)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        protected String UploadImage(String Cus_id)
        {
            FileName = Path.GetFileName(ImageFileUpload.PostedFile.FileName);
            if(ImageFileUpload.PostedFile.ContentLength  < 300000)
            {//succes
                String at = FileName.Split('.')[1];
                String path = "~/Images/" + Cus_id + "." + at;
                ImageFileUpload.PostedFile.SaveAs(Server.MapPath(path));
                this.CustomerImage.ImageUrl = path;
                return path;
            }
            else
            {//failed
                return "";
            }
        }
    }
}