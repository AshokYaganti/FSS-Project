using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Drawing;
using System.Web.UI.DataVisualization.Charting;

public partial class statistics : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["myconnectionstring"].ConnectionString);
    SqlCommand cmd;
    byte[] raw;
    protected void Page_Load(object sender, EventArgs e)
    {


        if (!(IsPostBack))
        {

            displayimage();

        }
        else { }
    }

    public DataSet BindDatatable()
    {
        DataSet ds = new DataSet();
        try
        {

            con.Open();
            SqlCommand cmd2 = new SqlCommand("sp_getpost", con);
            cmd2.CommandText = "sp_getpost";
            cmd2.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd2);
            da.Fill(ds);

        }
        catch (Exception e1)
        {
        }
        return ds;
    }

    protected void change_click(object sender, EventArgs e)
    {

        //Response.Redirect("wait.aspx");
        FileUpload1.Visible = true;
        Button3.Visible = true;
    }

    protected void Button3_Click(object sender, EventArgs e)
    {

        try
        {
            if ((FileUpload1.FileName != ""))
            {
                FileUpload1.Visible = false;
                Button3.Visible = false;
                //to allow only jpg gif and png files to be uploaded.
                string extension = Path.GetExtension(FileUpload1.PostedFile.FileName);
                if (((extension == ".jpg") || ((extension == ".gif") || (extension == ".png"))))
                {
                    string id = Convert.ToString(Session["username"]);

                    string fileName = Path.GetFileName(FileUpload1.PostedFile.FileName);

                    FileUpload1.PostedFile.SaveAs(Server.MapPath("~/pics/") + fileName);

                    FileStream fs = new FileStream(Server.MapPath("~/pics/") + fileName, FileMode.Open, FileAccess.ReadWrite, FileShare.Read);


                    raw = new byte[fs.Length];
                    fs.Read(raw, 0, Convert.ToInt32(fs.Length));

                    cmd = new SqlCommand("sp_userimage", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@photo", raw);
                    cmd.Parameters.AddWithValue("@date1", DateTime.Now);
                    con.Open();
                    int rows = cmd.ExecuteNonQuery();
                    con.Close();
                    if (rows > 0)
                    {
                        Label7.Visible = false;
                        displayimage();


                    }
                    else
                    {
                        string script = "<script>alert('Something went wrong')</script>";
                        Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "Error", script);
                    }
                }
                else
                {
                    Label7.Text = "Only Jpg,gif or Png files are permitted";
                    Label7.Visible = true;
                }
            }
            else
            {
                Label7.Text = "Kindly Select a File.....";
                Label7.Visible = true;
            }

        }
        catch (Exception e1)
        {
        }
    }
    public void displayimage()
    {
        try
        {
            Label7.Visible = false;
            string id = Convert.ToString(Session["username"]);

            con.Open();
            cmd = new SqlCommand("Select img from userimage where id=@id", con);
            cmd.Parameters.AddWithValue("@id", id);
            SqlDataReader dr = cmd.ExecuteReader();
            dr.Read();
            if (dr.HasRows)
            {

                Image1.ImageUrl = "~/Handler.ashx?id=" + id;
            }
            con.Close();
        }
        catch (Exception e1)
        {
        }

    }

    protected void Button4_Click(object sender, EventArgs e)
    {
        try
        {
            Chart1.Visible = true;
            int option = Convert.ToInt32(DropDownList1.SelectedValue);

            if (option == 0)
            {
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ss", "<script>alert('Please Enter First Name' )</script>", false);
            }
            else if (option == 1)
            {
                chart10000();
            }
            else if (option == 2)
            {
                chart20000();
            }
            else if (option == 3)
            {
                chart30000();
            }
            else if (option == 4)
            {
                chart40000();
            }
            else if (option == 5)
            {
                chart50000();
            }
            else if (option == 6)
            {
                chart60000();
            }
            else if (option == 7)
            {
                chart70000();
            }
            else if (option == 8)
            {
                chart80000();
            }
            else if (option == 9)
            {
                chart90000();
            }
            else if (option == 10)
            {
                chart100000();
            }            
            else
            {
                
            }
        }
        catch (Exception e1)
        {
        }
    }

    public void chart10000()
    {
        try
        {
            DataSet ds = new DataSet();
            con.Open();
            SqlCommand cmd11 = new SqlCommand("sp_getstatistics10000", con);
            cmd11.CommandText = "sp_getstatistics10000";
            cmd11.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd11);
            da.Fill(ds);
            con.Close();
            bindchart(ds);
        }
        catch (Exception e1)
        {
        }

    }

    public void chart20000()
    {
        try
        {
            DataSet ds = new DataSet();
            ds.Clear();
            con.Open();
            SqlCommand cmd11 = new SqlCommand("sp_getstatistics20000", con);
            cmd11.CommandText = "sp_getstatistics20000";
            cmd11.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd11);
            da.Fill(ds);
            con.Close();
            bindchart(ds);
        }
        catch (Exception e1)
        {
        }
    }
    public void chart30000()
    {
        try
        {
            DataSet ds = new DataSet();
            ds.Clear();
            con.Open();
            SqlCommand cmd11 = new SqlCommand("sp_getstatistics30000", con);
            cmd11.CommandText = "sp_getstatistics30000";
            cmd11.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd11);
            da.Fill(ds);
            con.Close();
            bindchart(ds);
        }
        catch (Exception e1)
        {
        }
    }
    public void chart40000()
    {
        try
        {
            DataSet ds = new DataSet();
            ds.Clear();
            con.Open();
            SqlCommand cmd11 = new SqlCommand("sp_getstatistics40000", con);
            cmd11.CommandText = "sp_getstatistics40000";
            cmd11.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd11);
            da.Fill(ds);
            con.Close();
            bindchart(ds);
        }
        catch (Exception e1)
        {
        }
    }
    public void chart50000()
    {
        try
        {
            DataSet ds = new DataSet();
            ds.Clear();
            con.Open();
            SqlCommand cmd11 = new SqlCommand("sp_getstatistics50000", con);
            cmd11.CommandText = "sp_getstatistics50000";
            cmd11.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd11);
            da.Fill(ds);
            con.Close();
            bindchart(ds);
        }
        catch (Exception e1)
        {
        }
    }
    public void chart60000()
    {
        try
        {
            DataSet ds = new DataSet();
            ds.Clear();
            con.Open();
            SqlCommand cmd11 = new SqlCommand("sp_getstatistics60000", con);
            cmd11.CommandText = "sp_getstatistics60000";
            cmd11.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd11);
            da.Fill(ds);
            con.Close();
            bindchart(ds);
        }
        catch (Exception e1)
        {
        }
    }
    public void chart70000()
    {
        try
        {
            DataSet ds = new DataSet();
            ds.Clear();
            con.Open();
            SqlCommand cmd11 = new SqlCommand("sp_getstatistics70000", con);
            cmd11.CommandText = "sp_getstatistics70000";
            cmd11.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd11);
            da.Fill(ds);
            con.Close();
            bindchart(ds);
        }
        catch (Exception e1)
        {
        }
    }
    public void chart80000()
    {
        try
        {
            DataSet ds = new DataSet();
            ds.Clear();
            con.Open();
            SqlCommand cmd11 = new SqlCommand("sp_getstatistics80000", con);
            cmd11.CommandText = "sp_getstatistics80000";
            cmd11.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd11);
            da.Fill(ds);
            con.Close();
            bindchart(ds);
        }
        catch (Exception e1)
        {
        }
    }
    public void chart90000()
    {
        try
        {
            DataSet ds = new DataSet();
            ds.Clear();
            con.Open();
            SqlCommand cmd11 = new SqlCommand("sp_getstatistics90000", con);
            cmd11.CommandText = "sp_getstatistics90000";
            cmd11.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd11);
            da.Fill(ds);
            con.Close();
            bindchart(ds);
        }
        catch (Exception e1)
        {
        }
    }
    public void chart100000()
    {
        try
        {
            DataSet ds = new DataSet();
            ds.Clear();
            con.Open();
            SqlCommand cmd11 = new SqlCommand("sp_getstatistics100000", con);
            cmd11.CommandText = "sp_getstatistics100000";
            cmd11.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd11);
            da.Fill(ds);
            con.Close();
            bindchart(ds);
        }
        catch (Exception e1)
        {
        }
    }
    
    public void bindchart(DataSet ds)
    {
        try
        {
        if (ds.Tables[0].Rows.Count > 0)
        {
            Chart1.BorderSkin.SkinStyle = BorderSkinStyle.Emboss;
            Chart1.BorderlineColor = System.Drawing.Color.FromArgb(26, 59, 105);
            Chart1.BorderlineWidth = 3;
            Chart1.BackColor = Color.RoyalBlue;

            Chart1.ChartAreas.Add("chtArea");
            Chart1.ChartAreas[0].AxisX.Title = "Search Category";
            Chart1.ChartAreas[0].AxisX.LabelStyle.Interval = 1;
            Chart1.ChartAreas[0].AxisX.Interval = 1;
            Chart1.ChartAreas[0].AxisX.TitleFont = new System.Drawing.Font("Verdana", 11, System.Drawing.FontStyle.Bold);
            Chart1.ChartAreas[0].AxisY.Title = "Response Time";
            Chart1.ChartAreas[0].AxisY.TitleFont = new System.Drawing.Font("Verdana", 11, System.Drawing.FontStyle.Bold);
            Chart1.ChartAreas[0].BorderDashStyle = ChartDashStyle.Solid;
            Chart1.ChartAreas[0].BorderWidth = 2;

            Chart1.Legends.Add("restimenonindex");
            Chart1.Series.Add("restimenonindex");
            Chart1.Series[0].ChartType = System.Web.UI.DataVisualization.Charting.SeriesChartType.Line;
            Chart1.Series[0].Points.DataBindXY(ds.Tables[0].DefaultView, "serchtype", ds.Tables[0].DefaultView, "restimenonindex");

            Chart1.Series[0].IsVisibleInLegend = true;
            Chart1.Series[0].IsValueShownAsLabel = true;
            Chart1.Series[0].ToolTip = "Data Point Y Value: #VALY{G}";

            // Setting Line Width
            Chart1.Series[0].BorderWidth = 3;
            Chart1.Series[0].Color = Color.Red;


            Chart1.Series.Add("restimeindex");
            Chart1.Series[1].ChartType = System.Web.UI.DataVisualization.Charting.SeriesChartType.Line;
            Chart1.Series[1].Points.DataBindXY(ds.Tables[0].DefaultView, "serchtype", ds.Tables[0].DefaultView, "restimeindex");

            Chart1.Series[1].IsVisibleInLegend = true;
            Chart1.Series[1].IsValueShownAsLabel = true;
            Chart1.Series[1].ToolTip = "Data Point Y Value: #VALY{G}";

            Chart1.Series[1].BorderWidth = 3;
            Chart1.Series[1].Color = Color.Green;

            // Setting Line Shadow
            //Chart1.Series[0].ShadowOffset = 5;

            //Legend Properties
            Chart1.Legends[0].LegendStyle = LegendStyle.Table;
            Chart1.Legends[0].TableStyle = LegendTableStyle.Wide;
            Chart1.Legends[0].Docking = Docking.Bottom;
        }
        }
        catch (Exception e1)
        {
        }
    }
}


   


     