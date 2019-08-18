namespace B19_Ex01_1
{
    public class Program
    {
        public static void Main()
        {
            binaryToInt();
        }


        private static void binaryToInt()
        {
            int[] userNumbers = userInput();

            int numberOfZero = 0;
            int numberOfOne = 0;
            int numberOfPower2 = 0;
            int numberOfIncreasingSequence = 0;

            int[] finalResults = new int[4];

            for (int i = 0; i < userNumbers.Length; i++)
            {
                int currentNumber = 0;
                for (int j = 0; j < 8; j++)
                {
                    int mod = userNumbers[i] % 2;
                    currentNumber += (int)System.Math.Pow(2, j) * mod;
                    userNumbers[i] /= 10;
                    if (mod == 0)
                    {
                        numberOfZero++;
                    }
                    else
                    {
                        numberOfOne++;
                    }
                }
                finalResults[i] = currentNumber;
                if (powerOf2(currentNumber))
                {
                    numberOfPower2++;
                }
                if (strictlyIncreasing(currentNumber))
                {
                    numberOfIncreasingSequence++;
                }
            }

            double averageOfZero = averageOfDigits(numberOfZero, finalResults.Length);
            double averageOfOne = averageOfDigits(numberOfOne, finalResults.Length);
            double averageOfInputs = averageOfNumbers(finalResults);

            string msg = string.Format(
                @"The numbers are {0}, {1}, {2}, {3}
The average of zeros is {4},
The average of ones is {5},
{6} of the numbers are power of 2,
{7} of them are strictly monotonically increasing sequence,
Their average is {8}",
                finalResults[0], finalResults[1], finalResults[2], finalResults[3], averageOfZero, averageOfOne, numberOfPower2, numberOfIncreasingSequence, averageOfInputs);
            System.Console.WriteLine(msg);
            System.Console.WriteLine("Press 'enter' to exit");
            System.Console.ReadLine();
        }


        private static int[] userInput()
        {
            int[] userInput = new int[4];
            for (int i = 0; i < userInput.Length; i++)
            {
                System.Console.WriteLine("Please enter an 8 digit binary number of zeros and ones (and then press 'enter')");
                string currentInput = System.Console.ReadLine();

                bool validInput = false;
                int currentNumber = 0;

                while (!validInput)
                {
                    bool success = int.TryParse(currentInput, out currentNumber);
                    // if input is less then 8 digits or contains non digit charecters or can't parse 
                    if (currentInput.Length != 8 || !success)
                    {
                        System.Console.WriteLine("Invalid input - please try again (and then press 'enter')");
                        currentInput = System.Console.ReadLine();
                        continue;
                    }

                    // check if all charecters are only ones and zeros
                    foreach (char c in currentInput)
                    {
                        if ((c != '0') && (c != '1'))
                        {
                            System.Console.WriteLine("Invalid input - please try again (and then press 'enter')");
                            currentInput = System.Console.ReadLine();
                            continue;
                        }
                    }
                    // input is valid, exit while loop
                    validInput = true;
                }
                userInput[i] = currentNumber;
            }
            return userInput;
        }


        private static bool powerOf2(int i_Number)
        {
            double powerOf2 = System.Math.Log(i_Number);
            // if the double value is grater then the int value (round down) then its not a power of 2 
            return (powerOf2 > (int)powerOf2);
        }

        private static bool strictlyIncreasing(int i_Number)
        {
            bool increasingNumber = true;
            while (i_Number != 0)
            {
                int currentDigit = i_Number % 10;
                i_Number /= 10;
                int nextDigit = i_Number % 10;
                if (nextDigit >= currentDigit)
                {
                    increasingNumber = false;
                    break;
                }
            }
            return increasingNumber;
        }

        private static double averageOfDigits(int i_NumberOfDigit, int i_Length)
        {
            return ((double)i_NumberOfDigit) / i_Length;
        }

        private static double averageOfNumbers(int[] i_Numbers)
        {
            double sumOfAllNumbers = 0;
            for (int i = 0; i < i_Numbers.Length; i++)
            {
                sumOfAllNumbers += i_Numbers[i];
            }
            return ((double)sumOfAllNumbers) / i_Numbers.Length;
        }
    }
}

