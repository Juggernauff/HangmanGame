namespace MyGame
{
    class HangmanGame
    {
        private string _secretWord;
        private List<char> _guessedLetters;
        private int _maxAttempts;
        private int _currentAttempts;

        public HangmanGame(string word, int attempts)
        {
            _secretWord = word.ToUpper();
            _maxAttempts = attempts;
            _guessedLetters = new List<char>();
            _currentAttempts = 0;
        }

        public void StartGame()
        {
            Console.WriteLine("Добро пожаловать в игру 'Виселица'!");
            DisplayWord();

            while (!IsGameOver())
            {
                char guess = GetPlayerGuess();
                if (!ProcessGuess(guess))
                {
                    Console.WriteLine("Неверно! Осталось попыток: {0}", _maxAttempts - _currentAttempts);
                }

                DisplayWord();
            }

            if (IsWordGuessed())
            {
                Console.WriteLine("Поздравляю! Вы угадали слово!");
            }
            else
            {
                Console.WriteLine("Игра окончена. Загаданное слово: {0}", _secretWord);
            }
        }

        private void DisplayWord()
        {
            foreach (char letter in _secretWord)
            {
                if (_guessedLetters.Contains(letter))
                {
                    Console.Write(letter + " ");
                }
                else
                {
                    Console.Write("_ ");
                }
            }
            Console.WriteLine();
        }

        private char GetPlayerGuess()
        {
            Console.Write("Введите букву: ");
            char guess = char.ToUpper(Console.ReadKey().KeyChar);
            Console.WriteLine();
            return guess;
        }

        private bool ProcessGuess(char guess)
        {
            if (char.IsLetter(guess))
            {
                _guessedLetters.Add(guess);
                if (!_secretWord.Contains(guess))
                {
                    _currentAttempts++;
                }
                return true;
            }
            else
            {
                Console.WriteLine("Пожалуйста, введите букву.");
                return false;
            }
        }

        private bool IsGameOver()
        {
            return IsWordGuessed() || _currentAttempts >= _maxAttempts;
        }

        private bool IsWordGuessed()
        {
            foreach (char letter in _secretWord)
            {
                if (!_guessedLetters.Contains(letter))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
