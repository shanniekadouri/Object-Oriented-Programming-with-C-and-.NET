namespace B19_Ex01_4
{
    using System;
    public class Program
    {
        public static void Main()
        {
            string stringInput = userInput();

            // is palindrome
            bool tempValue = false;
            bool palindrome = isPalindrome(stringInput, tempValue);

            // divide by 3
            string msg = "";
            if(long.TryParse(stringInput, out long numberInput))
            {
                bool divides = divideBy3(numberInput);
                msg = string.Format(
                    @"The input is a palindrome - {0},
The input is a multiplication of 3 - {1}", palindrome, divides);
            }
            else
            {
                int numberOfLower = checkLowerCase(stringInput);
                msg = string.Format(
                    @"The input is a palindrome - {0},
The number of lower case letters is - {1}", palindrome, numberOfLower);
            }
            System.Console.WriteLine(msg);
            System.Console.WriteLine("Press 'enter' to exit program");
            System.Console.ReadLine(); 
        }

        private static bool isPalindrome(string io_UserInput, bool i_Palindrome)
        {
            if (io_UserInput.Length == 2)
            {
                i_Palindrome = io_UserInput[0] == io_UserInput[1];
            }
            else if (io_UserInput[0] != io_UserInput[io_UserInput.Length - 1])
            {
                i_Palindrome = false;
            }
            else
            {
                i_Palindrome = isPalindrome(io_UserInput.Substring(1, io_UserInput.Length - 2), i_Palindrome);
            }
            return i_Palindrome;
        }

        private static bool divideBy3(long io_inputNumber)
        {
            return io_inputNumber % 3 == 0;
        }

        private static int checkLowerCase(string i_InputString)
        {
            int countLowerCase = 0;
            foreach(char c in i_InputString)
            {
                if(c > 'a' && c < 'z')
                {
                    countLowerCase++;
                }
            }
            return countLowerCase;
        }
        private static string userInput()
        {
            System.Console.WriteLine("Please enter 12 charecters input (and then press 'enter')");
            string stringInput = System.Console.ReadLine();

            bool validInput = false;
            long intInput = 0; // if the input is an integer value
            while(!validInput)
            {
                if(stringInput.Length != 12)
                {
                    stringInput = invalidInput();
                    continue;
                }
                char firstChar = stringInput[0];

                // check if the input is a number
                if(Char.IsDigit(firstChar)) {
                    if(!long.TryParse(stringInput, out intInput))
                    {
                        stringInput = invalidInput();
                        continue;
                    }
                }

                // check if the input contains only letters
                else
                {
                    foreach(char c in stringInput)
                    {
                        if(!Char.IsLetter(c))
                        {
                            stringInput = invalidInput();
                            continue;
                        }
                    }
                }
                validInput = true;
            }
           
            return stringInput;
        }

        private static string invalidInput()
        {
            System.Console.WriteLine("Invalid input- please try again (and then press 'enter')");
            return System.Console.ReadLine();
        }
        
    }

}
