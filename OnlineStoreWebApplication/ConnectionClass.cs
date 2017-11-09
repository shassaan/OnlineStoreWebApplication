using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace OnlineStoreWebApplication
{
    public class ConnectionClass
    {
        static string ConString = @"Data Source=DESKTOP-MU3GCIK\SQLEXPRESS;Initial Catalog=OLOS;Integrated Security=True";
        SqlConnection ConObj = new SqlConnection(ConString);
        SqlCommand Cmd = null;
        SqlDataAdapter Sda = null;
        DataTable Dt = null;
        SqlDataReader sdr = null;
        public void ConOpen()
        {
            if(ConObj.State == ConnectionState.Closed)
            ConObj.Open();
        }

        public void ConClose()
        {
            if (ConObj.State == ConnectionState.Open)
                ConObj.Close();
        }

        public void InsertUpdateDelete(String Query)
        {
            Cmd = new SqlCommand(Query, ConObj);
            Cmd.ExecuteNonQuery();
        }

        public DataTable GetData(String Query)
        {
            Dt = new DataTable();
            Sda = new SqlDataAdapter(Query , ConObj);
            Sda.Fill(Dt);
            return Dt;
        }

        public Boolean Verify(String Query)
        {
            Cmd = new SqlCommand(Query , ConObj);
            sdr = Cmd.ExecuteReader();
            if (sdr.HasRows == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public SqlDataReader DisplayInfo(String Query)
        {
            Cmd = new SqlCommand(Query, ConObj);
            sdr = Cmd.ExecuteReader();
            return sdr;
        }
    }
}












