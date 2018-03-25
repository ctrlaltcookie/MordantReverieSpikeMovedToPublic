using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Threading;

namespace WPFPrototypeReverie.Libraries
{
    class TextWriter
    {
        private DispatcherTimer _textTimer;
        private List<string> _narrative;
        private TextBlock _screen;
        private int _currentCharacter = 0;
        private int _currentLine = 0;
        private bool _complete = false;
        public bool IsComplete => _complete;
        private List<Label> _labels;

        public TextWriter(List<string> narrative, TextBlock screen, List<Label> labels)
        {
            _screen = screen;
            _labels = labels;
            _textTimer = new DispatcherTimer();
            _textTimer.Interval = new TimeSpan(0, 0, 0, 0, 35);
            _textTimer.Tick += new EventHandler(text_Tick);
            _narrative = narrative;
        }

        public void StartWriting()
        {
            _textTimer.Start();
        }

        private void text_Tick(object sender, EventArgs e)
        {
            if (_currentLine < _narrative.Count)
            {
                if (_currentCharacter < _narrative[_currentLine].Length)
                {
                    _screen.Text += _narrative[_currentLine][_currentCharacter];
                    _currentCharacter++;
                    _textTimer.Start();
                }
                else
                {
                    _currentCharacter = 0;
                    _currentLine++;
                    _textTimer.Stop();
                    Thread.Sleep(500);
                    _textTimer.Start();
                }
            }
            else
            {
                _complete = true;
                _textTimer.Stop();
            }
            UpdateLabels();
        }

        private void UpdateLabels()
        {
            if(_complete)
            {
                foreach(Label lab in _labels)
                {
                    lab.Visibility = System.Windows.Visibility.Visible;
                }
            }
        }
    }
}
