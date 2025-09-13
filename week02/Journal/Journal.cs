using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

public class Journal
{
    public List<Entry> _entries = new List<Entry>();

    public void AddEntry(Entry e)
    {
        if (e != null) _entries.Add(e);
    }

    public void Display()
    {
        if (_entries.Count == 0)
        {
            Console.WriteLine("No entries yet.");
            return;
        }

        int i = 1;
        foreach (var e in _entries)
        {
            Console.WriteLine($"--- Entry {i} ---");
            Console.WriteLine(e.ToString());
            Console.WriteLine();
            i++;
        }
    }

    public void SaveToFile(string filePath)
    {
        using var sw = new StreamWriter(filePath);
        foreach (var e in _entries)
        {
            sw.WriteLine(e.Serialize());
        }
    }

    public void LoadFromFile(string filePath)
    {
        if (!File.Exists(filePath))
        {
            Console.WriteLine("File not found.");
            return;
        }

        _entries.Clear();
        foreach (var line in File.ReadLines(filePath))
        {
            if (string.IsNullOrWhiteSpace(line)) continue;
            _entries.Add(Entry.Deserialize(line));
        }
    }

    public void SaveToJson(string filePath)
    {
        var options = new JsonSerializerOptions { WriteIndented = true };
        string json = JsonSerializer.Serialize(_entries, options);
        File.WriteAllText(filePath, json);
    }

    public void LoadFromJson(string filePath)
    {
        if (!File.Exists(filePath))
        {
            Console.WriteLine("File not found.");
            return;
        }

        string json = File.ReadAllText(filePath);
        _entries = JsonSerializer.Deserialize<List<Entry>>(json) ?? new List<Entry>();
    }
}
