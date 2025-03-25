using System.Globalization;
using System.Xml;

namespace bulls_and_cows
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string play_opt = "yes";
            List<int> leadearboard = new List<int>();
            
            while (play_opt != "no")
            {
                int digits = 0;
                bool leave_choice = false;
                Console.WriteLine(" ");
                Console.WriteLine("Welcome to the cows and bulls game!");
                bool play_choice_valid = true;
                int play_choice = 0;
                do
                {
                    // finsih folproofin menu
                    Console.WriteLine("Choose out of the 3 options: ");
                    Console.WriteLine("");
                    Console.WriteLine("1. Play game \r\n\r\n2. Show top score \r\n\r\n3. Quit ");
                    Console.WriteLine("");
                    Console.WriteLine("input: ");
                    int play_choice = Convert.ToInt32(Console.ReadLine());
                }while(play_choice_valid != true);
                if (play_choice == 2)
                {
                    foreach (int score in leadearboard)
                    {
                        Console.WriteLine((leadearboard.IndexOf(score) + 1) + ". " + score + " guesses");
                    }
                    play_choice = 1;
                }
                if (play_choice == 1)
                {
                    Console.WriteLine("How many digits of the number do you want play with (min 4 ,max 9): ");
                    digits = Convert.ToInt32(Console.ReadLine());
                }
                if (play_choice == 3)
                {
                    leave_choice = true;
                    if (leave_choice == true)
                    {
                        break;
                    }
                }
                bool choice = false;
                int nums;
                string num_str = "";

                int min_num = 0;
                int max_num = 0;
                if (digits == 4)
                {
                    min_num = 1023;
                    max_num = 9876;
                }
                else if (digits == 5)
                {
                    min_num = 10234;
                    max_num = 98765;
                }
                else if (digits == 6)
                {
                    min_num = 102345;
                    max_num = 987654;
                }
                else if (digits == 7)
                {
                    min_num = 1023456;
                    max_num = 9876543;
                }
                else if (digits == 8)
                {
                    min_num = 10234567;
                    max_num = 98765432;
                }
                else if (digits == 9)
                {
                    min_num = 102345678;
                    max_num = 987654321;
                }
                //while (choice != true)
                //{
                //    choice = true;
                //    Random r = new Random();
                //    nums = r.Next(min_num, max_num);
                //    for (int i = 0; i < digits; i++)
                //    {
                //        for (int j = 0; j < digits; j++)
                //        {
                //            if (j > i)
                //            {
                //                num_str = Convert.ToString(nums);
                //                if (num_str[i] == num_str[j])
                //                {
                //                    choice = false;
                //                }
                //            }
                //        }
                //    }
                //};0
                nums = 1234;
                num_str = "1234";
                //Console.WriteLine(num_str);
                int bulls = 0;
                int cows = 0;
                bool choice2 = false;
                int user_num = 0;
                string user_str = "";
                int guesses = 0;

                Console.WriteLine(" ");
                while (bulls != digits)
                {
                    choice2 = false;
                    while (choice2 != true)
                    {
                        if (guesses == 5 || guesses == 10 || guesses == 15)
                        {
                            Console.WriteLine("Do you want the answer [true/false] : ");
                            leave_choice = Convert.ToBoolean(Console.ReadLine());
                            if (leave_choice == true)
                            {
                                break;
                            }
                        }
                        choice2 = true;
                        Console.WriteLine($"Guess a {digits} digit number to match the random {digits} digit number generated");
                        Console.WriteLine("The digits should not repeat");
                        Console.WriteLine("input: ");
                        user_num = Convert.ToInt32(Console.ReadLine());
                        user_str = Convert.ToString(user_num);
                        if (user_str.Length != digits)
                        {
                            choice2 = false;
                        }


                        if (!(user_num >= min_num && user_num <= max_num))
                        {
                            choice2 = false;

                        }

                        for (int i = 0; i < digits; i++)
                        {
                            for (int j = 0; j < digits; j++)
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
                        if (choice2==false)
                        {
                            Console.WriteLine(" ");
                            Console.WriteLine("Invalid Input, Try again. ");
                            Console.WriteLine(" ");
                        }
                    }
                    if (leave_choice == true)
                    {
                        break;
                    }
                    bulls = 0;
                    cows = 0;
                    for (int i = 0; i < digits; i++)
                    {
                        for (int j = 0; j < digits; j++)
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
                    leadearboard.Add(guesses);
                    leadearboard.Sort();

                    Console.WriteLine($"It took you {guesses} guesses to get the right number");
                    Console.WriteLine(" ");

                    Console.WriteLine("Do you want to see your top scores [yes/no]: ");
                    string tpsc_opt = Console.ReadLine().ToLower();
                    if (tpsc_opt == "yes")
                    {
                        for (int i =0; i <leadearboard.Count; i++)
                        {
                            Console.WriteLine(i+1+". " + leadearboard[i]+" guesses");
                        }
                    }
                }
                Console.WriteLine(" ");
                Console.WriteLine("The number was " + num_str);
                Console.WriteLine(" ");
                Console.WriteLine("Do you want to play again: [yes/no]");
                play_opt = Console.ReadLine().ToLower();
            }
            Console.WriteLine("");
            Console.WriteLine("Goodbye!");
        }
    }
}
