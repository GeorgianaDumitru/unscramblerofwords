using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordUnscrambler.Data;

namespace WordUnscrambler.Workers
{
    internal class WordMatcher
    {
        internal List<MatchedWord> Match(string[] scambledWords, string[] wordList)
        {
            var matchedWords = new List<MatchedWord>();
            foreach (var scambledWord in scambledWords)
            {
                foreach(var word in wordList)
                {
                    if(scambledWord.Equals(word, StringComparison.OrdinalIgnoreCase))
                    {
                        matchedWords.Add(BuildMatchedWord(scambledWord, word));
                    }
                    else
                    {
                        var scrambledWordArray = scambledWord.ToCharArray();
                        var wordArray = word.ToCharArray();

                        Array.Sort(scrambledWordArray);
                        Array.Sort(wordArray);

                        var sortedScrambledWord = new string(scrambledWordArray);
                        var sortedWord = new string(wordArray);

                        if(sortedScrambledWord.Equals(sortedWord, StringComparison.OrdinalIgnoreCase))
                        {
                            matchedWords.Add(BuildMatchedWord(scambledWord, word));

                        }

                    }
                }
            }


            return matchedWords;
        }
        private MatchedWord BuildMatchedWord(string scambledWord, string word)
        {
            MatchedWord matchedWord = new MatchedWord
            {
                ScrambledWord = scambledWord,
                Word = word
            };
            return matchedWord;
        }
    }
}
