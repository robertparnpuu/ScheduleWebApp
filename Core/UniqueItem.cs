using System;

namespace Core
{
    public abstract class UniqueItem
    {
        public virtual string id { get; set; } = Guid.NewGuid().ToString();
    }
}
