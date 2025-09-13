// added the option to load and save from a json file

using System;

class Program
{
    static void Main()
    {
        var journal = new Journal();
        var prompts = new PromptGenerator();

        while (true)
        {
            Console.WriteLine("Journal Menu");
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display the journal");
            Console.WriteLine("3. Save the journal to a file");
            Console.WriteLine("4. Load the journal from a file");
            Console.WriteLine("5. Quit");
            Console.WriteLine("6. Save the journal to a JSON file");
            Console.WriteLine("7. Load the journal from a JSON file");
            Console.Write("Choose an option (1-7): ");

            string input = Console.ReadLine()?.Trim() ?? "";
            Console.WriteLine();

            switch (input)
            {
                case "1":
                    WriteEntry(journal, prompts);
                    break;

                case "2":
                    journal.Display();
                    break;

                case "3":
                    Console.Write("Enter filename to save (e.g., journal.txt): ");
                    var saveName = Console.ReadLine()?.Trim();
                    if (!string.IsNullOrWhiteSpace(saveName))
                    {
                        journal.SaveToFile(saveName);
                        Console.WriteLine($"Saved to {saveName}");
                    }
                    break;

                case "4":
                    Console.Write("Enter filename to load (e.g., journal.txt): ");
                    var loadName = Console.ReadLine()?.Trim();
                    if (!string.IsNullOrWhiteSpace(loadName))
                    {
                        journal.LoadFromFile(loadName);
                        Console.WriteLine("Journal loaded.");
                    }
                    break;

                case "5":
                    return;

                case "6":
                    Console.Write("Enter filename to save (e.g., journal.json): ");
                    var jsonSave = Console.ReadLine()?.Trim();
                    if (!string.IsNullOrWhiteSpace(jsonSave))
                    {
                        journal.SaveToJson(jsonSave);
                        Console.WriteLine($"Journal saved to {jsonSave}");
                    }
                    break;

                case "7":
                    Console.Write("Enter filename to load (e.g., journal.json): ");
                    var jsonLoad = Console.ReadLine()?.Trim();
                    if (!string.IsNullOrWhiteSpace(jsonLoad))
                    {
                        journal.LoadFromJson(jsonLoad);
                        Console.WriteLine("Journal loaded from JSON.");
                    }
                    break;

                default:
                    Console.WriteLine("Please choose 1–7.");
                    break;
            }

            Console.WriteLine();
        }
    }

    static void WriteEntry(Journal journal, PromptGenerator prompts)
    {
        string prompt = prompts.GetRandomPrompt();
        Console.WriteLine($"Prompt: {prompt}");
        Console.WriteLine("Write your response below. Finish with Enter:");
        string text = Console.ReadLine() ?? "";

        string date = DateTime.Now.ToString("yyyy-MM-dd");
        var entry = new Entry(date, prompt, text);
        journal.AddEntry(entry);
        Console.WriteLine("Entry added.");
    }
}
