using System;

namespace Core
{
    public abstract class UniqueItem
    {
        public string id { get; set; } = Guid.NewGuid().ToString();
    }
}
