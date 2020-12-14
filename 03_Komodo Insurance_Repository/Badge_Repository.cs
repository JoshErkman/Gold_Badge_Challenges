using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_Komodo_Insurance_Repository
{
    public class Badge_Repository
    {
        private Dictionary<int, Badge> BadgeList = new Dictionary<int, Badge>();

        // Create
        public void AddBadge(int badgeID, Badge badge)
        {
            BadgeList.Add(badgeID, badge);
        }

        // Read
        public Dictionary<int, Badge> GetBadges()
        {
            return BadgeList;
        }
    }
}
