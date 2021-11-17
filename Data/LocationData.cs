using Core;
using Data.Common;

namespace Data
{
    public class LocationData : WithContactData, INamedEntity
    {
        public string name { get; set; }
    }
}
