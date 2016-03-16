/**************************************************************
 * Create a web service and implement in website              *
 * Bill Nicholson                                             *
 * nicholdw@ucmail.uc.edu                                     *
 * ************************************************************
 * Assignment06: Web service, syllables/synonyms/antonyms     *
 * Benjamin Ward                                              *
 * 3/16/2016                                                  *
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
    protected void btnGetSyllables_Click(object sender, EventArgs e)
    {
        int syllables = WordService.CountSyllables(txtGetSyllables.Text);
        if (syllables == 0)
            txtDisplayNumSyllables.Text = "ERROR";
        else
            txtDisplayNumSyllables.Text = syllables.ToString();
    }
}