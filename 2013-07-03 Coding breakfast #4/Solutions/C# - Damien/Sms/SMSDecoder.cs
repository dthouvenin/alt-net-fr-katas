using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Sms
{
    public class SMSDecoder
    {
        public IDico Dico { get; private set;}

        public SMSDecoder()
        {
            this.Dico = new Dico();
        }
        
        public SMSDecoder(string filename)
        {            
            if(!File.Exists(filename))
                throw new FileNotFoundException("Fichier de dictionnaire non trouvé");
            this.Dico = new Dico();
            ((Dico)Dico).LoadFromFile(filename, EncodeWord);
        }

        public SMSDecoder(IDico dico)
        {
            this.Dico = dico;
        }

        public string DecodeWord(string word)
        {
            var candidates = Dico[word];
            if (candidates.Count == 1)
                return candidates[0];
            return string.Format("({0})", string.Join(" ", candidates.Cast<string>()));
        } 

        public string DecodeSentence(string sentence)
        {
            var res = new List<string>();
            ExtractAllWords(sentence, word => res.Add(DecodeWord(word)));
            return string.Join(" ", res);
        }

        #region Encode / Decode helpers
        private static Regex dblEx = new Regex("([^aeiouy])(\\1+)");
        private static Regex repEx = new Regex("[aeiouy]");
        private static Regex wordBrk = new Regex("(\\w+)");

        public static string EncodeWord(string original)
        {
            if (string.IsNullOrEmpty(original))
                return original;
            var sansAccents = Encoding.ASCII.GetString(Encoding.GetEncoding(1251).GetBytes(original)).ToLowerInvariant();
            var sansDoubles = dblEx.Replace(sansAccents, "$2");
            return sansDoubles[0] + repEx.Replace(sansDoubles.Remove(0, 1), "");
        }
        public delegate void WordProcessor(string original);

        internal static void ExtractAllWords(string original, WordProcessor process)
        {
            foreach (Match match in wordBrk.Matches(original))
            {
                process(match.Value);
            }            
        }

        public static string EncodeSentence(string original)
        {
            var res = new List<string>();
            ExtractAllWords(original, word => res.Add(EncodeWord(word)));
            return string.Join(" ", res);
        }
        #endregion
    }
}
