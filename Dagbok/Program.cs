namespace Dagbok
{
    internal class Program
    {

        static void Main(string[] args)
        {

            while (true)
            {

                Console.WriteLine("1. Lägg till uppgift");
                Console.WriteLine("2. Visa uppgifter");
                Console.WriteLine("3. Avsluta");

                MenuChoice.Choices choice = GetMenuChoice();

                switch (choice)
                {
                    case MenuChoice.Choices.AddTask:
                        AddTask();
                        break;
                    case MenuChoice.Choices.ShowTasks:
                        ShowTasks();
                        break;
                    case MenuChoice.Choices.Exit:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Ogiltigt val, försök igen.");
                        break;

                }

            }
        }

        private static void ShowTasks()
        {
            try
            {
                if (!File.Exists("Todo.txt"))
                {
                    Console.WriteLine("Inga uppgifter hittades.");
                    return;
                }
                string[] tasks = File.ReadAllLines("Todo.txt");

                if (tasks.Length == 0)
                {
                    Console.WriteLine("Inga Uppgifter i listan");
                    return;
                }

                Console.WriteLine("Uppgifter:");
                for (int i = 0; i < tasks.Length; i++)
                {
                    Console.WriteLine($"{i + 1}. {tasks[i]}");
                }
                Console.WriteLine($"\n Totalt: {tasks.Length} uppgifter");

            }
            catch
            {
                Console.WriteLine("Kunde inte läsa uppgifterna.");
            }
        }

        private static void AddTask()
        {
            Console.WriteLine("Ange uppgift:");
            string? task = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(task))
            {
                Console.WriteLine("Uppgiften kan inte vara tom.");
                return;
            }
            try
            {
                string taskWithTimestamp = $"{DateTime.Now}: {task}{Environment.NewLine}";
                File.AppendAllText("Todo.txt", taskWithTimestamp + Environment.NewLine);
                Console.WriteLine("Uppgift tillagd.");
            }
            catch
            {
                Console.WriteLine("Kunde inte lägga till uppgiften.");
            }
        }

        static MenuChoice.Choices GetMenuChoice()
        {
            string? input = Console.ReadLine();
            if (input != null && int.TryParse(input, out int choice) && Enum.IsDefined(typeof(MenuChoice.Choices), choice))
            {
                return (MenuChoice.Choices)choice;
            }
            return MenuChoice.Choices.invalid;
        }

    }
    
}
