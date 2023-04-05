using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordUnscrambler
{
    class Constants
    {
        public const string OptionsOnHowToEnterScrambledWords = "Enter scrambled word(s) manully or as a file: F - file/M - manual; ";
        public const string OptionsOnContinuingTheProgram = "Would you like to continu? Y/N";

        public const string EnterScrambledWordsViaFile = "Enter full path including file name: ";
        public const string EnterScrambledWordsManully = "Enter word(s) manully (separeted by commas is multiple): ";
        public const string EnterScrambledWordsOptionNotRecognized = "The option was not recongnized";
        
        public const string ErrorScrambledWordsCannotBeLoaded = "Scrambled words were not loaded because there was aan error: ";
        public const string ErrorProgramWillBeTerminated = "The program will be terminated: ";
        
        public const string MatchFound = "MATCHED FOUND FOR {0} {1}";
        public const string MatchNotFound = "NO MATCHES HAVE BEEN FOUND";

        public const string Yes = "Y";
        public const string No = "N";
        public const string File = "F";
        public const string Manual = "M";

        public const string WordListFileName = "wordlist.txt";

    }
}
