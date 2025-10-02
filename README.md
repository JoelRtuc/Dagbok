📖 Dagbok (C# Console Diary Application)

A simple diary / task manager built with C#.
You can add, view, search, edit, and delete diary entries.
All entries are saved as .txt files on disk for persistence.

✨ Features

➕ Add tasks with a title and description.

📂 Store entries automatically as text files.

🔍 Search entries by year, month, and/or day (wildcard with x).

👀 View full entries with timestamp and content.

📝 Edit entries by overwriting their text.

❌ Delete entries permanently from both memory and disk.

🗂 Uses both a List<DiaryEntry> and Dictionary<DateTime, DiaryEntry> internally for fast lookups.

🖥 Example Usage
1. Lägg till uppgift
2. Visa uppgifter och altenativ
3. Sök efter uppgift (datum)
4. Avsluta


When searching:

Write a time year (if you dont want to write x): 2025
Write a month (if you dont want to write x): x
Write a day (if you dont want to write x): 1


This will find all entries created on the 1st of any month in 2025.

📂 Project Structure

Program.cs – Main loop, loads entries, handles menu navigation.

DiaryEntry.cs – Represents a diary entry (title, text, timestamp).

Service.cs – Core logic for adding, searching, editing, and deleting tasks.

MenuChoice.cs – Enum representing menu options.

⚙️ How It Works

Entries are stored as .txt files in the program’s bin/Debug/netX.0/ folder.

Each file contains:

The timestamp (first line).

The diary/task content (subsequent lines).

Files are loaded into memory each time the program runs.

🚀 Getting Started

Clone the repo:

git clone https://github.com/YOUR_USERNAME/Dagbok.git
cd Dagbok


Open in Visual Studio or run with:

dotnet run


Start adding and managing diary tasks from the console menu.

📌 Planned Improvements

 Store files in a dedicated subfolder (Entries/).

 Support multi-line task input.

 Allow searching by keyword in text.

 Add export/import feature.

👉 Do you want me to also include a sample .txt diary entry file in the repo so people immediately understand the format?

You said:
in README text and format so I can just copy
ChatGPT said:

Got it 👍 Here’s the README.md content you can copy directly into your repo:

# 📖 Dagbok (C# Console Diary Application)

A simple diary / task manager built with **C#**.  
You can add, view, search, edit, and delete diary entries.  
All entries are saved as `.txt` files on disk for persistence.

---

## ✨ Features
- ➕ **Add tasks** with a title and description  
- 📂 **Store entries** automatically as text files  
- 🔍 **Search entries** by year, month, and/or day (wildcard with `x`)  
- 👀 **View full entries** with timestamp and content  
- 📝 **Edit entries** by overwriting their text  
- ❌ **Delete entries** permanently from both memory and disk  
- 🗂 Uses both a `List<DiaryEntry>` and `Dictionary<DateTime, DiaryEntry>` internally for fast lookups  

---

## 🖥 Example Usage


Lägg till uppgift

Visa uppgifter och altenativ

Sök efter uppgift (datum)

Avsluta


When searching:


Write a time year (if you dont want to write x): 2025
Write a month (if you dont want to write x): x
Write a day (if you dont want to write x): 1

This will find all entries created on the 1st of any month in 2025.

---

## 📂 Project Structure
- **Program.cs** – Main loop, loads entries, handles menu navigation  
- **DiaryEntry.cs** – Represents a diary entry (title, text, timestamp)  
- **Service.cs** – Core logic for adding, searching, editing, and deleting tasks  
- **MenuChoice.cs** – Enum representing menu options  

---

## ⚙️ How It Works
- Entries are stored as `.txt` files in the program’s `bin/Debug/netX.0/` folder  
- Each file contains:  
  1. The timestamp (first line)  
  2. The diary/task content (subsequent lines)  
- Files are loaded into memory each time the program runs  

---

## 🚀 Getting Started
1. Clone the repo:
   ```bash
   git clone https://github.com/JoelRtuc/Dagbok
   cd Dagbok


Open in Visual Studio or run with:

dotnet run


Start adding and managing diary tasks from the console menu
