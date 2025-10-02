using System.Threading.Tasks;

namespace Dagbok
{
    internal class Program
    {
        static List<DiaryEntry> allEntries = new List<DiaryEntry>();
        static Dictionary<DateTime, DiaryEntry> EntryDictionary = new Dictionary<DateTime, DiaryEntry>();
        static Service service;

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

            service = new Service(EntryDictionary, allEntries);

            while (true)
            {

                Console.WriteLine("1. Lägg till uppgift");
                Console.WriteLine("2. Visa uppgifter och altenativ");
                Console.WriteLine("3. Sök efter uppgift (datum)");
                Console.WriteLine("4. Avsluta");

                MenuChoice.Choices choice = service.GetMenuChoice();

                switch (choice)
                {
                    case MenuChoice.Choices.AddTask:
                        service.AddTask();
                        break;
                    case MenuChoice.Choices.ShowTasks:
                        service.AddMenu(allEntries);
                        break;

                    case MenuChoice.Choices.SearchTasks:
                        service.SearchTask(allEntries[0]);
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

    }
    
}
