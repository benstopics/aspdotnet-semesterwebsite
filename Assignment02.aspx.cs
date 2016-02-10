/*Name: Ben Ward
Assignment: 02
Date: 1/27/2016
Course: ASP.NET Class
Description: Assignment02 page ASP.NET code file.*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Default2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void NumberButtonClicked(object sender, EventArgs e)
    {
        Button button = (Button)sender;
        if (button.Text.Equals("Clear"))
        {
            lblPhonenumber.Text = ""; // If clear button clicked, clear textbox
        }
        else if (button.Text.Equals("<="))
        {
            lblPhonenumber.Text = lblPhonenumber.Text.Substring(0, lblPhonenumber.Text.Length - 1); // If backspace clicked, delete last char of textbox
        }
        else if (button.Text.Equals("OK"))
        {
            Response.Redirect("Assignment02DisplayNumber.aspx?PhoneNumber=" + lblPhonenumber.Text); // If OK button clicked, submit phone number to receiver page
        }
        else
        {
            lblPhonenumber.Text += button.Text; // If number button clicked, append number to textbox
        }
    }
}