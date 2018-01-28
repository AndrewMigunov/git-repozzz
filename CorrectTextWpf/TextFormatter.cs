using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorrectTextWpf
{
    public class TextFormatter
    {
        public static string Justify(string text, int width)
        {
            string rightText = "";            
            List<string> words = new List<string>(text.Split(' '));                      
            words.RemoveAll(x => x == "");
            foreach (string str in words)
            {
                if (str.Length > width)
                {
                    throw new Exception("word length > line width");
                }
            }


            for (int startIndex = 0; startIndex < words.Count; startIndex++)
            {
                int endIndex = startIndex;
                bool isLastLine = false;
                int length = words[endIndex].Length;
                while (endIndex < words.Count - 1)
                {
                    endIndex++;
                    length += words[endIndex].Length;
                    length++;
                    if (length > width)
                    {
                        endIndex--;
                        break;
                    }

                }
                if (endIndex == words.Count - 1)
                {
                    isLastLine = true;
                }
                rightText += NewLine(words, startIndex, endIndex, isLastLine, width);
                startIndex = endIndex;
            }
            return rightText;
        }
        private static string NewLine(List<string> words, int startIndex, int endIndex, bool isLastLine, int width)
        {
            string line = "";
            if (isLastLine)
            {
                for (int i = startIndex; i < endIndex; i++)
                {
                    line += words[i] + " ";
                }
                line += words[endIndex];
                return line;
            }
            if (startIndex == endIndex)
            {
                line += words[startIndex] + "\n";
                return line;
            }
            int length = 0;
            for (int i = startIndex; i <= endIndex; i++)
            {
                length += words[i].Length;
            }
            int countSpaces = width - length;
            int countInterval = endIndex - startIndex;
            int mincountSpaces = countSpaces / countInterval, remainingSpaces = countSpaces % countInterval;
            for (int i = startIndex; i < endIndex; i++)
            {
                line += words[i];
                if (remainingSpaces != 0)
                {
                    for (int j = 1; j <= mincountSpaces + 1; j++)
                    {
                        line += " ";

                    }
                    remainingSpaces--;
                }
                else
                {
                    for (int j = 1; j <= mincountSpaces; j++)
                    {
                        line += " ";

                    }
                }
            }
            line += words[endIndex] + "\n";
            return line;

        }


    }
}
