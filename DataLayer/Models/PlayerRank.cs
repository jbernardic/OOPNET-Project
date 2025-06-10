using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models
{
    public class PlayerRank : IComparable<PlayerRank>
    {
        public string? PlayerName;
        public int AppearanceCount;
        public int GoalCount;
        public int YellowCardCount;

        public override int GetHashCode()
        {
            return PlayerName?.GetHashCode() ?? 0;
        }
        public override bool Equals(object? obj)
        {
            return obj is PlayerRank other &&
                   string.Equals(PlayerName, other.PlayerName, StringComparison.Ordinal);
        }

        public int CompareTo(PlayerRank? obj)
        {
            if (obj == null) return 0;
            return -AppearanceCount.CompareTo(obj.AppearanceCount);
        }
    }
}
