namespace Lib_SC
{
    public class Caesar

    {
        //Main Function 
        //encrption:is old Text
        //Key:num to Encryption  or Decryption 
        //enc:Enc?DisEnc
        public static string MainCaesar(string encrption, int key, bool enc)
        {
            key = enc ? key : -key;//Encryption:Decryption
            string newString = "";
            encrption.ToList()
                .ForEach(x => newString = $"{newString}{EncryptionChar(x, key)}");
            return newString;
        }
        //cheack If Char small Or Captial 
        //And Return New Char
        private static char EncryptionChar(char c, int key) =>
            cheackChar(c).Invoke(c, key);
        //IF Char small=> retun (Function)ConverChar_Small
        //Else=>(Function)ConverChar_Captial
        private static Func<char, int, char> cheackChar(char c) =>
            c >= 97 && c <= 122 ? ConverChar_Small : ConverChar_Capital;
        //Conver Char small (c:a,key:2)=>a=c
        //a 97 //z 122
        private static char ConverChar_Small(char c, int key)
        {
            int index = c;
            index = index + key;
            index = index >= 97 && index <= 122 ? index : (index > 122) ? index - 26 : index + 26;
            return (char)index;
        }
        //Conver Char Captial (c:A,key:2)=>A=C
        //A 65 //Z 90
        private static char ConverChar_Capital(char c, int key)
        {
            int index = c;
            index = index + key;
            index = index >= 65 && index <= 90 ? index : (index > 90) ? index - 26 : index + 26;
            return (char)index;
        }
    }
}