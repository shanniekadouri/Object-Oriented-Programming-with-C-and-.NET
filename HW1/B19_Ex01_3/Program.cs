namespace B19_Ex01_3
{
    using System.Text;
    public class Program
    {
        public static void Main()
        {
            int getInputUser = userInput();
            sandClockAdvanced(getInputUser, 0, new StringBuilder());
            System.Console.WriteLine("Press 'enter' to exit");
            System.Console.ReadLine();
        }

        private static void sandClockAdvanced(int io_Hight, int io_NumOfRows, StringBuilder i_StringToPrint)
        {
            B19_Ex01_2.Program.SandClock(io_Hight, io_NumOfRows, i_StringToPrint);
        }

        private static int userInput()
        {
            System.Console.WriteLine("Please enter a desired hight of send clock (and then press 'enter')");
            string stringInput = System.Console.ReadLine();
            bool validInput = false;
            int hight = 0;
            while (!validInput)
            {
                bool success = int.TryParse(stringInput, out hight);
                if (!success)
                {
                    System.Console.WriteLine("Invalid input, please try again");
                    stringInput = System.Console.ReadLine();
                }
                else
                {
                    validInput = true;
                }
            }
            return hight;
        }
    }
}