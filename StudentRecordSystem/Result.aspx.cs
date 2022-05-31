using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Text;

namespace StudentRecordSystem
{
    public partial class WebForm9 : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["MGMTDB"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                DropListDataBind();
            }
        }

        protected void Submit_Click(object sender, EventArgs e)
        {
            LoadSubject();
            GetResult();
        }

        void LoadSubject()
        {
           
            StringBuilder sb = new StringBuilder();
            SqlConnection con = new SqlConnection(strcon);
            con.Open();
            SqlCommand com = new SqlCommand("MGMTSP",con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@Flag", "ShowSubject");
            com.Parameters.AddWithValue("@AName",DrpListId.SelectedValue);
            SqlDataReader dr = com.ExecuteReader();
            if(dr.HasRows)
            {
                while(dr.Read())
                {
                    sb.Append("<hr>");
                    sb.Append("<form>");
                    sb.Append("<div class='col-md-3'>");
                    sb.Append("<label class='form-label'>"+dr[1]+"</label><input type='text' id='txt1' class='form-control'/>");
                    sb.Append("<label class='form-label'>"+dr[2]+"</label><input type='text' id='txt2' class='form-control'/>");
                    sb.Append("<label class='form-label'>"+dr[3]+"</label><input type='text' id='txt3' class='form-control'/>");
                    sb.Append("<label class='form-label'>"+dr[4]+"</label><input type='text' id='txt4' class='form-control'/>");
                    sb.Append("</div>");
                    sb.Append("<input type='button' value='submit' runat='server' id='submitBtn' class='btn btn-outline-danger mt-3'>");
                    sb.Append("</form>");
                    PanelId.Controls.Add(new Literal { Text = sb.ToString() });
                }
            }
            dr.Close();
            con.Close();         
        }

        void GetResult()
        {
            SqlConnection con = null;
            try
            {               
               using(con = new SqlConnection(strcon))
                {
                    con.Open();
                    SqlCommand com = new SqlCommand("MGMTSP", con);
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.AddWithValue("@Flag","InsertResult");
                    com.Parameters.AddWithValue("@Sub1","");
                }

            }
            catch(Exception ex)
            {
                Response.Write("<script>alert('"+ex.Message+"')</script>");
            }
            finally
            {
                con.Close();
            }
        }

        void DropListDataBind()
        {
            SqlConnection con = new SqlConnection(strcon);
            SqlDataAdapter sda = new SqlDataAdapter("MGMTSP", con);
            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
            sda.SelectCommand.Parameters.AddWithValue("@Flag", "DropDownBind");
            DataTable data = new DataTable();
            sda.Fill(data);
            DrpListId.DataSource = data;
            DrpListId.DataTextField = "CourseName";
            DrpListId.DataValueField = "Id";
            DrpListId.DataBind();
        }
    }
}