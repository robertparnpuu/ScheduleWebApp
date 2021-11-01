using System;
using Data;

namespace Infra.Initializer
{
    public static class DbInitializer
    {

        public static void Initialize(ApplicationDbContext dataBase)
        {
            InitializePerson(dataBase);
            InitializeAddress(dataBase);
            InitializeContact(dataBase);
            InitializeWeekDays(dataBase);
        }

        public static void InitializePerson(ApplicationDbContext dataBase)
        {
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
        public static void InitializeAddress(ApplicationDbContext dataBase)
        {
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
        public static void InitializeContact(ApplicationDbContext dataBase)
        {
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
            }
            };
            dataBase.Contacts.AddRange(contacts);
            dataBase.SaveChanges();
        }
        public static void InitializeWeekDays(ApplicationDbContext dataBase)
        {
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