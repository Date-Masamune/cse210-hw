using System;
using System.Collections.Generic;

namespace ScriptureMemorizer
{
    public sealed class ScriptureLibrary
    {
        private readonly List<Scripture> _items = new List<Scripture>();
        private readonly Random _rng = new Random();

        private ScriptureLibrary() { }

        public static ScriptureLibrary CreateDefault()
        {
            var lib = new ScriptureLibrary();

            lib._items.Add(new Scripture(
                new Reference("Proverbs", 3, 5, 6),
                "Trust in the Lord with all thine heart; and lean not unto thine own understanding. " +
                "In all thy ways acknowledge him, and he shall direct thy paths."));

            lib._items.Add(new Scripture(
                new Reference("John", 3, 16),
                "For God so loved the world, that he gave his only begotten Son, that whosoever believeth in him " +
                "should not perish, but have everlasting life."));

            lib._items.Add(new Scripture(
                new Reference("Psalm", 23, 1),
                "The Lord is my shepherd; I shall not want."));

            return lib;
        }

        public Scripture RandomPick() => _items[_rng.Next(_items.Count)];
    }
}
