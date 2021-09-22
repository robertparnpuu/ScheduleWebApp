
using Data;
using Domain.Common;

namespace Domain
{
    public class Person : BaseEntity<PersonData>
    {

        public string name
        {
            get => default;
            set
            {
            }
        }

        public System.DateTime birthday
        {
            get => default;
            set
            {
            }
        }

        public string idCode
        {
            get => default;
            set
            {
            }
        }

        public Contact Contact
        {
            get => default;
            set
            {
            }
        }

        public void getbirtday()
        {

        }
    }
}