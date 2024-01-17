using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib_SC
{
    public class Monoalphabetic
    {
        private static string Eng_Char = "abcdefghijklmnopqrstuvwxyz";

        //Main Function
        public static string MainFunctionMonoalphabetic(string OldText, string Key, bool T)
            => ChoseType(T).Invoke(OldText, Key);
        //Chose Type Encryption  or Decryption 
        private static Func<string, string, string> ChoseType(bool T)
            => T ? MonoalphabeticEncryption : MonoalphabeticDecryption;
        //Take Char From Eng_Char And Covert To KEY  
        // EngChars:'abc' ,Key:'DFG',OldText:'fg'
        //newText='fg'
        private static string MonoalphabeticEncryption(string OldText, string Key)
        {
            string NewString = "";
            OldText.ToList().ForEach(
                x =>
                {
                    int index = Eng_Char.IndexOf(x >= 97 && x <= 122 ? x : CovertCharFromCaptialToSmall(x));
                    NewString = $"{NewString}{Key[index]}";
                });
            return NewString;
        }
        //Take Char From Key And Covert To Eng_Char 
        // EngChars:'abc' ,Key:'DFG',OldText:'fg'
        //newText='bc'
        private static string MonoalphabeticDecryption(string OldText, string Key)
        {
            string NewString = "";
            OldText.ToList().ForEach(
                x =>
                {
                    Key = Key.ToLower();
                    int index = Key.IndexOf(x >= 97 && x <= 122 ? x : CovertCharFromCaptialToSmall(x));
                    NewString = $"{NewString}{Eng_Char[index]}";
                });
            return NewString;
        }
        private static char CovertCharFromCaptialToSmall(char c)//A - a
            => (char)(c + 32);
    }
}
