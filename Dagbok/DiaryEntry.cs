using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dagbok
{
    internal class DiaryEntry
    {
        public FileStream diaryEntry;
        public string title;
        public string[] mainText;
        public DateTime time;

        public DiaryEntry(string[] mainText, string title)
        {
            this.mainText = mainText;
            this.title = title;
            DateTime.TryParse(mainText[0], out time);
        }

        public void Delete()
        {
            File.Delete(title);
        }

    }
}
