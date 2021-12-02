using Data;
using Domain.Common;

namespace Domain
{
    public class Occupation : BaseEntity<OccupationData>
    {
        public Occupation() : this(null) { }
        public Occupation(OccupationData d) : base(d) { }
        public string name => Data?.name ?? "-";
    }
}