using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_Komodo_Insurance_Repository
{
    public class Badge_Repository
    {
        private Dictionary<int, Badge> _badgeList = new Dictionary<int, Badge>();

        // Create
        public void AddBadge(int badgeID, Badge badge)
        {
            _badgeList.Add(badgeID, badge);
        }

        // Read
        public Dictionary<int, Badge> GetBadges()
        {
            return _badgeList;
        }

        // Update
        public bool UpdateExistingBadge(int badgeID, Badge newBadge)
        {
            Badge oldBadge = GetBadgeByID(badgeID);

            if(oldBadge != null)
            {
                oldBadge.DoorNames = newBadge.DoorNames;
                return true;
            }
            else
            {
                return false;
            }
        }


        // Helper Method
        public Badge GetBadgeByID(int ID)
        {
            foreach(KeyValuePair<int, Badge> entry in _badgeList)
            {
                if(entry.Key == ID)
                {
                    return entry.Value;
                }
            }

            return null;
        }
    }


}
