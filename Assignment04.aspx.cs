/**************************************************************
 * Do cool stuff with strings                                 *
 * Bill Nicholson                                             *
 * nicholdw@ucmail.uc.edu                                     *
 * ************************************************************
 * Assignment04: Do cool stuff with strings contribution      *
 * Benjamin Ward                                              *
 * 2/10/2016                                                  *
 * wardb3@mail.uc.edu                                         *
 *************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnCheck_Click(object sender, EventArgs e)
    {
        String word = txtCheck.Text.Trim();
        if (checkSpelling(word))
        {
            lblResult.Text = "Correct";
            lblResult.Visible = true;
        }
        else
        {
            lblResult.Text = "Not a word";
            lblResult.Visible = true;
        }
    }
    /// <summary>
    /// Check the spelling of a word. Does the word exist in the Word List?
    /// </summary>
    /// <param name="testWord">The word to be checked</param>
    /// <returns>True if testWord is in the Word List, false otherwise.</returns>
    private Boolean checkSpelling(String testWord)
    {
        Boolean result = false;
        List<String> words = (List<String>)Application["WordList"];
        foreach (String word in words)
        {
            if (word == testWord)
            {
                result = true;
                break;
            }
        }
        return result;
    }
    protected void btnPrefix_Click(object sender, EventArgs e)
    {
        txtPrefixResult.Text = "";
        int count = BuildWordList(txtPrefix.Text.Trim(), txtPrefixResult);
        lblCount.Text = count + " word" + ((count == 1) ? "" : "s");
    }
    /// <summary>
    /// Build a list of words that begin with a specific prefix
    /// </summary>
    /// <param name="prefix">The prefix</param>
    /// <param name="txtTarget">The place where the word list should be written</param>
    /// <returns>The number of words added to txtTarget</returns>
    public int BuildWordList(String prefix, TextBox txtTarget)
    {
        int count = 0;
        List<String> words = (List<String>)Application["WordList"];
        foreach (String word in words)
        {
            if (word.StartsWith(prefix))
            {
                txtTarget.Text += word + " ";
                count++;
            }
        }
        return count;
    }

    protected void btnGenerateStatistics_Click(object sender, EventArgs e)
    {
        GenerateWordListStatistics(txtStatistics);
    }

    public void GenerateWordListStatistics(TextBox txtTarget)
    {
        List<String> words = (List<String>)Application["WordList"];
        txtTarget.Text = words.Count + " word" + ((words.Count == 1) ? "" : "s");
        int characterCount = 0, letterCount = 0;
        String longestWord = "";
        foreach (String word in words)
        {
            characterCount += word.Length;
            foreach (Char ch in word)
            {
                if (Char.IsLetter(ch)) letterCount++;
                int idx = Convert.ToInt32(ch);
            }
            if (longestWord.Length < word.Length) { longestWord = word; }
        }
        txtTarget.Text += "\n" + characterCount + " characters";
        txtTarget.Text += "\n" + letterCount + " letters";
        txtTarget.Text += "\n" + (characterCount - letterCount) + " characters are not letters";
        txtTarget.Text += "\n" + "longest word is " + longestWord;
        txtTarget.Text += "\n" + "letter used the most: " + CalculateCharacterUsedTheMost();
    }


    protected void btnTwoRandomWords_Click(object sender, EventArgs e)
    {
        List<String> words = (List<String>)Application["WordList"];
        int count = words.Count;
        Random r = new Random();
        int word1 = r.Next(count);
        int word2 = r.Next(count);
        txtTwoRandomWords.Text = words[word1] + " " + words[word2];
    }
    /// <summary>
    /// Calculate the character that appears the most times in the word list
    /// </summary>
    /// <returns>the character that appears the most times in the word list</returns>
    private char CalculateCharacterUsedTheMost()
    {
        List<String> words = (List<String>)Application["WordList"];
        int indexofCharacterUsedTheMost = 0;
        int countOfCharacterUsedTheMost = 0;
        int[] letterList = new int[256];        // ASCII is 1 to 127 and 128 to 256 is ASCII extended. We only care about ASCII in this program.
        // Process each letter and count the occurrences
        foreach (String word in words)
        {
            foreach (Char ch in word)
            {
                int idx = Convert.ToInt32(ch);
                letterList[idx]++;
            }
        }
        // Scan the list for the highest count
        for (int i = 0; i < letterList.Length; i++)
        {
            if (countOfCharacterUsedTheMost < letterList[i])
            {
                indexofCharacterUsedTheMost = i;
                countOfCharacterUsedTheMost = letterList[i];
            }
        }
        return (Char)(indexofCharacterUsedTheMost);
    }

    protected void btnGenerateHaiku_Click(object sender, EventArgs e)
    {
        string haiku = "";

        List<String> words = (List<String>)Application["WordList"];
        string line1 = GenerateSyllabicLine(words, 5); // First line, 5 syllables
        string line2 = GenerateSyllabicLine(words, 7); // Second line, 7 syllables
        string line3 = GenerateSyllabicLine(words, 5); // Third line, 5 syllables
        haiku = line1 + "\n" + line2 + "\n" + line3;
        txtGenerateHaiku.Text = haiku;
    }

    public static string GenerateSyllabicLine(List<String> wordChoice, int syllables)
    {
        string result = "";

        int count = wordChoice.Count;
        Random r = new Random();
        string line = "";
        int syllablesCount = 0;
        while (true)
        {
            string nextWord = wordChoice[r.Next(count)]; // Generate random word
            int wordSyllables = UtilsNamespace.Utils.CountSyllables(nextWord); // Calculate number of syllables
            if (wordSyllables > 0)
            {
                line += " " + nextWord;
                syllablesCount += wordSyllables; // Update syllable count of generated line
                if (syllablesCount > syllables) // Too many syllables
                {
                    // Reset
                    line = "";
                    syllablesCount = 0;
                }
                else if (syllablesCount == syllables) // Line complete
                {
                    result = line;
                    break;
                } // Else, continue adding words
            }
        }

        return result;
    }
}