using System;

namespace countWords
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = "abcH1222 Hola ofaofh Hola, Hola,Hol";
            string word = "Hola";
            int wordCount = 0;

            for (int i = 0; i < text.Length; i++)
            {
                string character = text.Substring(i,1);

                // if character matches the first element of s word
                if(character == word.Substring(0,1) && searchWord(text, i, word)){
                    wordCount++;
                    i+=word.Length; // forward i to avoid searching within the found word
                }
            }

            Console.WriteLine($"{word} was found {wordCount} times");
        }

        private static bool searchWord(string text, int textIndex, string word){
            
            for (int i = 0; i < word.Length; i++)
            {
                if(word.Substring(i,1) != text.Substring(textIndex, 1))
                    return false;
                
                if(textIndex +1 < text.Length)
                    textIndex++;
            }

            return true;
        }
    }
}
