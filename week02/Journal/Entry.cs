using System;

public class Entry
{
    public string _date { get; set; }
    public string _promptText { get; set; }
    public string _entryText { get; set; }

    public Entry() { }

    public Entry(string date, string prompt, string text)
    {
        _date = date;
        _promptText = prompt;
        _entryText = text;
    }

    public override string ToString()
    {
        return $"{_date}\nPrompt: {_promptText}\nEntry:  {_entryText}";
    }

    private const string Sep = "~|~";
    public string Serialize()
    {
        return string.Join(Sep, _date ?? "", _promptText ?? "", _entryText ?? "");
    }

    public static Entry Deserialize(string line)
    {
        const string Sep = "~|~";
        var parts = line.Split(Sep, StringSplitOptions.None);
        string date = parts.Length > 0 ? parts[0] : "";
        string prompt = parts.Length > 1 ? parts[1] : "";
        string text = parts.Length > 2 ? parts[2] : "";
        return new Entry(date, prompt, text);
    }
}
