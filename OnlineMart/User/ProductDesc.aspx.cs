using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;

namespace OnlineMart.User
{
    public partial class ProductDesc : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\VINAYA SAMANVITA\source\repos\OnlineMart\OnlineMart\App_Data\Shopping.mdf;Integrated Security=True");
        int id,qty;
        string product_name, product_desc, product_price, product_qty, product_images;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["id"]==null)
            {
                Response.Redirect("DisplayItem.aspx");
            }
            else
            {
                id = Convert.ToInt32(Request.QueryString["id"].ToString());
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from Product where id="+id+"";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                d1.DataSource = dt;
                d1.DataBind();
                con.Close();
            }
            qty = get_qty(id);
            if(qty==0)
            {
                l2.Visible = false;
                t1.Visible = false;
                b1.Visible = false;
                l1.Text = "Currently Unavailable";

            }
        }

        protected void b1_Click(object sender,EventArgs e)
        {
            if(con.State==ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from Product where id="+id+" ";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            foreach(DataRow dr in dt.Rows)
            {
                product_name =dr["Product_name"].ToString();
                product_desc = dr["Product_desc"].ToString();
                product_price = dr["Product_price"].ToString();
                product_qty = dr["Product_qty"].ToString();
                product_images = dr["Product_images"].ToString();
            }
            //con.Close();

            if(Convert.ToInt32(t1.Text)> Convert.ToInt32(product_qty))
            {
                l1.Text = "Quanlity Unavailable";
                l1.ForeColor = Color.Red;
            }
            else
            {
                l1.Text = "Added Successfully";
                l1.ForeColor = Color.Green;
                if (Request.Cookies["aa"] == null)
                {
                    Response.Cookies["aa"].Value = product_name.ToString() + "," + product_desc.ToString() + "," + product_price.ToString() + "," + t1.Text.ToString() + "," + product_images.ToString() + "," + id.ToString();
                    Response.Cookies["aa"].Expires = DateTime.Now.AddDays(1);
                }
                else
                {
                    Response.Cookies["aa"].Value = Request.Cookies["aa"].Value + "|" + product_name.ToString() + "," + product_desc.ToString() + "," + product_price.ToString() + "," + t1.Text.ToString() + "," + id.ToString();
                    Response.Cookies["aa"].Expires = DateTime.Now.AddDays(1);
                }

                SqlCommand cmd1 = con.CreateCommand();
                cmd1.CommandType = CommandType.Text;
                //cmd1.CommandText = "update product set Product_qty=Product_qty-'"+t1.Text+ "'where Id='"+Convert.ToInt32(id.ToString())+"'";
                cmd1.CommandText = "update product set Product_qty=Product_qty-" + t1.Text + "where Id=" + id ;
                cmd1.ExecuteNonQuery();
                Response.Redirect("ProductDesc.aspx?id=" + id.ToString());
                l1.Text = "Added Successfully";
                l1.ForeColor = Color.Green;
            }

        }

        public int get_qty(int id)
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from Product where id=" + id + " ";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                qty = Convert.ToInt32(dr["Product_qty"].ToString());
            }

            return qty;
        }
    }
}