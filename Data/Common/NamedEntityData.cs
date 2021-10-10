using Core;

namespace Data.Common
{
    public class NamedEntityData : BaseEntityData, INamedEntity
    {
        public string name {  get; set; }
    }
}
