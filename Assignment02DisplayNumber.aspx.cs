/* Name: Ben Ward
Assignment: 02
Date: 1/27/2016
Course: ASP.NET Class
Description: This page receives the phone number from the form page and displays it. */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Assignment02DisplayNumber : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // Get and display phone number Get variable received
        if (Request.QueryString["PhoneNumber"] == null || Request.QueryString["PhoneNumber"].Equals("")) // Check if empty or non existent
            Response.Redirect("Assignment02.aspx");
        else
            lblDisplayPhoneNumber.Text = "Your phone number is " + Request.QueryString["PhoneNumber"]; // If not empty, display number
    }
}