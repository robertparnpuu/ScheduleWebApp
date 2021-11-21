using Data;
using Domain.Common;

namespace Domain
{
    public class Location : WithContact<LocationData>
    {
        public Location() : this(null) { }

        public Location(LocationData d) : base(d)
        { }
        public string name => Data?.name ?? "-";
        public string fullAddress => partyContact?.fullAddress ?? "-";
        public string fullContact => partyContact?.fullContact ?? "-";

    }
}