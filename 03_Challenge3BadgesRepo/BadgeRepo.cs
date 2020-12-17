using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_Challenge3BadgesRepo
{
    public class BadgeRepo
    {
        public Dictionary<int, Badge> _dictionaryBadges = new Dictionary<int, Badge>();

        //Create
        public void CreateNewBadge(int badgeID, Badge badgeItem)
        {
            _dictionaryBadges.Add(badgeID, badgeItem);
        }

        //Read
        public Dictionary<int, Badge> GetBadges()
        {
            return _dictionaryBadges;
        }

        //Update
        public bool UpdateDoorsOnBadge(int badgeNumber, string doorsString)
        {
            Badge badgeItem = GetBadgeByIDNumberTryGetValue(badgeNumber);
            if (badgeItem == null)
            {
                return false;
            }

            List<string> doorNames = new List<string>();
            string[] doorArray = doorsString.Split(',');

            foreach (string door in doorArray)
            {
                doorNames.Add(door.Trim());
            }

            badgeItem.DoorNamesList = doorNames;
            return true;
        }

        //Update
        public bool AddDoorsToBadge(int badgeNumber, string doorsString)
        {
            Badge badgeItem = GetBadgeByIDNumberTryGetValue(badgeNumber);
            if (badgeItem == null)
            {
                return false;
            }

            List<string> doorNames = new List<string>();
            string[] doorArray = doorsString.Split(',');

            foreach (string door in doorArray)
            {
                badgeItem.DoorNamesList.Add(door.Trim());
            }
            return true;
        }

        //Delete
        public bool RemoveDoorsFromBadge(int badgeNumber)
        {
            Badge badgeItem = GetBadgeByIDNumberTryGetValue(badgeNumber);
            if (badgeItem == null)
            {
                return false;
            }

            badgeItem.DoorNamesList.Clear();
            return true;
        }

        //Delete
        public bool RemoveSelectedDoorsFromBadge(int badgeNumber, string doorNumber) //Done
        {
            Badge badgeItem = GetBadgeByIDNumberTryGetValue(badgeNumber);
            if (badgeItem == null)
            {
                return false;
            }
            List<string> updatedDoors = badgeItem.DoorNamesList;
            string[] doorArray = doorNumber.Trim().Split(',');

            foreach (string doorToDelete in doorArray)
            {
                updatedDoors.Remove(doorToDelete.Trim());
            }
            badgeItem.DoorNamesList = updatedDoors;
            return true;
        }

        //Get By Number
        public Badge GetBadgeByIDNumberTryGetValue(int badgeNumber)
        {
            Badge badge;
            _dictionaryBadges.TryGetValue(badgeNumber, out badge);
            return badge;
        }
    }
}
