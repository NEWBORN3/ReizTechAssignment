using System;

namespace AnalogueClock
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool isRunning = true;
            while(isRunning)
            {
                //Description
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Welcome, This Console application will let you calculate the lesser angle bettwen hours and minutes in an analogue clock");
                Console.WriteLine("**The apps takes a valid user input for the values of hour and minute means 1 - 12 for hour value  and 0 - 60 for minute value**");
                Console.WriteLine("**The apps keeps running to let you calculate if you press 'y', when it promot youto do so**");
                Console.WriteLine("-----Enjoy----");
                Console.ResetColor();

                //Get hours and minute value from the user
                int hour = GetValidNumberInput("Input Hour: ");
                while (hour == 0 || hour > 12)
                {
                    Console.WriteLine("Error: Invalid Hour input. Please enter a valid hour (1 - 12).");
                    hour = GetValidNumberInput("Input Hour: ");
                }
                int minute = GetValidNumberInput("Input Minute: ");
                while (minute > 60)
                {
                    Console.WriteLine("Error: Invalid Hour input. Please enter a valid hour (0 - 60).");
                    minute = GetValidNumberInput("Input Hour: ");
                }

                //algorthim to calculate the lesser degree
                double hourAng = (hour % 12 + minute / 60.0) * 30; //just in case the hours is not in the range of 12
                Console.WriteLine($"{hour % 12}-{minute / 60.0}");
                double minuteAng = minute * 6;
                double ang = Math.Abs(hourAng - minuteAng);
                ang = ang > 180 ? 360 - ang : ang;
                Console.WriteLine($"lesser angle in degrees between hours arrow and minutes arrow is: {ang}");
                Console.WriteLine("If you want to continue calculating press 'Y': ");
                string ans = Console.ReadLine()!;
                isRunning = ans.ToLower().Equals("y"); 
            }
            

        }

        static int GetValidNumberInput(string promptMessage)
        {
            int num = 0;
            bool isValid = false;

            while (!isValid)
            {
                Console.Write(promptMessage);
                isValid = int.TryParse(Console.ReadLine(), out num);
                if (!isValid) Console.WriteLine("Error: Invalid input. Please enter a valid number.");
            }
            return num;

        }
    }
}