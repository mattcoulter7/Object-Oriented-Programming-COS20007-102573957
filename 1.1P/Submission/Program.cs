//References:
//https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/arrays/single-dimensional-arrays
//http://csharp.net-informations.com/collection/csharp-array.htm
//https://social.msdn.microsoft.com/Forums/vstudio/en-US/25963105-d8c1-4e98-987d-4a970a185afd/how-to-show-all-text-of-a-string-array-in-a-messageboxshow?forum=csharpgeneral
//https://www.programiz.com/csharp-programming/basic-input-output
//https://stackoverflow.com/questions/14036276/printing-strings
//https://www.programiz.com/csharp-programming/if-else-statement
//https://stackoverflow.com/questions/3374909/do-else-if-statements-exist-in-c
//http://zetcode.com/lang/csharp/arrays/
//https://www.geeksforgeeks.org/c-sharp-tolower-method/
using System;

namespace HelloWorld
{
    class Program
    {
        static void Main()
        {
            //Hello World message, as required
            Message myMessage;
            myMessage = new Message("Hello World...");
            myMessage.Print();

            //Array containing strings that are returned after user submits name
            Message[] messages = new Message[5];
            messages[0] = new Message("She is Matt's Mother");
            messages[1] = new Message("He is Matt's Father");
            messages[2] = new Message("He is Matt's Brother");
            messages[3] = new Message("She is Matt's Sister");
            messages[4] = new Message("Non-related");

            //User input
            string input;
            Console.Write("Enter Name: ");
            input = new string(Console.ReadLine().ToLower());

            //conditional if statements that return different message depending on the name that is enetered
            if (string.Compare(input, "cindy") == 0)
            {
                Console.WriteLine(messages[0].text);
            }
            else if (string.Compare(input, "allan") == 0)
            {
                Console.WriteLine(messages[1].text);
            }
            else if (string.Compare(input, "shane") == 0)
            {
                Console.WriteLine(messages[2].text);
            }
            else if (string.Compare(input, "cindy") == 0)
            {
                Console.WriteLine(messages[3].text);
            }
            else
            {
                Console.WriteLine(messages[4].text);
            }
            Main();
        }
    }
}
