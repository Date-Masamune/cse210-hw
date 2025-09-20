using System;
using System.Collections.Generic;
using System.Linq;

namespace ScriptureMemorizer
{
    public sealed class Scripture
    {
        private readonly Reference _reference;
        private readonly List<Word> _words;
        private readonly Random _rng = new Random();

        public Scripture(Reference reference, string text)
        {
            _reference = reference;
            _words = text
                .Split(new[] { ' ', '\t', '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(token => new Word(token))
                .ToList();
        }

        public bool AllHidden => _words.All(w => !w.HasHideableChars || w.IsHidden);

        public string GetDisplayText()
        {
            var body = string.Join(" ", _words.Select(w => w.GetDisplayText()));
            return $"{_reference.GetDisplayText()}\n\n{body}";
        }

        // Stretch: only hide words that aren't already hidden
        public void HideRandomWords(int count)
        {
            var pool = _words.Where(w => !w.IsHidden && w.HasHideableChars).ToList();
            if (pool.Count == 0) return;

            count = Math.Min(count, pool.Count);
            for (int i = 0; i < count; i++)
            {
                int pick = _rng.Next(pool.Count);
                pool[pick].Hide();
                pool.RemoveAt(pick);
            }
        }

        // For the "hint" feature
        public bool RevealOneHidden()
        {
            var hidden = _words.Where(w => w.IsHidden && w.HasHideableChars).ToList();
            if (hidden.Count == 0) return false;
            hidden[_rng.Next(hidden.Count)].Reveal();
            return true;
        }
    }
}
