using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dagbok
{
    internal class MenuChoice
    {
        public enum Choices
        {
            invalid = 0,
            AddTask = 1,
            ShowTasks = 2,
            SearchTasks = 3,
            Exit = 4
        }

    }
}
