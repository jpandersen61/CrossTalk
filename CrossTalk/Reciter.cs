using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace CrossTalk
{
    public class Reciter
    {
        private static Random _rng = new Random();

        /// <summary>
        /// Recites a set of lists of words.
        /// </summary>
        public static async void ReciteAllTheWords()
        {
            List<string> danish = new List<string> {"En", "To", "Tre", "Fire", "Fem", "Seks", "Syv", "Otte" };
            List<string> english = new List<string> { "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight" };
            List<string> german = new List<string> { "Eins", "Zwei", "Drei", "Vier", "Funf", "Sechs", "Sieben", "Acht" };

            Task danishTask = ReciteAsync(danish);
            Task englishTask = ReciteAsync(english);
            Task germanTask =  ReciteAsync(german);

            //Do something mean  while
            for(int i = 0; i < 5; i++)
            {
                Console.WriteLine($"Doing something mean while:{i} ");
                Thread.Sleep(_rng.Next(1000) + 50);
            }

            await danishTask;
            await englishTask;
            await germanTask;
            Task.WaitAll(danishTask,englishTask,germanTask);

            Console.WriteLine("Finished");



            //Recite(danish);
            //Recite(english);
            //Recite(german);
        }

        /// <summary>
        /// Recites (i.e. prints on screen with a bit of delay
        /// between each line) the provided list of strings.
        /// </summary>
        public static void Recite(List<string> words)
        {
            foreach (string s in words)
            {
                Console.WriteLine(s);
                Thread.Sleep(_rng.Next(1000) + 50);
            }
        }

        public static Task ReciteAsync (List<string> words)
        {
            Task t = Task.Run(() => Recite(words));
            return t;
        }
    }
}