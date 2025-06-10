using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models
{
    public class MatchRank : IComparable<MatchRank>
    {
        public required string Location { get; set; }
        public required int Attendance { get; set; }
        public required string HomeTeamCountry { get; set; }
        public required string AwayTeamCountry { get; set; }

        public int CompareTo(MatchRank? other)
        {
            if (other == null) return 0;
            return -Attendance.CompareTo(other.Attendance);
        }
    }
}
