using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreadsAndEvents
{
    class Class
    {
        private ObservableCollection<string> List { get; set; }

        public Class()
        {
            List = new ObservableCollection<string>() { "asd", "asd1", "asd2", "asd3", "asd4", "asd5" };
        }

        public void Remove(string str)
        {
            List.Remove(str);
        }
    }
}
