/*
Added 2 features
1) Scripture Library: selects a random scripture from a small built-in library each time.
2) Hint: user can type "hint" to reveal one random hidden word to aid memorization. */



using System;

namespace ScriptureMemorizer
{
    internal static class Program
    {
        private static void Main()
        {
            var library = ScriptureLibrary.CreateDefault();
            var scripture = library.RandomPick();

            while (true)
            {
                Console.Clear();
                Console.WriteLine(scripture.GetDisplayText());
                Console.WriteLine();
                if (scripture.AllHidden)
                {
                    Console.WriteLine("All words hidden. Great job!");
                    break;
                }

                Console.Write("Press Enter to hide words, type 'hint' to reveal one, or 'quit' to end: ");
                var input = Console.ReadLine();

                if (!string.IsNullOrWhiteSpace(input))
                {
                    var cmd = input.Trim().ToLowerInvariant();
                    if (cmd == "quit") break;
                    if (cmd == "hint")
                    {
                        scripture.RevealOneHidden();
                        continue;
                    }
                }

                scripture.HideRandomWords(3); // hide a few each round
            }
        }
    }
}
