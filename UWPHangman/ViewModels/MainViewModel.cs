using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;

namespace UWPHangman.ViewModels
{
    class MainViewModel : INotifyPropertyChanged
    {
        private readonly List<string> _wordList;
        private readonly Random rand;
        private int _index = 1; //lifes of the player 1 == 7 lifes | 8 == 0 lifes | 0 == guess was right
        private string chars = "";
        private string _word, _hiddenWord, _guessWord;
        public int Index { get { return _index; } set { _index = value; NotifyPropertyChanged(); Guess.RaiseCanExecuteChanged(); } }
        public string GuessWord { get { return _guessWord; } set { _guessWord = value.ToLower(); NotifyPropertyChanged(); } }
        public string WrongLetters { get { return chars; } set { chars = value; NotifyPropertyChanged(); } }
        public string Word { get { return _word; } set { _word = value; NotifyPropertyChanged(); } }

        public RelayCommand Guess { get; set; }
        public RelayCommand Reset { get; set; }
        public MainViewModel()
        {
            rand = new Random();
            _wordList = new List<string>() { "auto", "astronaut", "hudba", "svět", "měsíc", "planeta", "budova", "mrkev", "papír", "propiska" };
            _hiddenWord = _wordList[rand.Next(_wordList.Count - 1)];
            Word = new string('_', _hiddenWord.Length);
            Guess = new RelayCommand(
                () =>
                {
                    if (GuessWord.Length > 0)
                    {
                        if (GuessWord.Length == 1)
                        {
                            if (_hiddenWord.Contains(GuessWord))
                            {
                                for (int i = 0; i < _hiddenWord.Length; i++)
                                {
                                    if (_hiddenWord[i] == GuessWord[0])
                                    {
                                        char[] s = Word.ToCharArray();
                                        s[i] = GuessWord[0];
                                        Word = new string(s);
                                    }
                                }
                            }
                            else
                            {
                                bool match = false;
                                if (_hiddenWord.IndexOfAny("ěéóščřžýáíďťňůú".ToCharArray()) != -1 && GuessWord.IndexOfAny("eoscrzyaidtnu".ToCharArray()) != -1)
                                {
                                    for (int i = 0; i < _hiddenWord.Length; i++)
                                    {
                                        switch (GuessWord[0])
                                        {
                                            case 'e':
                                                if (_hiddenWord[i] == 'ě') GuessWord = "ě";
                                                if (_hiddenWord[i] == 'é') GuessWord = "é";
                                                break;
                                            case 'o':
                                                if (_hiddenWord[i] == 'ó') GuessWord = "ó";
                                                break;
                                            case 's':
                                                if (_hiddenWord[i] == 'š') GuessWord = "š";
                                                break;
                                            case 'c':
                                                if (_hiddenWord[i] == 'č') GuessWord = "č";
                                                break;
                                            case 'r':
                                                if (_hiddenWord[i] == 'ř') GuessWord = "ř";
                                                break;
                                            case 'z':
                                                if (_hiddenWord[i] == 'ž') GuessWord = "ž";
                                                break;
                                            case 'y':
                                                if (_hiddenWord[i] == 'ý') GuessWord = "ý";
                                                break;
                                            case 'a':
                                                if (_hiddenWord[i] == 'á') GuessWord = "á";
                                                break;
                                            case 'i':
                                                if (_hiddenWord[i] == 'í') GuessWord = "í";
                                                break;
                                            case 'd':
                                                if (_hiddenWord[i] == 'ď') GuessWord = "ď";
                                                break;
                                            case 't':
                                                if (_hiddenWord[i] == 'ť') GuessWord = "ť";
                                                break;
                                            case 'n':
                                                if (_hiddenWord[i] == 'ň') GuessWord = "ň";
                                                break;
                                            case 'u':
                                                if (_hiddenWord[i] == 'ů') GuessWord = "ů";
                                                if (_hiddenWord[i] == 'ú') GuessWord = "ú";
                                                break;
                                            default:
                                                break;
                                        }
                                        if (_hiddenWord[i] == GuessWord[0])
                                        {
                                            char[] s = Word.ToCharArray();
                                            s[i] = GuessWord[0];
                                            Word = new string(s);
                                            match = true;
                                        }
                                    }
                                }
                                if (!match)
                                {
                                    if (WrongLetters.Length == 0) { WrongLetters += GuessWord + ","; Index++; }
                                    if (!WrongLetters.Split(',').Any(x => x == GuessWord)) { WrongLetters += GuessWord + ","; Index++; }
                                }
                            }
                        }
                        if (GuessWord.Length == _hiddenWord.Length && GuessWord != _hiddenWord) { Index++; WrongLetters += GuessWord + ","; }
                        if (GuessWord == _hiddenWord || Word == _hiddenWord) { Index = 0; Word = _hiddenWord; }
                    }
                },
                () =>
                {
                    if (Index == 8 || Index == 0) return false;
                    return true; 
                }
                );
            Reset = new RelayCommand(
                () => { _hiddenWord = _wordList[rand.Next(_wordList.Count - 1)]; 
                    Index = 1; 
                    WrongLetters = ""; 
                    Word = new string('_', _hiddenWord.Length); },
                () => { return true; }
                );
        }



        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
