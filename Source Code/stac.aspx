<%@ Page Language="C#" AutoEventWireup="true" CodeFile="stac.aspx.cs" Inherits="stac" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">  
    <title>Article by Vithal Wadje</title>  
</head>  
<body bgcolor="blue">  
    <form id="form1" runat="server">  
    <h4 style="color: White;">  
       Accuracy Representation
    </h4>  
    <asp:Chart ID="Chart1" runat="server" BackColor="64, 0, 0"   
        BackGradientStyle="LeftRight" Height="350px" Palette="None"   
        PaletteCustomColors="192, 0, 0" Width="350px">  
        <Series>  
            <asp:Series Name="Series1">  
            </asp:Series>  
        </Series>  
        <ChartAreas>  
            <asp:ChartArea Name="ChartArea1" >  
            </asp:ChartArea>  
        </ChartAreas>  
        <BorderSkin BackColor="" PageColor="192, 64, 0" />  
    </asp:Chart>  
  
  
    </form>  
</body>  
</html>  