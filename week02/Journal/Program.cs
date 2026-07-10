using System;
using System.Collections.Generic;


class Program
{
    static void Main(string[] args)
    {

        Journal journal = new Journal();


        List<string> prompts = new List<string>()
        {
            "Who was the most interesting person I interacted with today?",
            "What was the best part of my day?",
            "How did I see the hand of the Lord in my life today?",
            "What was the strongest emotion I felt today?",
            "If I had one thing I could do over today, what would it be?",
            "What is something new I learned today?",
            "What is something I am grateful for today?"
        };


        List<string> quotes = new List<string>()
        {
            "Rest at the end, not the middle.",
            "Nothing changes if nothing changes.",
            "Believe you can and you're halfway there.",
            "Your future depends on what you do today.",
            "What is yours will cross oceans to find you.",
            "Disipline will run when motivation walks.",
            "Small steps every day lead to big results."
        };


        bool running = true;


        // Creativity addition:
        // added a dialy qoute for motivation 


        while (running)
        {

            Console.WriteLine("Journal Menu");
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display journal");
            Console.WriteLine("3. Save journal");
            Console.WriteLine("4. Load journal");
            Console.WriteLine("5. Quit");


            Console.Write("Select an option: ");
            string choice = Console.ReadLine();



            if (choice == "1")
            {

                Random random = new Random();


                string randomPrompt =
                    prompts[random.Next(prompts.Count)];


                string randomQuote =
                    quotes[random.Next(quotes.Count)];



                Console.WriteLine();
                Console.WriteLine("✨ Quote of the Day:");
                Console.WriteLine(randomQuote);
                Console.WriteLine();


                Console.WriteLine(randomPrompt);
                Console.Write("> ");

                string response = Console.ReadLine();



                Entry newEntry = new Entry();


                newEntry._date =
                    DateTime.Now.ToString("yyyy-MM-dd");


                newEntry._prompt = randomPrompt;

                newEntry._response = response;

                newEntry._quote = randomQuote;



                journal.AddEntry(newEntry);


                Console.WriteLine();
                Console.WriteLine("Entry saved!");
            }



            else if (choice == "2")
            {
                journal.DisplayAll();
            }



            else if (choice == "3")
            {

                Console.Write("Enter filename to save: ");
                string filename = Console.ReadLine();


                journal.SaveToFile(filename);


                Console.WriteLine("Journal saved successfully!");
            }



            else if (choice == "4")
            {

                Console.Write("Enter filename to load: ");
                string filename = Console.ReadLine();


                journal.LoadFromFile(filename);


                Console.WriteLine("Journal loaded successfully!");
            }



            else if (choice == "5")
            {
                running = false;

                Console.WriteLine("Goodbye!");
            }



            else
            {
                Console.WriteLine("Invalid option. Try again.");
            }


            Console.WriteLine();
        }

    }
}