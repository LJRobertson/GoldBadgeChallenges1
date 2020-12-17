 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_Challenge3BadgesRepo
{
    public class Badge
    {
        public int BadgeID { get; set; }
        public List<string> DoorNamesList { get; set; } = new List<string>();

        public Badge() { }

        public Badge(int badgeID) 
        {
            BadgeID = badgeID;
        }
    }
}
