using System;
using System.Collections.Generic;
using System.Linq;

namespace CheckIfAnagrams
{
    public static class StringComparison
    {
        public static bool CheckIfAnagrams(string firstTextData, string secondTextData)
        {
            // PREPARATIONS: Counting (letters in string) + sorting (achieved dictionary)
            Dictionary<char, int> firstTextDataResult = SortDictionaryByKeys(CountLetters(firstTextData));
            Dictionary<char, int> secondTextDataResult = SortDictionaryByKeys(CountLetters(secondTextData));


            // CHECKING: Check if the output dictionaries are the same size
            if (firstTextDataResult.Count != secondTextDataResult.Count)
            {
                return false;
            }

            foreach (KeyValuePair<char, int> pair in firstTextDataResult)
            {
                // Check if the 2nd dictionary contains a key of the 1st dictionary
                if (secondTextDataResult.ContainsKey(pair.Key) == false)
                {
                    return false;
                }

                firstTextDataResult.TryGetValue(pair.Key, out int firstValue);
                secondTextDataResult.TryGetValue(pair.Key, out int secondValue);

                // Check if value of the current key is exactly the same for both dictionaries
                if (firstValue != secondValue)
                {
                    return false;
                }
            }

            return true;
        }

        private static Dictionary<char, int> CountLetters(string textData)
        {
            Dictionary<char, int> countedLettersDictionary = new Dictionary<char, int>();

            foreach (char letter in textData)
            {
                char smallLetter = Convert.ToChar(letter.ToString().ToLower());

                // Add new letter if it's not exists
                if (countedLettersDictionary.ContainsKey(smallLetter) == false)
                {
                    countedLettersDictionary.Add(smallLetter, 1);
                }
                // Increment occurrence of already existing letter
                else
                {
                    countedLettersDictionary.TryGetValue(smallLetter, out int value);
                    countedLettersDictionary[smallLetter] = value + 1;
                }
            }

            return countedLettersDictionary;
        }

        private static Dictionary<char, int> SortDictionaryByKeys(Dictionary<char, int> dictionary)
        {
            return dictionary.OrderBy(pair => pair.Key).ToDictionary(pair => pair.Key, pair => pair.Value);
        }
    }
}
