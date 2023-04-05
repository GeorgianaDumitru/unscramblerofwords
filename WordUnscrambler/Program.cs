using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using WordUnscrambler.Workers;
using WordUnscrambler.Data;

namespace WordUnscrambler
{

    
    class Program
    {
        private static readonly FileReader _fileReader = new FileReader();
        private static readonly WordMatcher _wordMatcher = new WordMatcher();
        

        static void Main(string[] args)
        {
            try
            {
                bool continueWordUnscramble = true;

                do
                {
                    Console.WriteLine(Constants.OptionsOnHowToEnterScrambledWords);

                    var option = Console.ReadLine() ?? string.Empty;

                    switch (option.ToUpper())
                    {
                        case Constants.File:
                            Console.Write(Constants.EnterScrambledWordsViaFile);
                            ExecuteScrambledWordInFileScenerio();
                            break;
                        case Constants.Manual:
                            Console.Write(Constants.EnterScrambledWordsManully);
                            ExecuteScarmbledWordManullyEntryScenerio();
                            break;
                        default:
                            Console.Write(Constants.EnterScrambledWordsOptionNotRecognized);
                            break;

                    }
                    var continueDecision = string.Empty;
                    do
                    {
                        Console.WriteLine(Constants.OptionsOnContinuingTheProgram);
                        continueDecision = (Console.ReadLine() ?? string.Empty);


                    } while (
                        !continueDecision.Equals(Constants.Yes, StringComparison.OrdinalIgnoreCase) &&
                        !continueDecision.Equals(Constants.No, StringComparison.OrdinalIgnoreCase));

                    continueWordUnscramble = continueDecision.Equals(Constants.Yes, StringComparison.OrdinalIgnoreCase);

                } while (continueWordUnscramble);

            }
            catch (Exception ex)
            {
                Console.WriteLine(Constants.ErrorProgramWillBeTerminated + ex.Message);
            }



        }

        private static void ExecuteScarmbledWordManullyEntryScenerio()
        {
            var manualInput = Console.ReadLine() ?? string.Empty;
            string[] scambledWords = manualInput.Split(',');
            DisplayMatchedUnscambledWords(scambledWords);            
        }


        private static void ExecuteScrambledWordInFileScenerio()
        {
            try
            {
                var fileName = Console.ReadLine() ?? string.Empty;
                string[] scambledWords = _fileReader.Read(fileName);
                DisplayMatchedUnscambledWords(scambledWords);

            }
            catch(Exception ex)
            {
                Console.WriteLine(Constants.ErrorScrambledWordsCannotBeLoaded + ex.Message);

            }
            
        }
        private static void DisplayMatchedUnscambledWords(string[] scambledWords)
        {
            string[] wordList = _fileReader.Read(Constants.WordListFileName);

            List<MatchedWord> matchedWords = _wordMatcher.Match(scambledWords, wordList);

            if(matchedWords.Any())
            {
                foreach(var mactshedWord in matchedWords)
                {
                    Console.WriteLine(Constants.MatchFound, mactshedWord.ScrambledWord, mactshedWord.Word);
                }
            }
            else
            {
                Console.WriteLine(Constants.MatchNotFound);
            }

        }
    }
}
