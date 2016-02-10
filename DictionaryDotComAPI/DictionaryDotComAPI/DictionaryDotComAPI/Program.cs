using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DictionaryDotComAPI;
using System.Net;
using System.Text.RegularExpressions;

namespace DictionaryDotComAPI
{
    class Program
    {
        static string acceptableChars = "abcdefghijklmnopqrstuvwxyz'·";
        static void Main(string[] args)
        {
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
                    int syllables = trim.Split('·').Length;
                    Console.WriteLine(String.Join("", trim.Split('·')) + " " + syllables);
                    break;
                }
            }

            Console.ReadKey();
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
