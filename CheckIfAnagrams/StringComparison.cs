using System;
using System.Collections.Generic;
using System.Linq;

namespace CheckIfAnagrams
{
    public static class StringComparison
    {
    // Longer and more complex algorithm
    #region First algorithm
        public static bool CheckIfAnagrams1(string firstTextData, string secondTextData)
        {
            // PREPARATIONS: Counting (letters in string) + sorting (achieved dictionary)
            Dictionary<char, int> firstTextDataResult = SortDictionaryByKeys(CountLetters(firstTextData));
            Dictionary<char, int> secondTextDataResult = SortDictionaryByKeys(CountLetters(secondTextData));


            // CHECKING: Check if the output dictionaries have the same size
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
    #endregion

    // Shorter and more optimised algorithm
    #region Second algorithm
        public static bool CheckIfAnagrams2(string firstTextData, string secondTextData)
        {
            // Check if both strings have the same size
            if (firstTextData.Length != secondTextData.Length)
            {
                return false;
            }

            string tempSecondTextData = secondTextData.ToLower();
            foreach (char letter in firstTextData.ToLower())
            {
                // Check if the second string contains the letter of the first string
                if (tempSecondTextData.Contains(letter) == false)
                {
                    return false;
                }
                // Remove current letter from the string       Find the index of the first occurrence of a letter
                tempSecondTextData = tempSecondTextData.Remove(tempSecondTextData.IndexOf(letter), 1);
            }

            return true;
        }
    #endregion
    }
}
