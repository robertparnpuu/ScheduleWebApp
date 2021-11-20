using System;
using System.Linq;
using Data;

namespace Infra.Initializer
{
    public static class DbInitializer
    {

        public static void Initialize(ApplicationDbContext dataBase, bool newDb)
        {
            dataBase.SaveChanges();
            InitializeAddress(dataBase, newDb);
            InitializeContact(dataBase, newDb);
            InitializeContract(dataBase, newDb);
            InitializeDepartment(dataBase, newDb);
            InitializeLocation(dataBase, newDb);
            InitializeOccupations(dataBase, newDb);
            InitializePartyContact(dataBase, newDb);
            InitializePerson(dataBase, newDb);
            InitializeWeekDay(dataBase, newDb);
            InitializeRequirement(dataBase,newDb);
            InitializeShiftAssignment(dataBase,newDb);
            InitializeStandardShift(dataBase, newDb);
        }

        public static void InitializeAddress(ApplicationDbContext dataBase, bool newDb)
        {
            if (!newDb)
                if (dataBase.Addresses.Any()) return;

            var addresses = new[]
            {
            new AddressData 
            {
                id = "addressId1",
                apartmentNumber = "30",
                streetName = "Kuke",
                houseNumber = "1",
                city = "Tallinn",
                zipCode ="12345",
                region = "Harjumaa",
                country = "Eesti",
            },
            new AddressData
            {
                id="addressId2",
                apartmentNumber = "20",
                streetName = "Männi",
                houseNumber = "15",
                city = "Tartu",
                zipCode ="67891",
                region = "Tartumaa",
                country = "Eesti"
            },
            new AddressData
            {
                id="addressId3",
                apartmentNumber = "17",
                streetName = "Kuuse",
                houseNumber = "1",
                city = "Narva",
                zipCode ="13579",
                region = "Ida-Virumaa",
                country = "Eesti"
            },
            new AddressData
            {
                id="addressId4",
                apartmentNumber = "4",
                streetName = "Test4",
                houseNumber = "4",
                city = "Tallinn",
                zipCode ="44444",
                region = "Harjumaa",
                country = "Eesti"
            },
            new AddressData
            {
                id="addressId5",
                apartmentNumber = "5",
                streetName = "Test5",
                houseNumber = "5",
                city = "Tallinn",
                zipCode ="55555",
                region = "Harjumaa",
                country = "Eesti"
            },
            new AddressData
            {
                id="addressId6",
                apartmentNumber = "6",
                streetName = "Test6",
                houseNumber = "6",
                city = "Tallinn",
                zipCode ="66666",
                region = "Harjumaa",
                country = "Eesti"
            },
            new AddressData
            {
            id="addressId7",
            apartmentNumber = "7",
            streetName = "Test7",
            houseNumber = "7",
            city = "Tallinn",
            zipCode ="77777",
            region = "Harjumaa",
            country = "Eesti"
            },
            new AddressData
            {
            id="addressId8",
            apartmentNumber = "8",
            streetName = "Test8",
            houseNumber = "8",
            city = "Tallinn",
            zipCode ="88888",
            region = "Harjumaa",
            country = "Eesti"
            },
            new AddressData
            {
            id="addressId9",
            apartmentNumber = "9",
            streetName = "Test9",
            houseNumber = "9",
            city = "Tallinn",
            zipCode ="99999",
            region = "Harjumaa",
            country = "Eesti"
            },
            new AddressData
            {
            id="addressId10",
            apartmentNumber = "10",
            streetName = "Test10",
            houseNumber = "10",
            city = "Tallinn",
            zipCode ="10101",
            region = "Harjumaa",
            country = "Eesti"
            }
            };
            dataBase.Addresses.AddRange(addresses);
            dataBase.SaveChanges();
        }
        public static void InitializeContact(ApplicationDbContext dataBase, bool newDb)
        {
            if (!newDb)
                if (dataBase.Contacts.Any()) return;
            var contacts = new[]
            {
            new ContactData()
            {
                id = "contactId1",
                email = "test1@hot.ee",
                phoneNumber = "56111111"
            },
            new ContactData()
            {
                id = "contactId2",
                email = "test2@hot.ee",
                phoneNumber = "56222222"
            },
            new ContactData()
            {
                id = "contactId3",
                email = "test3@hot.ee",
                phoneNumber = "56333333"
            },
            new ContactData()
            {
                id = "contactId4",
                email = "test4@hot.ee",
                phoneNumber = "56444444"
            },
            new ContactData()
            {
            id = "contactId5",
            email = "test5@hot.ee",
            phoneNumber = "56555555"
            },
            new ContactData()
            {
            id = "contactId6",
            email = "test6@hot.ee",
            phoneNumber = "56666666"
            },
            new ContactData()
            {
            id = "contactId7",
            email = "test7@hot.ee",
            phoneNumber = "5777777"
            },
            new ContactData()
            {
            id = "contactId8",
            email = "test8@hot.ee",
            phoneNumber = "56888888"
            },
            new ContactData()
            {
            id = "contactId9",
            email = "test9@hot.ee",
            phoneNumber = "56888888"
            },
            new ContactData()
            {
            id = "contactId10",
            email = "test10@hot.ee",
            phoneNumber = "56101010"
            }
            };
            dataBase.Contacts.AddRange(contacts);
            dataBase.SaveChanges();
        }
        public static void InitializeContract(ApplicationDbContext dataBase, bool newDb)
        {
            if (!newDb)
                if (dataBase.Contacts.Any()) return;
            var contracts = new[]
            {
            new ContractData()
            {
            id = "contractId1",
            personId = "personId1",
            occupationId = "occupationId2",
            departmentId = "departmentId3",
            validFrom = DateTime.Parse("2021-04-02"),
            validTo=DateTime.Parse("2021-04-03")
            },
            new ContractData()
            {
            id = "contactId2",
            personId = "personId2",
            occupationId = "occupationId2",
            departmentId = "departmentId3",
            validFrom = DateTime.Parse("2021-04-02"),
            validTo=DateTime.Parse("2021-05-03")
            },
            new ContractData()
            {
            id = "contractId3",
            personId = "personId3",
            occupationId = "occupationId2",
            departmentId = "departmentId3",
            validFrom = DateTime.Parse("2021-06-02"),
            },
            new ContractData()
            {
            id = "contractId4",
            personId = "personId3",
            occupationId = "occupationId4",
            departmentId = "departmentId1",
            validFrom = DateTime.Parse("2021-06-02"),
            }
            };
            dataBase.Contracts.AddRange(contracts);
            dataBase.SaveChanges();
        }
        public static void InitializeDepartment(ApplicationDbContext dataBase, bool newDb)
        {
            if (!newDb)
                if (dataBase.Departments.Any()) return;

            var departments = new[]
            {
            new DepartmentData()
            {
                id = "departmentId1",
                name = "Müük",
                partyContactId = "partyContactId1"
            },
            new DepartmentData()
            {
                id = "departmentId2",
                name = "Finants",
                partyContactId = "partyContactId2"
            },
            new DepartmentData()
            {
                id = "departmentId3",
                name = "Reklaam",
                partyContactId = "partyContactId3"
            }
            };
            dataBase.Departments.AddRange(departments);
            dataBase.SaveChanges();
        }
        public static void InitializeLocation(ApplicationDbContext dataBase, bool newDb)
        {
            if (!newDb)
                if (dataBase.Locations.Any()) return;
            var locations = new[]
            {
            new LocationData()
            {
                id = "locationId1",
                name = "Mustamäe ladu",
                partyContactId = "partyContactId5"
            },
            new LocationData()
            {
                id = "locationId2",
                name = "Lasnamäe ladu",
                partyContactId = "partyContactId6"
            },
            new LocationData()
            {
                id = "locationId3",
                name = "Õismäe restoran",
                partyContactId = "partyContactId7"
            }
            };
            dataBase.Locations.AddRange(locations);
            dataBase.SaveChanges();
        }
        public static void InitializeOccupations(ApplicationDbContext dataBase, bool newDb)
        {
            if (!newDb)
                if (dataBase.Occupations.Any()) return;
            var occupations = new[]
            {
            new OccupationData()
            {
                id = "occupationId1",
                name = "Kokk",
            },
            new OccupationData()
            {
                id = "occupationId2",
                name = "Koristaja",
            },
            new OccupationData()
            {
                id = "occupationId3",
                name = "Laomees",
            },
            new OccupationData()
            {
                id = "occupationId4",
                name = "Teenindaja",
            }
            };
            dataBase.Occupations.AddRange(occupations);
            dataBase.SaveChanges();
        }
        public static void InitializePartyContact(ApplicationDbContext dataBase, bool newDb)
        {
            if (!newDb)
                if (dataBase.PartyContacts.Any()) return;
            var contacts = new[]
            {
            new PartyContactData()
            {
            id = "partyContactId1",
            partyId = "personId1",
            addressId="addressId1",
            contactId="contactId1"
            },
            new PartyContactData()
            {
            id = "partyContactId2",
            partyId = "personId2",
            addressId="addressId2",
            contactId="contactId2"
            },
            new PartyContactData()
            {
            id = "partyContactId3",
            partyId = "personId3",
            addressId="addressId3",
            contactId="contactId3"
            },
            new PartyContactData()
            {
            id = "partyContactId4",
            partyId = "personId4",
            addressId="addressId4",
            contactId="contactId4"
            },
            new PartyContactData()
            {
            id = "partyContactId5",
            partyId = "locationId1",
            addressId="addressId5",
            contactId="contactId5"
            },
            new PartyContactData()
            {
            id = "partyContactId6",
            partyId = "locationId2",
            addressId="addressId6",
            contactId="contactId6"
            },
            new PartyContactData()
            {
            id = "partyContactId7",
            partyId = "locationId3",
            addressId="addressId7",
            contactId="contactId7"
            },
            new PartyContactData()
            {
            id = "partyContactId8",
            partyId = "departmentId1",
            addressId="addressId8",
            contactId="contactId8"
            },
            new PartyContactData()
            {
            id = "partyContactId9",
            partyId = "departmentId2",
            addressId="addressId9",
            contactId="contactId9"
            },
            new PartyContactData()
            {
            id = "partyContactId10",
            partyId = "departmentId3",
            addressId="addressId10",
            contactId="contactId10"
            }
            };
            dataBase.PartyContacts.AddRange(contacts);
            dataBase.SaveChanges();
        }
        public static void InitializePerson(ApplicationDbContext dataBase, bool newDb)
        {
            if (!newDb)
                if (dataBase.Persons.Any()) return;
            var people = new[]
            {
            new PersonData
            {
            id="personId1",
            firstName = "Lennart",
            lastName = "Meri",
            roleAssignmentId = "roleAssignmentId1",
            idCode = "39000000000",
            dateOfBirth =DateTime.Parse("2021-04-01"),
            partyContactId = "partyContactId1"
            },
            new PersonData
            {
            id="personId2",
            firstName = "Jakob",
            lastName = "Hurt",
            roleAssignmentId = "roleAssignmentId1",
            idCode = "39111111111",
            dateOfBirth =DateTime.Parse("2020-05-02"),
            partyContactId = "partyContactId2"
            },
            new PersonData
            {
            id="personId3",
            firstName = "Anton Hansen",
            lastName = "Tammsaare",
            roleAssignmentId = "roleAssignmentId2",
            idCode = "39222222222",
            dateOfBirth =DateTime.Parse("2019-06-03"),
            partyContactId = "partyContactId3"
            },
            new PersonData
            {
            id="personId4",
            firstName = "Jaak",
            lastName = "Peterson",
            roleAssignmentId = "roleAssignmentId2",
            idCode = "39333333333",
            dateOfBirth =DateTime.Parse("2018-07-04"),
            partyContactId = "partyContactId4"
            }
            };
            dataBase.Persons.AddRange(people);
            dataBase.SaveChanges();
        }
        public static void InitializeRequirement(ApplicationDbContext dataBase, bool newDb)
        {
            if (!newDb)
                if (dataBase.Requirements.Any()) return;
            var r = new[]
            {
            new RequirementData()
            {
                id="requirementId1",
                locationId = "locationId1",
                occupationId = "occupationId1",
                weekDayId = "1",
                startTime = DateTime.Parse("2021-04-01"),
                endTime = DateTime.Parse("2021-04-02"),
                minEmployees = 1,
                maxEmployees = 4
            },
            new RequirementData()
            {
                id="requirementId2",
                locationId = "locationId1",
                occupationId = "occupationId1",
                weekDayId = "2",
                startTime = DateTime.Parse("2021-04-01"),
                endTime = DateTime.Parse("2021-04-02"),
                minEmployees = 1,
                maxEmployees = 4
            },
            new RequirementData()
            {
                id="requirementId3",
                locationId = "locationId2",
                occupationId = "occupationId1",
                weekDayId = "1",
                startTime = DateTime.Parse("2021-05-01"),
                endTime = DateTime.Parse("2021-05-02"),
                minEmployees = 1,
                maxEmployees = 4
            },
            new RequirementData()
            {
                id="requirementId4",
                locationId = "locationId2",
                occupationId = "occupationId2",
                weekDayId = "1",
                startTime = DateTime.Parse("2021-05-01"),
                endTime = DateTime.Parse("2021-05-02"),
                minEmployees = 1,
                maxEmployees = 4
            },
            new RequirementData()
            {
                id="requirementId5",
                locationId = "locationId2",
                occupationId = "occupationId3",
                weekDayId = "1",
                startTime = DateTime.Parse("2021-05-01"),
                endTime = DateTime.Parse("2021-05-02"),
                minEmployees = 2,
                maxEmployees = 4
            },
            new RequirementData()
                {
                id="requirementId6",
                locationId = "locationId2",
                occupationId = "occupationId4",
                weekDayId = "1",
                startTime = DateTime.Parse("2021-05-01"),
                endTime = DateTime.Parse("2021-05-02"),
                minEmployees = 1,
                maxEmployees = 5
            },
            new RequirementData()
            {
                id="requirementId7",
                locationId = "locationId3",
                occupationId = "occupationId1",
                weekDayId = "1",
                startTime = DateTime.Parse("2021-06-01"),
                endTime = DateTime.Parse("2021-06-02"),
                minEmployees = 4,
                maxEmployees = 4
            }
            };
            dataBase.Requirements.AddRange(r);
            dataBase.SaveChanges();
        }
        public static void InitializeShiftAssignment(ApplicationDbContext dataBase, bool newDb)
        {
            if (!newDb)
                if (dataBase.ShiftAssignments.Any()) return;
            var sa = new[]
            {
            new ShiftAssignmentData()
            {
                id="shiftAssignmentId1",
                personId = "personId1",
                locationId = "locationId1",
                startTime = DateTime.Parse("2021-04-01"),
                endTime = DateTime.Parse("2021-04-01"),
            },
            new ShiftAssignmentData()
            {
                id="shiftAssignmentId2",
                personId = "personId1",
                locationId = "locationId2",
                startTime = DateTime.Parse("2021-04-02"),
                endTime = DateTime.Parse("2021-04-02"),
            },
            new ShiftAssignmentData()
            {
                id="shiftAssignmentId3",
                personId = "personId2",
                locationId = "locationId3",
                startTime = DateTime.Parse("2021-04-03"),
                endTime = DateTime.Parse("2021-04-03"),
            }
            };
            dataBase.ShiftAssignments.AddRange(sa);
            dataBase.SaveChanges();
        }
        public static void InitializeStandardShift(ApplicationDbContext dataBase, bool newDb)
        {
            if (!newDb)
                if (dataBase.ShiftAssignments.Any()) return;
            var ss = new[]
            {
            new StandardShiftData()
            {
                id="standardShiftId1",
                name="mustamäe ladu, kokk 9-5",
                locationId = "locationId1",
                occupationId = "occupationId1",
                startTime = DateTime.Parse("2021-04-01T09:00:00"),
                endTime = DateTime.Parse("2021-04-01T17:00:00"),
            },
            new StandardShiftData()
            {
                id="standardShiftId2",
                name="mustamäe ladu, kokk, hommikune, nädalavahetus",
                locationId = "locationId1",
                occupationId = "occupationId1",
                startTime = DateTime.Parse("2021-04-01T07:00:00"),
                endTime = DateTime.Parse("2021-04-01T14:00:00"),
            },
            new StandardShiftData()
            {
                id="standardShiftId3",
                name="Lasnamäe ladu, laomees 6-12",
                locationId = "locationId2",
                occupationId = "occupationId3",
                startTime = DateTime.Parse("2021-04-01T06:00:00"),
                endTime = DateTime.Parse("2021-04-01T12:00:00"),
            }
            };
            dataBase.StandardShifts.AddRange(ss);
            dataBase.SaveChanges();
        }
        public static void InitializeWeekDay(ApplicationDbContext dataBase, bool newDb)
        {
            if (!newDb)
                if (dataBase.WeekDays.Any()) return;
            var weekdays = new[]
            {
            new WeekDayData()
            {
            id = "1",
            name = "Monday"
            },
            new WeekDayData()
            {
            id = "2",
            name = "TuesDay"
            },
            new WeekDayData()
            {
            id = "3",
            name = "Wednesday"
            },
            new WeekDayData()
            {
            id = "4",
            name = "Thursday"
            },
            new WeekDayData()
            {
            id = "5",
            name = "Friday"
            },
            new WeekDayData()
            {
            id = "6",
            name = "Saturday"
            },
            new WeekDayData()
            {
            id = "7",
            name = "Sunday"
            }
            };
            dataBase.WeekDays.AddRange(weekdays);
            dataBase.SaveChanges();
        }
    }
}