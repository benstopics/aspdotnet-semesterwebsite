/*Name: Ben Ward
Assignment: 03
Date: 2/3/2016
Course: ASP.NET Class
Description: Code-behind to perform user functions for Assignment03. */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Assignment03 : System.Web.UI.Page
{
    static ViewCollection views;

    protected void Page_Init(object sender, EventArgs e)
    {
        // Instantiate view if multiview not populated
        if(views == null)
            views = new ViewCollection(mvUserMultiview);
        // Populate multiview
        for (int i = 0; i < views.Count; i++)
        {
            mvUserMultiview.Views.Add(views[i]);
        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        // Handle custom dropdown visibility behavior
        ddNavigation.Visible = false;
        if(IsPostBack)
            ddNavigation.Visible = true;
        // Enable automatic postback for selectedchangeindex event
        ddNavigation.AutoPostBack = true;
    }
    protected void btnUserButton_Click(object sender, EventArgs e)
    {
        try
        {
            int numOfViews = Convert.ToInt32(txtUserTextbox.Text); // Get number of views from textbox
            views.Clear();
            for (int i = 0; i < numOfViews; i++)
            {
                // Create view
                Label lblOne = new Label();
                lblOne.Text = "View " + (i+1).ToString();
                View myViewOne = new View();
                myViewOne.Controls.Add(lblOne);
                // Build view list
                views.Add(myViewOne);
                mvUserMultiview.Views.Add(myViewOne);
                // Build navigation list
                ddNavigation.Items.Add("View " + (i+1));
            }
            
            ddNavigation.Visible = true; // Unhide dropdown
            mvUserMultiview.ActiveViewIndex = 0; // Set multiview focus to first view
        }
        catch
        {

        }
    }
    protected void ddNavigation_SelectedIndexChanged(object sender, EventArgs e)
    {
        mvUserMultiview.ActiveViewIndex = ddNavigation.SelectedIndex; // When dropdownlist selected index changed, change multiview active view accordingly
    }
}