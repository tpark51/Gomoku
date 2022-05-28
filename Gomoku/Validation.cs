using System;
namespace Gomoku
{
    public class Validation
    {
        private static void Prompt2Continue()
        {
            Console.WriteLine("=====================================");
            Console.WriteLine("Press any key to continue...");

            Console.ReadLine();
        }

        private static string PromptRequired(string message)
        {
            string res = PromptUser(message);
            while (string.IsNullOrEmpty(res))
            {
                Console.WriteLine("Input required❗");
                res = PromptUser(message);
            }

            return res;
        }

        public static string PromptUser(string message)
        {
            Console.Write(message);
            return Console.ReadLine() ?? string.Empty;
        }

        internal static int PromptUser4Int(string message, int min = Int32.MinValue, int max = Int32.MaxValue)
        {
            int result;
            while (!(int.TryParse(PromptUser(message), out result)) || result < min || result > max)
            {
                PromptUser($@"Invalid Input, must be between {min} and {max}
Press Enter to Continue");
            }

            return result;
        }
    }
}
