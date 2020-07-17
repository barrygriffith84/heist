using System;
using System.Collections.Generic;

namespace heist
{
    class Program
    {
        static void Main(string[] args)
        {

            List<Member> Team = new List<Member>();
            Member userInputMember = new Member();
            string nameInput;
            int teamSkillSum = 0;
            Random rnd = new Random();
            int trials = 0;
            int bankDiffLevel = 0;
            int successRuns = 0;
            int failRuns = 0;
            int userInputDiff = 0;


            Console.WriteLine("Plan Your Heist!");

            Console.WriteLine("Please enter the bank difficulty level");
               try
            {
                userInputDiff = int.Parse(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("Wrong input, try again");
            }


            while (userInputMember.Name != "")
            {
                userInputMember = new Member();
                Console.WriteLine("Please enter the team member's name.");
                nameInput = Console.ReadLine();

                userInputMember.Name = nameInput;


                userInputMember.SkillLevel = 0;
                if (userInputMember.Name != "")
                {
                    while (userInputMember.SkillLevel <= 0)
                    {
                        Console.WriteLine("Please enter a positive integer for the team member's skill level.");
                        try
                        {
                            userInputMember.SkillLevel = Int32.Parse(Console.ReadLine());
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("That is not the correct input.");
                        }
                    };


                }

                bool courageBool = false;

                if (userInputMember.Name == "")
                {
                    courageBool = true;
                }

                if (userInputMember.Name != "")
                {
                    while (userInputMember.CourageFactor < 0.0 || userInputMember.CourageFactor > 2.0 || courageBool == false)
                    {
                        courageBool = true;
                        Console.WriteLine("Please enter a decimal value between 0.0 and 2.0 for the team member's courage factor.");
                        try
                        {
                            userInputMember.CourageFactor = double.Parse(Console.ReadLine());
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("That is not the correct input.");
                        }
                    };
                    if (userInputMember.Name != "")
                        Team.Add(userInputMember);
                };
            }

            Console.WriteLine($"There are {Team.Count} team members");
            // Team.ForEach(thief => Console.WriteLine($"Name: {thief.Name}, Skill Level {thief.SkillLevel}, courage factor {thief.CourageFactor}"));

            Team.ForEach(thief => teamSkillSum += thief.SkillLevel);

            Console.WriteLine("How many trials would you like to run?");
            try
            {
                trials = int.Parse(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("Wrong input, try again");
            }

            for (int i = 0; i < trials; i++)
            {

                bankDiffLevel = userInputDiff;
                int luck = rnd.Next(-10, 10);
                bankDiffLevel += luck;

                Console.WriteLine($"The team's combined skill level is: {teamSkillSum}");
                Console.WriteLine($"The bank's difficulty level is: {bankDiffLevel}");


                if (teamSkillSum >= bankDiffLevel)
                {
                    Console.WriteLine("You have successfully robbed a bank!");
                    successRuns++;
                    
                }
                else
                {
                    Console.WriteLine("I see prison fornication in your future!");
                    failRuns++;
                }

            }

            Console.WriteLine($"The number of successful runs is: {successRuns}");
            Console.WriteLine($"The number of failed runs is: {failRuns}");





        }
    }
}
