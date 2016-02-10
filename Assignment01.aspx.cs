/* Name: Ben Ward
Assignment: 02
Date: 1/27/2016
Course: ASP.NET Class
Description: Assignment01 page. */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Assignment01 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
    }

    public void SolveOnClick()
    {
        Response.Write("<p>" + new Problem160().Solve() + "</p>");
    }

    public class Problem160
    {
        public int Solve()
        {
            long num = 1000000000, factorial = 1;
            for (long i = num; i > 0; factorial *= i--) ;
            string result = factorial.ToString();
            // Factorial calculator
            while (result.Length > 5)
                result = (result.Substring(result.Length - 1).Equals("0")) ? result.Substring(0, result.Length - 1) : result.Substring(result.Length - 5);
            return Int32.Parse(result); // Display result
        }
    }
}