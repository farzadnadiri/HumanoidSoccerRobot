using System.Collections.Generic;
using System.Speech.Recognition;

namespace Robot.Utils
{
    public class SpeechRecognizer
    {
        public class SpeechPattern
        {
            public delegate void RecognitionFunction(string e);

            public event RecognitionFunction Recognized;
            private void OnRecognized()
            {
                if (Recognized != null) Recognized(_phrase);
            }

            public bool Recognize(string input)
            {
                if (Phrase == input)
                {
                    OnRecognized();
                    return true;
                }
                return false;
            }

            private readonly string _phrase;
            public string Phrase { get { return _phrase; } }

            public SpeechPattern(string phrase, RecognitionFunction eventhandler)
            {
                _grammar = new Grammar(new GrammarBuilder(phrase));
                Recognized += eventhandler;
                _phrase = phrase;
            }

            private readonly Grammar _grammar;
            public Grammar Grammar
            {
                get { return _grammar; }
            }
        }

        private readonly List<SpeechPattern> _patterns;
        private readonly SpeechRecognitionEngine _recognizer;
        public SpeechRecognitionEngine Recognizer
        {
            get { return _recognizer; }
        }

        public SpeechRecognizer()
        {
            _patterns = new List<SpeechPattern>();
            _recognizer = new SpeechRecognitionEngine();
            _recognizer.SpeechRecognized += SpeechRecognized;
            _recognizer.SetInputToDefaultAudioDevice();
        }

        public void Start()
        {
            _recognizer.RecognizeAsync(RecognizeMode.Multiple);
        }
        public void Stop()
        {
            _recognizer.RecognizeAsyncStop();
        }
        private void SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            foreach (SpeechPattern pattern in _patterns)
            {
                pattern.Recognize(e.Result.Text);
            }
        }

        public void AddPattern(SpeechPattern pattern)
        {
            _patterns.Add(pattern);
            Recognizer.RequestRecognizerUpdate();
            Recognizer.LoadGrammar(pattern.Grammar);
        }

        public void RemovePattern(SpeechPattern pattern)
        {
            for (int i = 0; i < _patterns.Count; i++)
            {
                if (pattern.Phrase == _patterns[i].Phrase)
                {
                    _patterns.RemoveAt(i);
                    Recognizer.RequestRecognizerUpdate();
                    Recognizer.UnloadGrammar(_patterns[i].Grammar);
                }
            }
        }

    }
}
