using System.Threading.Tasks;

namespace Dagbok
{
    internal class Program
    {
        static List<DiaryEntry> allEntries = new List<DiaryEntry>();
        static Dictionary<DateTime, DiaryEntry> EntryDictionary = new Dictionary<DateTime, DiaryEntry>();
        static bool delete, change, view;

        static void Main(string[] args)
        {

            string directoryPath = AppDomain.CurrentDomain.BaseDirectory;
            string searchPattern = "*.txt";


            foreach (string path in Directory.GetFiles(directoryPath, "*.txt", SearchOption.AllDirectories))
            {
                DiaryEntry entry = new DiaryEntry(File.ReadAllLines(path), Path.GetFileName(path));
                allEntries.Add(entry);
                EntryDictionary.Add(entry.time, entry);
            }


            while (true)
            {

                Console.WriteLine("1. Lägg till uppgift");
                Console.WriteLine("2. Visa uppgifter och altenativ");
                Console.WriteLine("3. Sök efter uppgift (datum)");
                Console.WriteLine("4. Avsluta");

                MenuChoice.Choices choice = GetMenuChoice();

                switch (choice)
                {
                    case MenuChoice.Choices.AddTask:
                        AddTask();
                        break;
                    case MenuChoice.Choices.ShowTasks:
                        while (true) 
                        {
                            int choosenOption;
                            Console.WriteLine("1. Radera En uppgift");
                            Console.WriteLine("2. Ändra en uppgift");
                            Console.WriteLine("3. Visa en uppgift");
                            Console.WriteLine("4. Avsluta");
                            delete = false;
                            change = false;
                            view = false;
                            bool exit = false;
                            if(int.TryParse(Console.ReadLine(), out choosenOption) && choosenOption > 0)
                            {
                                switch (choosenOption)
                                {
                                    case 1:
                                        delete = true;
                                        break;
                                    case 2:
                                        change = true;
                                        break;
                                    case 3:
                                        view = true;
                                        break;
                                    case 4:
                                        exit = true;
                                        break;
                                }
                                ShowTasks();
                            }
                            else
                            {
                                Console.WriteLine("Invalid choice:");
                                break;
                            }

                            if (exit)
                            {
                                break;
                            }

                            int choosenEntry;
                            try
                            {
                                choosenEntry = int.Parse(Console.ReadLine());
                            }
                            catch
                            {
                                continue;
                            }

                            if (view)
                            {
                                DisplayFullEntry(allEntries[choosenEntry]);
                            }

                            if (delete)
                            {
                                DeleteEntry(allEntries[choosenEntry]);
                            }

                            if (change)
                            {
                                WriteOver(allEntries[choosenEntry]);
                            }

                        }

                        break;

                    case MenuChoice.Choices.SearchTasks:
                        SearchTask();
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
                Console.WriteLine("Uppgifter:");
                int option = 0;
                foreach (DiaryEntry entry in allEntries)
                {
                    option++;
                    if (!File.Exists(entry.title))
                    {
                        Console.WriteLine("Inga uppgifter hittades.");
                        return;
                    }

                    Console.WriteLine(option + ": " + entry.time + "\t" + entry.title);
                }
                Console.WriteLine($"\nTotalt: {allEntries.Count} uppgifter");


            }
            catch
            {
                Console.WriteLine("Kunde inte läsa uppgifterna.");
            }
        }

        static void DisplayFullEntry(DiaryEntry entry)
        {
            Console.WriteLine($"{entry.time}\t{entry.title}");
            foreach(string line in entry.mainText)
            {
                Console.WriteLine(line);
            }
        }

        static void DeleteEntry(DiaryEntry entry)
        {
            allEntries.Remove(entry);
            EntryDictionary.Remove(entry.time ,out entry);
            entry.Delete();
        }

        static void WriteOver(DiaryEntry entry)
        {

            try
            {
                string newText = Console.ReadLine();

                File.WriteAllText(entry.title, newText);

                entry.mainText = File.ReadAllLines(newText);
            }
            catch
            {
                Console.WriteLine("Uppgiften var felaktig");
            }
        }

        static void AddTask()
        {
            Console.WriteLine("Ange Titel");
            string? title = Console.ReadLine() + ".txt";
            Console.WriteLine("Ange uppgift:");
            string? task = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(task) || string.IsNullOrWhiteSpace(title))
            {
                Console.WriteLine("Uppgiften kan inte vara tom.");
                return;
            }
            try
            {
                File.AppendAllText(title, task + Environment.NewLine);
                Console.WriteLine("Uppgift tillagd.");
            }
            catch
            {
                Console.WriteLine("Kunde inte lägga till uppgiften.");
            }
        }

        static void SearchTask()
        {

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
