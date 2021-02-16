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
    public partial class ViewCart : System.Web.UI.Page
    {
        string s;
        string t;
        string[] a = new string[6];
        int tot = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[7] { new DataColumn("Product_name"), new DataColumn("Product_desc"), new DataColumn("Product_price"), new DataColumn("Product_qty"), new DataColumn("Product_images"),new DataColumn("Id"), new DataColumn("Product_id") });

            if (Request.Cookies["aa"] != null)
            {
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
                    dt.Rows.Add(a[0].ToString(), a[1].ToString(), a[2].ToString(), a[3].ToString(), a[4].ToString(),i.ToString(),a[5].ToString());
                    tot = tot + (Convert.ToInt32(a[2].ToString())* Convert.ToInt32(a[3].ToString()));
                }
            }
            d1.DataSource = dt;
            d1.DataBind();
            if(tot==0)
            {
                l1.Text = "No Items in Cart";

            }
            else
            {
                l1.Text = "Total Cost:"+tot.ToString();
            }
            
        }

        protected void b1_Click1(object sender, EventArgs e)
        {
            Response.Redirect("Checkout.aspx");
        }
    }
}