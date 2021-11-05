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
            InitializeDepartment(dataBase, newDb);
            InitializeLocation(dataBase, newDb);
            InitializeOccupations(dataBase, newDb);
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
                country = "Eesti"
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
                email = "contact1@hot.ee",
                phoneNumber = "56111111",
                addressId = "addressId1"
            },
            new ContactData()
                {
                id = "contactId2",
                email = "contact2@hot.ee",
                phoneNumber = "56222222",
                addressId = "addressId1"
            },
            new ContactData()
            {
                id = "contactId3",
                email = "contact3@hot.ee",
                phoneNumber = "56333333",
                addressId = "addressId2"
            },
            new ContactData()
            {
                id = "contactId4",
                email = "contact4@hot.ee",
                phoneNumber = "56444444",
                addressId = "addressId1"
            }
            };
            dataBase.Contacts.AddRange(contacts);
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
                contactId = "contactId1"
            },
            new DepartmentData()
            {
                id = "departmentId2",
                name = "Finants",
                contactId = "contactId2"
            },
            new DepartmentData()
            {
                id = "departmentId3",
                name = "Reklaam",
                contactId = "contactId3"
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
                contactId = "contactId3"
            },
            new LocationData()
            {
                id = "locationId2",
                name = "Lasnamäe ladu",
                contactId = "contactId3"
            },
            new LocationData()
            {
                id = "locationId3",
                name = "Õismäe restoran",
                contactId = "contactId4"
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
            contactId = "contactId1"
            },
            new PersonData
            {
            id="personId2",
            firstName = "Jakob",
            lastName = "Hurt",
            roleAssignmentId = "roleAssignmentId1",
            idCode = "39111111111",
            dateOfBirth =DateTime.Parse("2020-05-02"),
            contactId = "contactId2"
            },
            new PersonData
            {
            id="personId3",
            firstName = "Anton Hansen",
            lastName = "Tammsaare",
            roleAssignmentId = "roleAssignmentId2",
            idCode = "39222222222",
            dateOfBirth =DateTime.Parse("2019-06-03"),
            contactId = "contactId2"
            },
            new PersonData
            {
            id="personId4",
            firstName = "Jaak",
            lastName = "Peterson",
            roleAssignmentId = "roleAssignmentId2",
            idCode = "39333333333",
            dateOfBirth =DateTime.Parse("2018-07-04"),
            contactId = "contactId3"
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
                startTime = DateTime.Parse("2021-04-01"),
                endTime = DateTime.Parse("2021-04-01"),
            },
            new StandardShiftData()
            {
                id="standardShiftId2",
                name="mustamäe ladu, kokk, hommikune, nädalavahetus",
                locationId = "locationId1",
                occupationId = "occupationId1",
                startTime = DateTime.Parse("2021-04-01"),
                endTime = DateTime.Parse("2021-04-01"),
            },
            new StandardShiftData()
            {
                id="standardShiftId3",
                name="Lasnamäe ladu, laomees 6-12",
                locationId = "locationId2",
                occupationId = "occupationId3",
                startTime = DateTime.Parse("2021-04-01"),
                endTime = DateTime.Parse("2021-04-01"),
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