namespace B19_Ex01_2
{
    using System.Text;

    public class Program
    {
        public static void Main()
        {
            StringBuilder sandClockString = new StringBuilder();
            SandClock(5, 0, sandClockString);
            System.Console.WriteLine("Press 'enter' to exit");
            System.Console.ReadLine();
        }
        public static void SandClock(int io_Hight, int io_NumOfRows, StringBuilder i_StringToPrint)
        {
            if (io_Hight == io_NumOfRows)
            {
                System.Console.WriteLine(i_StringToPrint);
                return;
            }

            if ((io_Hight / 2) > io_NumOfRows)
            {
                i_StringToPrint.AppendLine(stringOfStars(io_Hight - (2 * io_NumOfRows), io_NumOfRows));
            }
            else
            {
                i_StringToPrint.AppendLine(stringOfStars((io_NumOfRows * 2) - io_Hight + 2, io_Hight - io_NumOfRows - 1));
            }

            SandClock(io_Hight, io_NumOfRows + 1, i_StringToPrint);
        }


        private static string stringOfStars(int i_NumOfStars, int i_NumOfSpaces)
        {
            StringBuilder currentStr = new StringBuilder();
            for (int i = 0; i < (i_NumOfStars + i_NumOfSpaces); i++)
            {
                if (i < i_NumOfSpaces)
                {
                    currentStr.Append(" ");
                }
                else
                {
                    currentStr.Append("*");
                }
            }
            return currentStr.ToString();
        }
    }
}