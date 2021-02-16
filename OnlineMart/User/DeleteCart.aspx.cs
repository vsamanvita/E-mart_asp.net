using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace OnlineMart.User
{
    public partial class DeleteCart : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\VINAYA SAMANVITA\source\repos\OnlineMart\OnlineMart\App_Data\Shopping.mdf;Integrated Security=True");

        int id;
        string product_name, product_desc, product_price, product_qty, product_images;
        string s;
        string t;
        string[] a = new string[6];
        int count = 0;
        int product_id, qty;
        protected void Page_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[7] { new DataColumn("Product_name"), new DataColumn("Product_desc"), new DataColumn("Product_price"), new DataColumn("Product_qty"), new DataColumn("Product_images"), new DataColumn("Id"), new DataColumn("Product_id") });

            if (Request.Cookies["aa"] != null)
            {
                id = Convert.ToInt32(Request.QueryString["id"].ToString());
                s = Convert.ToString(Request.Cookies["aa"].Value);
                string[] strArr = s.Split('|');

                for (int i = 0; i < strArr.Length; i++)
                {
                    t = Convert.ToString(strArr[i].ToString());
                    string[] strArr1 = t.Split(',');
                    for (int j = 0; j < strArr1.Length; j++)
                    {
                        a[j] = strArr1[j].ToString();
                    }
                    dt.Rows.Add(a[0].ToString(), a[1].ToString(), a[2].ToString(), a[3].ToString(), a[4].ToString(), i.ToString(),a[5].ToString());
                }
            }

            count = 0;
            foreach(DataRow dr in dt.Rows)
            {
                if(count==id)
                {
                    product_id = Convert.ToInt32(dr["Product_id"].ToString());
                    qty = Convert.ToInt32(dr["Product_qty"].ToString());
                }
                count = count + 1;
            }
            count = 0;

            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "update product set Product_qty=Product_qty+"+qty+"where Id="+product_id;
            cmd.ExecuteNonQuery();
            con.Close();


            dt.Rows.RemoveAt(id);

            Response.Cookies["aa"].Expires = DateTime.Now.AddDays(-1);
            Response.Cookies["aa"].Expires = DateTime.Now.AddDays(-1);

            foreach (DataRow dr in dt.Rows)
            {
                product_name = dr["Product_name"].ToString();
                product_desc = dr["Product_desc"].ToString();
                product_price = dr["Product_price"].ToString();
                product_qty = dr["Product_qty"].ToString();
                product_images = dr["Product_images"].ToString();
                product_id = Convert.ToInt32(dr["Product_id"].ToString());

                count = count + 1;

                if (count == 1)
                {
                    Response.Cookies["aa"].Value = product_name.ToString() + "," + product_desc.ToString() + "," + product_price.ToString() + "," + product_qty.ToString() + "," + product_images.ToString() + "," + product_id.ToString();
                    Response.Cookies["aa"].Expires = DateTime.Now.AddDays(1);
                }
                else
                {
                    Response.Cookies["aa"].Value = Request.Cookies["aa"].Value + "|" + product_name.ToString() + "," + product_desc.ToString() + "," + product_price.ToString() + "," + product_qty.ToString() + "," + product_images.ToString() + "," + product_id.ToString();
                    Response.Cookies["aa"].Expires = DateTime.Now.AddDays(1);
                }
            }

            Response.Redirect("ViewCart.aspx");
        }
        
    }
}