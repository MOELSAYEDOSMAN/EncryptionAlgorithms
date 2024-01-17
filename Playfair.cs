using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib_SC
{
    public class Playfair
    {
        private const string Eng_Char = "ABCDEFGHIKLMNOPQRSTUVWXYZ";
        //Main Function
        public static string MainPlayfair(string text, string Key, bool EncrptionBool)
        => EncrptionBool ? EncrptionPlayfair(CheackNewText(text.ToUpper()), Full_Chars(Key.ToUpper())) : DecryptionPlayfair(CheackNewText(text.ToUpper()), Full_Chars(Key.ToUpper()));

        #region Encrption
        private static string EncrptionPlayfair(string s, List<char> Mat5X5)
        {
            string EncroString = "";
            int Length = s.Length;
            for (int i = 0; i < Length; i += 2)
            {
                //Char 1
                int IndexChar1 = Mat5X5.IndexOf(s[i]);
                var PosChar1 = ReturnPostion(IndexChar1);
                //Char 2
                int IndexChar2 = Mat5X5.IndexOf(s[i + 1]);
                var PosChar2 = ReturnPostion(IndexChar2);
                EncroString = $"{EncroString}{SelectEncrRole(C1: (PosChar1, IndexChar1), C2: (PosChar2, IndexChar2), Mat5X5)}";
            }
            return EncroString;
        }
        //Chose Role
        private static string SelectEncrRole(((int row, int col) pos, int Index) C1, ((int row, int col) pos, int Index) C2, List<char> Mat5X5)
                => (C1.pos.row == C2.pos.row) ? EncrRoleRol((C1.pos.col, C1.Index), (C2.pos.col, C2.Index), Mat5X5)
                : (C1.pos.col == C2.pos.col) ? EncrRoleCOl((C1.pos.row, C1.Index), (C2.pos.row, C2.Index), Mat5X5)
                : EncrRoleDiff((C1.pos.col, C1.Index), (C2.pos.col, C2.Index), Mat5X5);
        //Row
        private static string EncrRoleRol((int Col, int Index) C1, (int Col, int Index) C2, List<char> Mat5X5)
        => $"{((C1.Col == 4) ? Mat5X5[C1.Index - 4] : Mat5X5[C1.Index + 1])}{((C2.Col == 4) ? Mat5X5[C2.Index - 4] : Mat5X5[C2.Index + 1])}";
        //Col
        private static string EncrRoleCOl((int row, int Index) C1, (int row, int Index) C2, List<char> Mat5X5)
        => $"{((C1.row == 4) ? Mat5X5[C1.Index - (20)] : Mat5X5[C1.Index + (5)])}{((C2.row == 4) ? Mat5X5[C2.Index - 20] : Mat5X5[C2.Index + 5])}";
        //Diff
        private static string EncrRoleDiff((int Col, int Index) C1, (int Col, int Index) C2, List<char> Mat5X5)
        => $"{((C1.Col > C2.Col) ? Mat5X5[C1.Index - (C1.Col - C2.Col)] : Mat5X5[C1.Index - C1.Col + C2.Col])}{((C2.Col > C1.Col) ? Mat5X5[C2.Index - (C2.Col - C1.Col)] : Mat5X5[C2.Index - C2.Col + C1.Col])}";
        #endregion


        #region Desencrption
        private static string DecryptionPlayfair(string s, List<char> Mat5X5)
        {
            string EncroString = "";
            int Length = s.Length;
            for (int i = 0; i < Length; i += 2)
            {
                //Char 1
                int IndexChar1 = Mat5X5.IndexOf(s[i]);
                var PosChar1 = ReturnPostion(IndexChar1);

                //Char 2
                int IndexChar2 = Mat5X5.IndexOf(s[i + 1]);
                var PosChar2 = ReturnPostion(IndexChar2);

                EncroString = $"{EncroString}{SelectDecrypRole(C1: (PosChar1, IndexChar1), C2: (PosChar2, IndexChar2), Mat5X5)}";
            }
            EncroString = DecrChangeNewText(EncroString);//Remove X And Z
            
            return EncroString;
        }
        //Chose Role
        private static string SelectDecrypRole(((int row, int col) pos, int Index) C1, ((int row, int col) pos, int Index) C2, List<char> Mat5X5)
                => (C1.pos.row == C2.pos.row) ? DscRoleRol((C1.pos.col, C1.Index), (C2.pos.col, C2.Index), Mat5X5)
                : (C1.pos.col == C2.pos.col) ? DecRoleCOl((C1.pos.row, C1.Index), (C2.pos.row, C2.Index), Mat5X5)
                : DecrRoleDiff((C1.pos.col, C1.Index), (C2.pos.col, C2.Index), Mat5X5);
        //Row
        private static string DscRoleRol((int Col, int Index) C1, (int Col, int Index) C2, List<char> Mat5X5)
        => $"{((C1.Col == 0) ? Mat5X5[C1.Index + 4] : Mat5X5[C1.Index - 1])}{((C2.Col == 0) ? Mat5X5[C2.Index + 4] : Mat5X5[C2.Index - 1])}";
        //Col
        private static string DecRoleCOl((int row, int Index) C1, (int row, int Index) C2, List<char> Mat5X5)
        => $"{((C1.row == 0) ? Mat5X5[C1.Index + (20)] : Mat5X5[C1.Index - (5)])}{((C2.row == 0) ? Mat5X5[C2.Index + 20] : Mat5X5[C2.Index - 5])}";
        //Diff
        private static string DecrRoleDiff((int Col, int Index) C1, (int Col, int Index) C2, List<char> Mat5X5)
        => $"{((C1.Col > C2.Col) ? Mat5X5[C1.Index - (C1.Col - C2.Col)] : Mat5X5[C1.Index - C1.Col + C2.Col])}{((C2.Col > C1.Col) ? Mat5X5[C2.Index - (C2.Col - C1.Col)] : Mat5X5[C2.Index - C2.Col + C1.Col])}";
         private static string DecrChangeNewText(string OldText)
         {
            
            int NumberCharXinOLdText = OldText.Where(x=>x=='X').Count();//"--x---x--x"=>3
            while(NumberCharXinOLdText!=0)
            {
                int indexCharX = OldText.IndexOf('X');
                if ((indexCharX>0) && (indexCharX + 1 != OldText.Length) && (OldText[indexCharX - 1] == OldText[indexCharX + 1]))
                {
                     OldText = OldText.Remove(indexCharX, 1);
                }
                NumberCharXinOLdText--;
            }

            if (OldText[OldText.Length - 1] == 'Z')
                OldText = OldText.Remove(OldText.Length - 1);
            return OldText;
         }
        #endregion


        //Swip String If Need 
        private static string CheackNewText(string OldText)
        {
            string NewText = "";
            int Length = OldText.Length;
            for (int i = 0; i < Length; i += 2)
            {
                //If Char Double Like("HELLOW")=>(LL)=>(LX)=>("HELXLOW")
                if ((i + 1) != Length && (OldText[i] == OldText[i + 1]))
                {
                    NewText = $"{NewText}{OldText[i]}X";
                    i--;
                }
                else if ((i + 1) == Length)
                    NewText = $"{NewText}{OldText[i]}";
                else
                    NewText = $"{NewText}{OldText[i]}{OldText[i + 1]}";
            }
            //If String Not EVEN=> ADD Z
            return NewText.Length % 2 == 0 ? NewText : $"{NewText}Z";
        }

        //Return Postion Char
        private static (int row, int col) ReturnPostion(int val)
            => (row: val / 5, col: val % 5);

        //Full Matrix
        public static List<char> Full_Chars(string key)
        {
            List<char> Mat5X5 = new List<char>();//len=25
            
            key.ToList().ForEach(c =>
                        {
                            if (!Mat5X5.Contains(c))
                                Mat5X5.Add(c);
                        });

            Eng_Char.ToList().ForEach(c =>
            {
                if (!Mat5X5.Contains(c) && (c == 'I' && !Mat5X5.Contains(item: 'J') || c != 'I'))
                    Mat5X5.Add(c);
            });
            return Mat5X5;
        }
    }
}
