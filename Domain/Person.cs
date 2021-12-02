﻿using System;
using Data;
using Domain.Common;
using Domain.Repos;

namespace Domain
{
    public class Person : WithContact<PersonData>
    {
        public Person() : this(null) { }

        public Person(PersonData d):base(d) { }

        public string firstName => Data?.firstName ?? "-";
        public string lastName => Data?.lastName ?? "-";
        public DateTime? dateOfBirth => Data?.dateOfBirth ?? DateTime.MinValue;
        public string idCode => Data?.idCode ?? "-";
        public string roleAssignmentId => Data?.roleAssignmentId ?? "-";

        public string fullName => $"{firstName} {lastName}";
        public string fullAddress=> partyContact?.fullAddress ?? "-";
        

    }
}