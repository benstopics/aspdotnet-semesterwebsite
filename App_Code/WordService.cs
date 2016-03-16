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
using System.Linq;
using System.Net;
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
    public List<string> GetSynonymOfLastWord(string sentence)
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
            List<string> synonyms = GetSynonyms(word);
            // Generate suggestions
            if (words.Count == 0) // No words for prefix, make prefix blank
                prefix = "";
            foreach (string synonym in synonyms)
                result.Add(prefix + synonym);
            // If first word, suggest capitalization
            if (prefix.Equals(""))
                for (int i = 0; i < result.Count; i++)
                    result[i] = (result[i][0] + "").ToUpper() + result[i].Substring(1);
        }

        return result;
    }

    public static List<string> GetSynonyms(string word)
    {
        List<string> result = new List<string>();

        WebClient client = new WebClient();
        client.Encoding = System.Text.Encoding.UTF8; // If encoding isn't set manually, dot character will be converted to "A" as placeholder
        try
        {
            string downloadString = client.DownloadString("http://www.thesaurus.com/browse/" + word);
            if (!String.IsNullOrEmpty(downloadString))
            {
                // Capture HTML in synonyms div
                int htmlAfterSynonymsDivIndex = AllIndexesOf(downloadString, "<div class=\"relevancy-list\">")[0];
                string htmlAfterSynonymsDiv = downloadString.Substring(htmlAfterSynonymsDivIndex);
                int synonymsHTMLIndex = AllIndexesOf(htmlAfterSynonymsDiv, "</div>")[0];
                string synonymsHTML = htmlAfterSynonymsDiv.Substring(0, synonymsHTMLIndex);
                // Capture synonyms
                List<int> indexes = AllIndexesOf(synonymsHTML, "<li><a href=\"http://www.thesaurus.com/browse/"); // Capture all instances of synonym data
                foreach (int index in indexes)
                {
                    string trim = synonymsHTML.Substring(index + 45);

                    // Capture word
                    for (int i = 0; i < trim.Length; i++)
                    {
                        Console.Write(trim[i]);
                        if (trim[i] == '"')
                        { // If found non-word character
                            trim = trim.Substring(0, i);
                            Console.WriteLine();
                            break;
                        }
                    }

                    Console.WriteLine(trim);

                    result.Add(Uri.UnescapeDataString(trim)); // Add word to list of synonyms (unescape in case of %20 spaces)
                }
            }
        }
        catch (Exception e) { }

        return result;
    }

    static string acceptableChars = "abcdefghijklmnopqrstuvwxyz'·";

    [WebMethod]
    public static int CountSyllables(string word)
    {
        int result = 0;
        // Start web client
        WebClient client = new WebClient();
        client.Encoding = System.Text.Encoding.UTF8; // If encoding isn't set manually, dot character will be converted to "A" as placeholder
        try
        {
            string downloadString = client.DownloadString("http://www.dictionary.com/browse/" + word);
            List<int> indexes = AllIndexesOf(downloadString, "data-syllable=\""); // Capture all instances of syllable data indexes
            foreach (int index in indexes)
            {
                string trim = downloadString.Substring(index + 15);

                // Capture syllable data values
                for (int i = 0; i < trim.Length; i++)
                {
                    int search = acceptableChars.IndexOf(trim[i]);
                    Console.Write(trim[i]);
                    if (search == -1)
                    { // If found non-word character
                        trim = trim.Substring(0, i);
                        Console.WriteLine();
                        break;
                    }
                }

                Console.WriteLine(trim);

                if (String.Join("", trim.Split('·')) == word)
                {
                    result = trim.Split('·').Length; // Count number of syllables
                    break;
                }
            }
        }
        catch (Exception e) { }

        return result;
    }

    // http://stackoverflow.com/questions/2641326/finding-all-positions-of-a-substring-in-a-large-string-in-c-sharp
    public static List<int> AllIndexesOf(string str, string value)
    {
        if (String.IsNullOrEmpty(value))
            throw new ArgumentException("the string to find may not be empty", "value");
        List<int> indexes = new List<int>();
        for (int index = 0; ; index += value.Length)
        {
            index = str.IndexOf(value, index);
            if (index == -1)
                return indexes;
            indexes.Add(index);
        }
    }
}
