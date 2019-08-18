namespace B19_Ex01_5
{
    using System
    class Program
    {
        public static void Main()
        {
            string stringInput = userInput();
            int[] minMaxValues = new int[2];
            biggestDigit(stringInput).CopyTo(minMaxValues, 0);
            int countDividesBy3 = divideBy3(stringInput);
            int biggerThanUnit = biggerThanUnitDigit(stringInput);

            string msg = string.Format(
                @"The largest digit value in the number is - {0},
the smallest digit value in the number is - {1},
the number of digits that are a multiplication of 3 is - {2},
the number of digits that are bigger than the unit digit is - {3}", minMaxValues[1], minMaxValues[0], countDividesBy3, biggerThanUnit);

            System.Console.WriteLine(msg);
            System.Console.WriteLine("Press 'enter' to exit program");
            System.Console.ReadLine();

        }

        private static int[] biggestDigit(string i_Input)
        {
            int maxDigit = 0;
            int minDigit = 9;
            int[] minMaxValues = new int[2];
            foreach (char c in i_Input)
            {
                int currentDigit = intParse(c.ToString());
                if (currentDigit > maxDigit)
                {
                    maxDigit = currentDigit;
                }
                if (currentDigit < minDigit)
                {
                    minDigit = currentDigit;
                }
            }
            minMaxValues[0] = minDigit;
            minMaxValues[1] = maxDigit;

            return minMaxValues;
        }

        private static int biggerThanUnitDigit(string i_StringInput)
        {
            int biggerThanUnit = 0;
            int unitDigit = intParse(i_StringInput[i_StringInput.Length - 1].ToString());
            foreach (char c in i_StringInput)
            {
                int currentDigit = intParse(c.ToString());
                if (currentDigit > unitDigit)
                {
                    biggerThanUnit++;
                }
            }
            return biggerThanUnit;
        }

        private static int divideBy3(string i_StringInput)
        {
            int countDividesBy3 = 0;
            foreach (char c in i_StringInput)
            {
                if (c % 3 == 0)
                {
                    countDividesBy3++;
                }
            }
            return countDividesBy3;
        }


        private static int intParse(string i_StringInput)
        {
            bool success = int.TryParse(i_StringInput, out int intInput);
            return intInput;
        }

        private static string userInput()
        {
            System.Console.WriteLine("Please enter 8 digit number (and then press 'enter')");
            string stringInput = System.Console.ReadLine();

            bool validInput = false;
            while (!validInput)
            {
                if (stringInput.Length != 8 || !int.TryParse(stringInput, out int intInput))
                {
                    System.Console.WriteLine("Invalid input - please try again (and then press 'enter')");
                    stringInput = System.Console.ReadLine();
                    continue;
                }
                validInput = true;
            }

            return stringInput;

        }
    }
}
