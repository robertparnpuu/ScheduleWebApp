using System;
using Data;
using Domain.Common;

namespace Domain
{
    public class Person : BaseEntity<PersonData>
    {
        public Person() : this(null) { }

        public Person(PersonData d) : base(d)
        {
        }
        public string firstName => Data?.firstName ?? "-";
        public string lastName => Data?.lastName ?? "-";

        public DateTime? dateOfBirth => Data?.dateOfBirth;
        public string idCode => Data?.idCode ?? "-";


        public string roleAssignmentId => Data?.roleAssignmentId ?? "-";
        //public RoleAssignment roleAssignment => lazyReadRoleAssignment.Value;
        //internal Lazy<RoleAssignment> lazyReadRoleAssignment { get; }

        public string fullName => $"{firstName} {lastName}";

        //TODO Siin peab ka olema mitu role assignmenti, list siis äkki
    }
}