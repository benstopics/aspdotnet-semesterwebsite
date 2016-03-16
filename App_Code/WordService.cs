using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

/// <summary>
/// Summary description for WordService
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
[System.Web.Script.Services.ScriptService]
public class WordService : System.Web.Services.WebService
{

    public WordService()
    {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod]
    public List<string> GetSynonyms(string sentence)
    {
        List<string> result = new List<string>();

        List<string> words = new List<string>();
        words.AddRange(sentence.Split(' '));
        if (sentence[sentence.Length - 1] != ' ' && words.Count > 0) // Not starting new word and words to work with
        {
            // Capture word
            string word = words[words.Count - 1];
            // Rebuild sentence without last word
            words.RemoveAt(words.Count - 1);
            string prefix = String.Join(" ", words) + " ";
            // Generate synonyms
            // TODO - grab synonyms from dictionary.com
            // Generate suggestions
            if (words.Count == 0) // No words for prefix, make prefix blank
                prefix = "";
            result.Add(prefix + "cat");
            result.Add(prefix + "dog");
            result.Add(prefix + "wolf");
            // If first word, suggest capitalization
            if (prefix.Equals(""))
                for (int i = 0; i < result.Count; i++)
                    result[i] = (result[i][0] + "").ToUpper() + result[i].Substring(1);
        }

        return result;
    }

}
