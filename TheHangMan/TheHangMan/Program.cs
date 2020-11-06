using System;
using System.Collections.Generic;
using System.IO;

namespace HangedMan
{
    class Program
    {


        private static System.Timers.Timer aTimer;

        static void Main(string[] args)
        {
            Random generator = new Random();

            string path = @"countries_and_capitals.txt";
            string path2 = @"scores.txt";

            List<String[]> lista = new List<string[]>();
            List<string> Capitals = new List<string>();
            List<string> Countries = new List<string>();
            List<String[]> Scores = new List<String[]>();


            if (File.Exists(path))
            {

                string[] createText = File.ReadAllLines(path);

                foreach (var item in createText)
                {
                    lista.Add(item.Split(" | "));

                }
                foreach (var item in lista)
                {
                    int counter = 0;
                    foreach (var index in item)
                    {
                        if (counter % 2 == 0) {

                            Countries.Add(index);
                        }
                        else
                        {
                            Capitals.Add(index);

                        }
                        counter++;
                    }
                }
            }

            bool next = true;
            while (next)
            {
                DateTime start;
                List<char> notInWord = new List<char>();
                List<char> InWord = new List<char>();
                char cha;
                int pick = generator.Next(Capitals.Count);
                int chances = 5;
                int picks = 0;
                bool game = true;

                for (int i = 0; i < Capitals[pick].Length; i++)
                    InWord.Add('_');
                do
                {
                    start = DateTime.Now;
                    Console.Clear();
                    Console.WriteLine("Chances left:" + chances);
                    drawHangedMan(chances);

                    Console.WriteLine("Word :");
                    foreach (var item in InWord)
                    {
                        Console.Write(" " + item + " ");
                    }
                    Console.Write("Not-In-Word :");
                    foreach (var item in notInWord)
                    {
                        Console.Write(" " + item + " ");
                    }


                    if (chances == 1)
                    {
                        Console.WriteLine("There's a hint: Capital of " + Countries[pick]);
                    }
                        
                    Console.WriteLine();
                    Console.WriteLine("Do you want to pick a word (type a) or a character (type b)");


                    cha = Console.ReadKey().KeyChar;
                    Console.WriteLine();

                    if (cha == 'a')
                    {
                        Console.WriteLine("Type your answer: ");
                        string answer = Console.ReadLine();

                        if (answer == Capitals[pick])
                        {
                            game = false;
                        }
                        else
                        {
                            chances -= 2;
                        }

                    }
                    else if (cha == 'b')
                    {
                        Console.WriteLine("Type your answer: ");
                        char answer = Console.ReadKey().KeyChar;

                        bool inside = false;
                        for (int i = 0; i < Capitals[pick].Length; i++)
                        {
                            if (char.ToUpper(answer) == char.ToUpper(Capitals[pick][i]))
                            {
                                InWord[i] = char.ToUpper(answer);
                                inside = true;
                                picks++;
                            }
                        }

                        if (!inside)
                        {
                            bool dunno = false;
                            foreach (var item in notInWord)
                            {
                                if (answer == item)
                                    dunno = true;
                            }
                            if (!dunno)
                            {
                                notInWord.Add(answer);
                                chances--;
                            }
                        }

                    }

                    int number = 0;
                    foreach (var item in InWord)
                    {
                        if (item == '_')
                            number++;
                    }
                    if (number == 0)
                        game = false;

                } while (game && chances > 0);

                DateTime stop = DateTime.Now;

                Console.Clear();
                drawHangedMan(chances);

                Console.WriteLine("Word :");
                foreach (var item in InWord)
                {
                    Console.Write(" " + item + " ");
                }
                Console.Write("Not-In-Word :");
                foreach (var item in notInWord)
                {
                    Console.Write(" " + item + " ");
                }

                Console.WriteLine();
                if (game == true)
                {
                    Console.WriteLine("Correct answer was: " + Capitals[pick]);

                }
                else
                {
                    Console.WriteLine("U guessed the capital after: " + picks + " letters. It took you " + (int)(stop - start).TotalSeconds + " seconds");
                    Console.WriteLine("Congratulations! YOU WON!");
                    Console.WriteLine();
                    Console.WriteLine("Do you want to save your score Y\\N?");
                    cha = Console.ReadKey().KeyChar;
                    Console.WriteLine();
                    if (cha == 'y')
                    {
                        string name;
                        Console.WriteLine("Type your name");
                        name = Console.ReadLine();


                        using (StreamWriter sw = File.AppendText(path2))
                        {
                            sw.WriteLine(name + " | " + DateTime.Now + " | " + (int)(stop - start).TotalSeconds + " | " + Countries[pick]);
                            sw.WriteLine();
                        }

                    }
                }
                Console.WriteLine();
                Console.WriteLine("Do you want to try again? Y\\N");

                cha = Console.ReadKey().KeyChar;
                if (cha == 'y')
                {
                    next = true;
                }
                else if (cha == 'n')
                {
                    next = false;
                }

            }
            Console.WriteLine();
            Console.WriteLine("LeaderBoard:");
            if (File.Exists(path2))
            {
                string[] createText2 = File.ReadAllLines(path2);

                foreach (var item in createText2)
                {

                    Scores.Add(item.Split(" | "));

                }
                int counter = 0;
                foreach (var item in Scores)
                {
                    if (counter == 10)
                        break;

                    foreach (var index in item)
                    {
                       
                        Console.Write(index+" ");

                    }
                    Console.WriteLine();
                    counter++;
                }
            }


        }

        static public void drawHangedMan(int a)
        {
            if(a == 0)
            {
                Console.WriteLine("        ________  ");
                Console.WriteLine("        |       \\  ");
                Console.WriteLine("        |        |  ");
                Console.WriteLine("        O        |  ");
                Console.WriteLine("       /|\\       |  ");
                Console.WriteLine("       / \\       |  ");
                Console.WriteLine("_________________|__");
            }
            else if(a == 1)
            {
                Console.WriteLine("        ________  ");
                Console.WriteLine("        |       \\  ");
                Console.WriteLine("        |        |  ");
                Console.WriteLine("        O        |  ");
                Console.WriteLine("       /|\\       |  ");
                Console.WriteLine("                 |  ");
                Console.WriteLine("_________________|__");
            }
            else if (a == 2)
            {
                Console.WriteLine("        ________  ");
                Console.WriteLine("        |       \\  ");
                Console.WriteLine("        |        |  ");
                Console.WriteLine("        O        |  ");
                Console.WriteLine("        |\\       |  ");
                Console.WriteLine("                 |  ");
                Console.WriteLine("_________________|__");
            }
            else if(a == 3)
            {
                Console.WriteLine("        ________  ");
                Console.WriteLine("        |       \\  ");
                Console.WriteLine("        |        |  ");
                Console.WriteLine("        O        |  ");
                Console.WriteLine("        |        |  ");
                Console.WriteLine("                 |  ");
                Console.WriteLine("_________________|__");
            }

            else if (a == 4)
            {
                Console.WriteLine("        ________  ");
                Console.WriteLine("        |       \\  ");
                Console.WriteLine("        |        |  ");
                Console.WriteLine("        O        |  ");
                Console.WriteLine("                 |  ");
                Console.WriteLine("                 |  ");
                Console.WriteLine("_________________|__");
            }
            else
            {
                Console.WriteLine("        ________  ");
                Console.WriteLine("        |       \\  ");
                Console.WriteLine("        |        |  ");
                Console.WriteLine("                 |  ");
                Console.WriteLine("                 |  ");
                Console.WriteLine("                 |  ");
                Console.WriteLine("_________________|__");


            }
        }
    }
}
