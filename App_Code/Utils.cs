using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Net;

namespace UtilsNamespace { 
/// <summary>
/// Summary description for Utils
/// </summary>
    public class Utils {
        public Utils() {
            //
            // TODO: Add constructor logic here
            //
        }
        /// <summary>
        /// Read the word list into a List data structure
        /// </summary>
        /// <returns>The List object containing all the words</returns>
        public static List<String> ReadWordList() {

            List<String> wordList = new List<String>();
            StreamReader sr = null;
            try {   // Open the text file using a stream reader.
                String path = HttpContext.Current.Server.MapPath("~/Words/english.All.txt");
                using (sr = new StreamReader(path)) {
                    String word;
                    while ((word = sr.ReadLine())!= null) {
                        wordList.Add(word);
//                      Console.WriteLine(word);
                    }
                }
            } catch (Exception e) {
                // What can we do here??            
            } finally { try { sr.Close(); } catch (Exception ex) { } }
            return wordList;
        }

        /**
         * Assignment04: auxilliary functions
         * Benjamin Ward
         * 2/10/2016
         * wardb3@mail.uc.edu
         **/
        static string acceptableChars = "abcdefghijklmnopqrstuvwxyz'·";

        public static int CountSyllables(string word)
        {
            int result = 0;
            // Start web client
            WebClient client = new WebClient();
            client.Encoding = System.Text.Encoding.UTF8; // If encoding isn't set manually, dot character will be converted to "A" as placeholder
            string downloadString = client.DownloadString("http://www.dictionary.com/browse/wardenship");
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

                if (String.Join("", trim.Split('·')) == "wardenship")
                {
                    result = trim.Split('·').Length; // Count number of syllables
                    break;
                }
            }

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
}