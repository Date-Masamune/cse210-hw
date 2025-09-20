using System.Linq;

namespace ScriptureMemorizer
{
    public sealed class Word
    {
        private readonly string _text;
        private bool _hidden;

        public Word(string text)
        {
            _text = text;
            _hidden = false;
        }

        public bool IsHidden => _hidden;
        public bool HasHideableChars => _text.Any(char.IsLetter);

        public void Hide() => _hidden = true;
        public void Reveal() => _hidden = false;

        public string GetDisplayText()
        {
            if (!_hidden) return _text;
            var masked = _text.Select(c => char.IsLetter(c) ? '_' : c).ToArray();
            return new string(masked);
        }
    }
}
