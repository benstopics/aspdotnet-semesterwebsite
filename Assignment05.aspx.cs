/**************************************************************
 * Connect to DB and provide UI for designing car model       *
 * Bill Nicholson                                             *
 * nicholdw@ucmail.uc.edu                                     *
 * ************************************************************
 * Assignment05: Code-behind                                  *
 * Benjamin Ward                                              *
 * 2/17/2016                                                  *
 * wardb3@mail.uc.edu                                         *
 *************************************************************/

using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
    }
    protected void Page_LoadComplete(object sender, EventArgs e)
    {
        ddModel.AutoPostBack = true;
        if (!IsPostBack)
            UpdateOptions();
    }
    private void UpdateOptions()
    {
        sdsLeftListBox.SelectParameters.Clear();
        sdsLeftListBox.SelectParameters.Add("id", ddModel.SelectedValue);
        sdsLeftListBox.SelectCommand = "SELECT * FROM vModelAndOption WHERE ModelID = @id";
        lbRightSide.Items.Clear();
        lbLeftSide.ClearSelection();
        lbRightSide.ClearSelection();
    }
    protected void ddModel_SelectedIndexChanged(object sender, EventArgs e)
    {
        UpdateOptions();
    }
    protected void btnAllRight_Click(object sender, EventArgs e)
    {
        List<string> leftItems = new List<string>();

        foreach (ListItem item in lbLeftSide.Items)
        {
            lbRightSide.Items.Add(item);
        }

        lbLeftSide.Items.Clear();
        lbLeftSide.ClearSelection();
        lbRightSide.ClearSelection();
    }
    protected void btnAllLeft_Click(object sender, EventArgs e)
    {
        List<string> rightItems = new List<string>();

        foreach (ListItem item in lbRightSide.Items)
        {
            lbLeftSide.Items.Add(item);
        }

        lbRightSide.Items.Clear();
        lbLeftSide.ClearSelection();
        lbRightSide.ClearSelection();
    }
    protected void btnRight_Click(object sender, EventArgs e)
    {
        if (lbLeftSide.SelectedItem != null)
        {
            lbRightSide.Items.Add(lbLeftSide.SelectedItem);
            lbLeftSide.Items.Remove(lbLeftSide.SelectedItem);
        }

        lbLeftSide.ClearSelection();
    }
    protected void btnLeft_Click(object sender, EventArgs e)
    {
        if (lbRightSide.SelectedItem != null)
        {
            lbLeftSide.Items.Add(lbRightSide.SelectedItem);
            lbRightSide.Items.Remove(lbRightSide.SelectedItem);
        }

        lbRightSide.ClearSelection();
    }
}