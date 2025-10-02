using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dagbok
{

    internal class Service
    {
        static bool delete, change, view;
        static List<DiaryEntry> allEntries = new List<DiaryEntry>();
        static Dictionary<DateTime, DiaryEntry> EntryDictionary = new Dictionary<DateTime, DiaryEntry>();

        public Service(Dictionary<DateTime, DiaryEntry> dic, List<DiaryEntry> newAllEntries)
        {
            EntryDictionary = dic;
            newAllEntries = allEntries; 
        }

        public void ShowTasks(List<DiaryEntry> entries)
        {
            try
            {
                Console.WriteLine("Uppgifter:");
                int option = 0;
                foreach (DiaryEntry entry in entries)
                {
                    option++;
                    if (!File.Exists(entry.title))
                    {
                        Console.WriteLine("Inga uppgifter hittades.");
                        return;
                    }

                    Console.WriteLine(option + ": " + entry.time + "\t" + entry.title);
                }
                Console.WriteLine($"\nTotalt: {entries.Count} uppgifter");


            }
            catch
            {
                Console.WriteLine("Kunde inte läsa uppgifterna.");
            }
        }

        public void DisplayFullEntry(DiaryEntry entry)
        {
            Console.WriteLine($"{entry.time}\t{entry.title}");
            for (int i = 1; i < entry.mainText.Length; i++)
            {
                Console.WriteLine(entry.mainText[i]);
            }
        }

        public void DeleteEntry(DiaryEntry entry)
        {
            allEntries.Remove(entry);
            EntryDictionary.Remove(entry.time, out entry);
            entry.Delete();
        }

        public void WriteOver(DiaryEntry entry)
        {
            Console.WriteLine("Vad vill du skriva istället?: ");
            try
            {
                string newText = entry.time.ToString() + "\n" + Console.ReadLine();

                File.WriteAllText(entry.title, newText);

                entry.mainText = File.ReadAllLines(entry.title);
            }
            catch
            {
                Console.WriteLine("Uppgiften var felaktig");
            }
        }

        public void AddTask()
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

            File.AppendAllText(title, DateTime.Now.ToString() + Environment.NewLine + task + Environment.NewLine);
            Console.WriteLine("Uppgift tillagd.");

        }

        public void SearchTask()
        {

            string day, month, year;
            Console.WriteLine("Write a time year (if you dont want to write x):");
            year = Console.ReadLine();
            Console.WriteLine("Write a month (if you dont want to write x):");
            month = Console.ReadLine();
            Console.WriteLine("Write a day (if you dont want to write x):");
            day = Console.ReadLine();

            List<DiaryEntry> entries = new List<DiaryEntry>();
            int i = 0;
            foreach (DiaryEntry entry1 in EntryDictionary.Values)
            {
                i++;
                bool match = true;

                if (year != "x" && entry1.time.Year != int.Parse(year))
                    match = false;

                if (month != "x" && entry1.time.Month != int.Parse(month))
                    match = false;

                if (day != "x" && entry1.time.Day != int.Parse(day))
                    match = false;

                if (match)
                {
                    Console.WriteLine($"{i} +: Entry {entry1} matches filter!");
                    entries.Add(entry1);
                }
            }

            if (entries.Count > 0)
            {
                AddMenu(entries);
            }
            else
            {
                Console.WriteLine("No match.");
            }

        }

        public MenuChoice.Choices GetMenuChoice()
        {
            string? input = Console.ReadLine();
            if (input != null && int.TryParse(input, out int choice) && Enum.IsDefined(typeof(MenuChoice.Choices), choice))
            {
                return (MenuChoice.Choices)choice;
            }
            return MenuChoice.Choices.invalid;
        }

        public void AddMenu(List<DiaryEntry> entries)
        {
            while (true)
            {
                int choosenOption;
                Console.WriteLine("1. Radera En uppgift");
                Console.WriteLine("2. Ändra en uppgift");
                Console.WriteLine("3. Visa en uppgift");
                Console.WriteLine("4. Gå tillbaka");
                delete = false;
                change = false;
                view = false;
                bool exit = false;
                if (int.TryParse(Console.ReadLine(), out choosenOption) && choosenOption > 0)
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
                    ShowTasks(entries);
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
                    choosenEntry = int.Parse(Console.ReadLine()) - 1;
                }
                catch
                {
                    continue;
                }

                if (view)
                {
                    DisplayFullEntry(entries[choosenEntry]);
                }

                if (delete)
                {
                    DeleteEntry(entries[choosenEntry]);
                }

                if (change)
                {
                    WriteOver(entries[choosenEntry]);
                }

            }
        }

    }
}
