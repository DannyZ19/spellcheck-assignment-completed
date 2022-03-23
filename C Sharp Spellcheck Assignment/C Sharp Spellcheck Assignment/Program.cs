// Spell Check Starter
// This start code creates two lists
// 1: dictionary: an array containing all of the words from "dictionary.txt"
// 2: aliceWords: an array containing all of the words from "AliceInWonderland.txt"

using System;
using System.Text.RegularExpressions;
using System.Diagnostics; // For Stopwatch


class Program
{
    public static void Main(string[] args)
    {
        


        

        // Load data files into arrays
        String[] dictionary = System.IO.File.ReadAllLines(@"data-files/dictionary.txt");
        String aliceText = System.IO.File.ReadAllText(@"data-files/AliceInWonderLand.txt");
        String[] aliceWords = Regex.Split(aliceText, @"\s+");



        // Print first 50 values of each list to verify contents
        Console.WriteLine("***DICTIONARY***");
        printStringArray(dictionary, 0, 50);

        Console.WriteLine("***ALICE WORDS***");
        printStringArray(aliceWords, 0, 50);

        // MENU \\ 

        do
        { 
        Console.WriteLine("\n1. Spell Check a Word (Linear Search)");
        Console.WriteLine("\n2. Spell Check a Word (Binary Search)");
        Console.WriteLine("\n3. Spell Check Alice in Wonderland (Linear Search)");
        Console.WriteLine("\n4. Spell Check Alice in Wonderland (Binary Search)");
        Console.WriteLine("\n5. Exit");


        Console.WriteLine("\nPlease select which search algorithm to use.");
        var selection = Console.ReadLine();
        if (selection == "1")
        {
                
                Console.WriteLine("Linear Search");

            Console.WriteLine("Please select a word to search for.");
            string item = Console.ReadLine();
                
                var timer = new Stopwatch();
                timer.Start();
                int index = LinearSearch(dictionary, item);

            if (index == -1)
            {

                Console.WriteLine("Not found");
            }
            else
            {

                Console.WriteLine("\nWord found at " + index);
                timer.Stop();

                Console.WriteLine($"\nSearch took {timer.Elapsed} .", dictionary.Length, timer.Elapsed);
                     
            }

        }

        if (selection == "2")
        {
                
                Console.WriteLine("Binary Search");

            Console.WriteLine("Please select a word to search for.");
            string item = Console.ReadLine();
                var timer2 = new Stopwatch();
                timer2.Start();
                int index = BinarySearch(dictionary, item);
            if (index == -1)
            {
                Console.WriteLine("Not found");
            }
            else
            {
                Console.WriteLine("\nWord found at " + index);
                timer2.Stop();
                Console.WriteLine($"\nSearch took {timer2.Elapsed} .", dictionary.Length, timer2.Elapsed);
                    
            }

        }





        if (selection == "3")
        {
                var timer3 = new Stopwatch();  
                timer3.Start();
                Console.WriteLine("Alice Linear Search");


                int count = 0;
                
                for (int i = 0; i < aliceWords.Length; i++)
                {
                   int index = LinearSearch(dictionary, aliceWords[i]);
                    

                    if (index == -1)
                    {
                        count++;
                        
                    }
                    
                }
                Console.WriteLine($"There are {count} unknown words in the book");
                timer3.Stop();
                Console.WriteLine($"\n( {timer3.Elapsed} )", dictionary.Length, timer3.Elapsed);
                


            }

        if (selection == "4")
        {
                var timer4 = new Stopwatch();
                timer4.Start(); 
                Console.WriteLine("Alice Binary Search");


                int count = 0;

                for (int i = 0; i < aliceWords.Length; i++)
                {
                    int index = BinarySearch(dictionary, aliceWords[i]);


                    if (index == -1)
                    {
                        count++;

                    }
                    
                }
                Console.WriteLine($"There are {count} unknown words in the book");
                timer4.Stop();  
                Console.WriteLine($"\n( {timer4.Elapsed} )", dictionary.Length, timer4.Elapsed);
                

            }


            if (selection == "5")
        {
            Console.WriteLine("Exitting Program.");
            Environment.Exit(0);
        }
     } while (true);
  }

    

    public static int LinearSearch(string[] dictionary, string target)
        {
            for (int i = 0; i < dictionary.Length; i++)
            {
                if (target == dictionary[i])
                    return (i);
            }
            return -1;
        }



        public static int BinarySearch(string[] dictionary, string target)
        {
            int low = 0;



            int high = dictionary.Length - 1;

            while (low <= high)
            {
                int mid = (low + high) / 2;
                string item_mid = dictionary[mid];

                int c = item_mid.CompareTo(target);

                if (c == 0)
                {
                    return mid;
                }
                if (c < 0)
                {
                    low = mid + 1;
                }
                else
                {
                    high = mid;
                }



            }
            return -1;
        }






        public static void printStringArray(String[] array, int start, int stop)
        {
            // Print out array elements at index values from start to stop 
            for (int i = start; i < stop; i++)
            {
                Console.WriteLine(array[i]);
            }
        }







    }
