namespace Tic_Tac_Toe.ConsoleApp
{
    public class Program
    {
        static void Main()
        {
            bool isZeroNow = false;
            bool hasWinner = false;
            string[,] map = new string[3, 3]
            {
                { "1", "2", "3" },
                { "4", "5", "6" },
                { "7", "8", "9" }
            };
            for (int i = 0; i < 9; i++)
            {
                Console.WriteLine(isZeroNow ? "Ходят нолики" : "Ходят крестики");
                PrintMap(map);
                Console.WriteLine("Введите цифру вашего хода:");
                string cellNumber = GetPlayerCellNumber(map);
                map = MakeMove(map, cellNumber, isZeroNow);
                hasWinner = HasWinner(map);
                if (hasWinner)
                {
                    break;
                }

                isZeroNow = !isZeroNow;
            }

            PrintMap(map);
            if (hasWinner)
            {
                Console.WriteLine(isZeroNow ? "Нолики победили!" : "Крестики победили!");
            }
            else
            {
                Console.WriteLine("Ничья!");
            }
        }

        static string GetPlayerCellNumber(string[,] map)
        {
            while (true)
            {
                string hui = Console.ReadLine();
                if (hui.Length != 1)
                {
                    Console.WriteLine("Неверный ввод. Пожалуйста, введите цифру от 1 до 9.");
                    continue;
                }

                char pisun = Convert.ToChar(hui);
                if (pisun < 49 || pisun > 57)
                {
                    Console.WriteLine("Неверный ввод. Пожалуйста, введите цифру от 1 до 9.");
                    continue;
                }

                bool isMoveCorrect = IsMoveCorrect(map, hui);
                if (!isMoveCorrect)
                {
                    Console.WriteLine("Неверный ввод. Пожалуйста, введите цифру пустой ячейки.");
                    continue;
                }

                return hui;
            }
        }

        static string[,] MakeMove(string[,] map, string cellNumber, bool isZeroNow) // Заменить в поле цифру на символ
        {
            string a = "";
            if (isZeroNow)
                a = "O";
            else
                a = "X";
            switch (cellNumber)
            {
                case "1": map[0, 0] = a; break;
                case "2": map[0, 1] = a; break;
                case "3": map[0, 2] = a; break;
                case "4": map[1, 0] = a; break;
                case "5": map[1, 1] = a; break;
                case "6": map[1, 2] = a; break;
                case "7": map[2, 0] = a; break;
                case "8": map[2, 1] = a; break;
                case "9": map[2, 2] = a; break;
            }

            return map;
        }

        static bool IsMoveCorrect(string[,] map, string cellNumber)
        {
            string a = "";
            switch (cellNumber)
            {
                case "1": a = map[0, 0]; break;
                case "2": a = map[0, 1]; break;
                case "3": a = map[0, 2]; break;
                case "4": a = map[1, 0]; break;
                case "5": a = map[1, 1]; break;
                case "6": a = map[1, 2]; break;
                case "7": a = map[2, 0]; break;
                case "8": a = map[2, 1]; break;
                case "9": a = map[2, 2]; break;
            }

            if (a != "X" && a != "O")
                return true;
            else
            {
                return false;
            }
        }

        static void PrintMap(string[,] map) // Вывод поля через пробелы
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (map[i, j] == "X")
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write(map[i, j] + " ");
                        Console.ResetColor();
                    }
                    else if (map[i, j] == "O")
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.Write(map[i, j] + " ");
                        Console.ResetColor();
                    }
                    else
                        Console.Write(map[i, j] + " ");
                }

                Console.WriteLine();
            }
        }

        static bool HasWinner(string[,] map) // Проверить поле на наличие выигрыша
        {
            if (map[0, 0] == map[0, 1] && map[0, 0] == map[0, 2])
                return true;
            if (map[1, 0] == map[1, 1] && map[1, 0] == map[1, 2])
                return true;
            if (map[2, 0] == map[2, 1] && map[2, 0] == map[2, 2])
                return true;
            if (map[0, 0] == map[1, 0] && map[0, 0] == map[2, 0])
                return true;
            if (map[0, 1] == map[1, 1] && map[0, 1] == map[2, 1])
                return true;
            if (map[0, 2] == map[1, 2] && map[0, 2] == map[2, 2])
                return true;
            if (map[0, 0] == map[1, 1] && map[0, 0] == map[2, 2])
                return true;
            if (map[0, 2] == map[1, 1] && map[0, 2] == map[2, 0])
                return true;
            return false;
        }
    }
}