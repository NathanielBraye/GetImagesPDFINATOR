using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetImagesPDFINATOR
{
    public class MainFolderPath
    {

        public int id { get; set; }

        public string name { get; set; }

        public DateTime date { get; set; }

        public bool alive;
        public MainFolderPath()
        {
        }

        public MainFolderPath(int id, string name, DateTime date)
        {
            this.id = id;
            this.name = name;
            this.date = date;
        }

        public override string ToString()
        {
            return id + "," + name + "," + date + "," + "\n";
        }


    }
}
