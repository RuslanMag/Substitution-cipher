using System;
using System.Text;
using System.Text.RegularExpressions;

namespace Lab1_Task1
{
    internal class CipherCore
    {
        public char[] alphabet = {' ', 'А', 'Б', 'В', 'Г', 'Д', 'Е', 'Ж',
            'З', 'И', 'Й', 'К', 'Л', 'М', 'Н', 'О', 'П',
            'Р', 'С', 'Т', 'У', 'Ф', 'Х', 'Ц', 'Ч', 'Ш',
            'Щ', 'Ъ', 'Ы', 'Ь', 'Э', 'Ю', 'Я' };

        public char[] newAlphabet;

        public string originalText;
        public string convertedText;

        public void ShuffleAlphabet(char[] a)
        {
            Random random = new Random();
            for (int i = 0; i < a.Length; i++)
            {
                int b = random.Next(i);
                char c = a[i];
                a[i] = a[b];
                a[b] = c;
            }
        }

        public void CopyAlphabet(char[] a)
        {
            newAlphabet = new char[a.Length];

            a.CopyTo(newAlphabet, 0);
        }

        private string Strip(string str)
        {
            str = str.ToUpper();

            var reg = new Regex($"[{'А'}-{'Я'},{" "}]");

            StringBuilder builder = new StringBuilder();
            foreach (Match match in reg.Matches(str.ToUpper()))
            {
                builder.Append(match.Value[0]);
            }

            return builder.ToString();
        }

        public String Encrypt(String text)
        {
            originalText = Strip(text);

            char[] origTextArr = originalText.ToCharArray();
            char[] encrTextArr = new char[origTextArr.Length];
            for (int i = 0; i < origTextArr.Length; i++)
            {
                int charNum = 0;
                for (int j = 0; j < alphabet.Length; j++)
                {
                    if (origTextArr[i] == alphabet[j])
                    {
                        charNum = j;
                    }
                }
                encrTextArr[i] = newAlphabet[charNum];
            }

            convertedText = new string(encrTextArr);
            return convertedText;
        }

        public String Decrypt(String text)
        {
            originalText = Strip(text);

            char[] encrTextArr = originalText.ToCharArray();
            char[] decrTextArr = new char[encrTextArr.Length];
            for (int i = 0; i < encrTextArr.Length; i++)
            {
                int charNum = 0;
                for (int j = 0; j < newAlphabet.Length; j++)
                {
                    if (encrTextArr[i] == newAlphabet[j])
                    {
                        charNum = j;
                    }
                }
                decrTextArr[i] = alphabet[charNum];
            }

            convertedText = new string(decrTextArr);
            return convertedText;
        }
    }
}
