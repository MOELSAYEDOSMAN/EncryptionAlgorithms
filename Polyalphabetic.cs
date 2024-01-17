using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib_SC
{
    public class Polyalphabetic
    {
        //Use caser To Shift Char
        public static string MainPolyalphabetic(string Text, bool Encrp)
            => Encrp ? EncrpPolyalphabetic(Text) : DecrypPolyalphabetic(Text);


        private static string DecrypPolyalphabetic(string Text)
        {
            string NewText = "";
            int Length = Text.Length;
            for (int i = 0; i < Length; i++)
                NewText = $"{NewText}{(i % 3 == 0 ? Caesar.MainCaesar(Text[i].ToString(), 3, false)//Role 1:Shift Left Char 3 ,Caesar=>Key=-3
                    : i % 3 == 1 ? Caesar.MainCaesar(Text[i].ToString(), 5, false)//Role 2:Shift Left Char 5 ,Caesar=>Key=-5
                    : Caesar.MainCaesar(Text[i].ToString(), 7, false))}";//Role 3:Shift Left Char 7 ,Caesar=>Key=-7
            return NewText;
        }


        private static string EncrpPolyalphabetic(string Text)
        {
            string NewText = "";
            int Length = Text.Length;
            for (int i = 0; i < Length; i++)
                NewText =
                    $"{NewText}{(i % 3 == 0 ? Caesar.MainCaesar(Text[i].ToString(), 3, true)//Role 1:Shift Right Char 3 ,Caesar=>Key=3
                    : i % 3 == 1 ? Caesar.MainCaesar(Text[i].ToString(), 5, true)//Role 2:Shift Right Char 5 ,Caesar=>Key=5
                    : Caesar.MainCaesar(Text[i].ToString(), 7, true))}";//Role 3:Shift Right Char 7 ,Caesar=>Key=7

            return NewText;
        }
    }
}
