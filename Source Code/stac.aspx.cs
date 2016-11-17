using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class stac : System.Web.UI.Page
{
    private SqlConnection con;
    private SqlCommand com;
    private string constr, query;
    private void connection()
    {
        constr = ConfigurationManager.ConnectionStrings["getconn"].ToString();
        con = new SqlConnection(constr);
        con.Open();

    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Bindchart();

        }
    }


    private void Bindchart()
    {
        connection();
        query = "select *from Orderdet";//not recommended this i have written just for example,write stored procedure for security  
        com = new SqlCommand(query, con);
        SqlDataAdapter da = new SqlDataAdapter(query, con);
        DataSet ds = new DataSet();
        da.Fill(ds);

        DataTable ChartData = ds.Tables[0];

        //storing total rows count to loop on each Record  
        string[] XPointMember = new string[ChartData.Rows.Count];
        int[] YPointMember = new int[ChartData.Rows.Count];

        for (int count = 0; count < ChartData.Rows.Count; count++)
        {
            //storing Values for X axis  
            XPointMember[count] = ChartData.Rows[count]["Month"].ToString();
            //storing values for Y Axis  
            YPointMember[count] = Convert.ToInt32(ChartData.Rows[count]["Orders"]);


        }
        //binding chart control  
        Chart1.Series[0].Points.DataBindXY(XPointMember, YPointMember);

        //Setting width of line  
        Chart1.Series[0].BorderWidth = 1;
        //setting Chart type   
        Chart1.Series[0].ChartType = SeriesChartType.Line;
        // Chart1.ChartAreas["ChartArea1"].AxisX.MajorGrid.Enabled = false;  
        // Chart1.ChartAreas["ChartArea1"].AxisY.MajorGrid.Enabled = false;  
        //  Chart1.Series[0].ChartType = SeriesChartType.Spline;  
        //Chart1.ChartAreas["ChartArea1"].Area3DStyle.Enable3D = true;  


        con.Close();

    }
}