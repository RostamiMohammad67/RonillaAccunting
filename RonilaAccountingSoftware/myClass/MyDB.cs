using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

/// <summary>
/// Summary description for db
/// </summary>
namespace RonilaAccountingSoftware.myClass
{
    public class mydb
    {

        public string servername = "(local)";
        public string dbname = "";
        public string securitymodel = "trusted_connection=yes";
        SqlConnection conn = null;
        SqlCommand cmd = null;
        SqlDataAdapter da = null;

        public mydb()
        {
            conn = new SqlConnection();
            cmd = new SqlCommand();
            cmd.CommandTimeout = 0;
            da = new SqlDataAdapter();
            cmd.Connection = conn;
            da.SelectCommand = cmd;
        }

        public void connect()
        {

            if (conn.State != ConnectionState.Open)
            {
                string cs = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\RonilaDB.mdf;Integrated Security=True";
                conn.ConnectionString = cs;
                conn.Open();
            }
        }

     

        public void disconnect()
        {
            if (conn.State != ConnectionState.Closed)
            {
                conn.Close();
            }
        }

        public void docommand(string sql)
        {
            cmd.CommandText = sql;
            cmd.ExecuteNonQuery();
        }

        public DataTable select(string sql)
        {
            cmd.CommandText = sql;

            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        

        public string select_AsCount(string sql)
        {
            cmd.CommandText = sql;
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
                return dt.Rows[0][0].ToString();
            return "0";

        }

        public DataSet select2(string sql)
        {
            cmd.CommandText = sql;
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }
        public void docommand(string sql, string parameter, Byte[] file)
        {
            cmd.Parameters.Clear();
            SqlParameter param = cmd.Parameters.Add("@p1", SqlDbType.VarBinary);
            param.Value = file;
            cmd.CommandText = sql;
            cmd.ExecuteNonQuery();
        }

    

    }
}