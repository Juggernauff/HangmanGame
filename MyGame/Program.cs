namespace MyGame
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите секретное слово: ");
            string secretWord = Console.ReadLine()!.ToLower();

            Console.Write("Введите количество жизней: ");
            int.TryParse(Console.ReadLine(), out int health);

            Console.Clear();

            HangmanGame hangmanGame = new HangmanGame(secretWord, health);
            hangmanGame.StartGame();
        }
    }
}