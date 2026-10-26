namespace Search_Task_2
{
    internal class Program
    {
        //write a program that checks if a word contains any vowels. If the word does not contain any vowels, throw an exception with a message indicating that the word does not contain any vowels.
        static void Main(string[] args)
        {
            //try => detects exceptions that occur in a block of code and allows you to handle them gracefully.
            //catch => catches the exception that is thrown in the try block and allows you to handle it.(تتعامل مع Exception).
            try
            {
                IsVowels("mazen");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        static void IsVowels(string word)
        {
            bool isvowel = false;
            for (int i = 0; i < word.Length; i++)
            { 
              char c = word[i];
                if (c == 'a' || c == 'e' || c == 'i' || c == 'o' || c == 'u')
                {
                    isvowel = true;
                    break;
                }
            }
            if (!isvowel)
            {
                throw new Exception("The word does not contain any vowels.");
            }
            
        }
    }
}
