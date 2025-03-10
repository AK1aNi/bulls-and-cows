using System.Xml;

namespace bulls_and_cows
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool choice = false;
            int nums;
            string num_str = "";

            while (choice != true)
            {
                choice = true;
                Random r = new Random();
                nums = r.Next(1023, 9876);
                for (int i = 0; i <= 3; i++)
                {
                    for (int j = 0; j <= 3; j++)
                    {
                        if (j > i)
                        {
                            num_str = Convert.ToString(nums);
                            if (num_str[i] == num_str[j])
                            {
                                choice = false;
                            }
                        }
                    }
                }
            }
            int bulls = 0;
            int cows = 0;
            bool choice2 = false;
            int user_num = 0;
            string user_str = "";
            int guesses = 0;
            bool leave_choice = false;

            while (bulls != 4)
            {
                choice2 = false;
                while (choice2 != true)
                {
                    if (guesses ==5 || guesses == 10 || guesses == 15)
                    {
                        Console.WriteLine("Do you want the answer [true/false] : ");
                        leave_choice = Convert.ToBoolean(Console.ReadLine());
                        if (leave_choice == true)
                        {
                            break;
                        }
                    }
                    choice2 = true;
                    Console.WriteLine("Guess a 4 digit number to match the random 4 digit number generated");
                    Console.WriteLine("The digits should not repeat" +
                                      " It should be 4 digits");
                    Console.WriteLine("input: ");
                    user_num = Convert.ToInt32(Console.ReadLine());
                    user_str = Convert.ToString(user_num);
                    if (user_str.Length != 4)
                    {
                        choice2 = false;
                    }
                    if (!(user_num >= 1023 && user_num <= 9876))
                    {
                        choice2 = false;

                    }

                    for (int i = 0; i <= 3; i++)
                    {
                        for (int j = 0; j <= 3; j++)
                        {
                            if (j > i)
                            {
                                if (user_str[i] == user_str[j])
                                {
                                    choice2 = false;
                                }
                            }

                        }
                    }
                }
                if (leave_choice==true)
                {
                    break;
                }
                bulls = 0;
                cows = 0;
                for (int i = 0; i <= 3; i++)
                {
                    for (int j = 0; j <= 3; j++)
                    {
                        if (i == j)
                        {
                            if (num_str[i] == user_str[j])
                            {
                                bulls = bulls + 1;
                            }
                        }
                        else
                        {
                            if (num_str[i] == user_str[j])
                            {
                                cows = cows + 1;
                            }
                        }
                    }
                }
                Console.WriteLine("Cows: " + cows);
                Console.WriteLine("Bulls: " + bulls);
                Console.WriteLine(" ");
                guesses = guesses + 1;
            }
            if (leave_choice == false)
            {
                Console.WriteLine($"It took you {guesses} guesses to get the right number");
            }
            Console.WriteLine(" ");
            Console.WriteLine("The number was"+num_str);

        }
    }
}
