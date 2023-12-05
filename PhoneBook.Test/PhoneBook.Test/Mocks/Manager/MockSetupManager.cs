using Moq;
using PhoneBook.Persistence.Context;
using PhoneBook.Persistence.Context.Interface;
using PhoneBook.Persistence.Models;
using PhoneBook.Persistence.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Test.Mocks.Manager
{
    public static class MockSetupManager
    {
        public static List<PersonDataModel> GetListOfPersons()
        {
            var list = new List<PersonDataModel>();
            list.Add(new PersonDataModel()
            {
                Id = 1,
                CompanyRef = 1,
                FullAddress = "1, Regeant Street, Sliema, Malta",
                FullName = "Matthew Caruana",
                PhoneNumber = "+35699112233",
                Company = new CompanyDataModel()
                {
                    ID = 1,
                    CompanyName = "Company A",
                    RegistrationDate = new DateTime(2020, 1, 1),
                    Persons = new List<PersonDataModel>()
                    {
                        new PersonDataModel()
                        {
                            Id = 1,
                            CompanyRef = 1,
                            FullAddress = "1, Regeant Street, Sliema, Malta",
                            FullName = "Matthew Caruana",
                            PhoneNumber = "+35699112233"
                        },
                        new PersonDataModel()
                        {
                            Id = 2,
                            CompanyRef = 1,
                            FullAddress = "50, Main Street, Fgura, Malta",
                            FullName = "Albert Vella",
                            PhoneNumber = "+35699445511"
                        }
                    }
                }
            });

            list.Add(new PersonDataModel()
            {
                Id = 2,
                CompanyRef = 1,
                FullAddress = "50, Main Street, Fgura, Malta",
                FullName = "Albert Vella",
                PhoneNumber = "+35699445511",
                Company = new CompanyDataModel()
                {
                    ID = 1,
                    CompanyName = "Company A",
                    RegistrationDate = new DateTime(2020, 1, 1),
                    Persons = new List<PersonDataModel>()
                    {
                        new PersonDataModel()
                        {
                            Id = 1,
                            CompanyRef = 1,
                            FullAddress = "1, Regeant Street, Sliema, Malta",
                            FullName = "Matthew Caruana",
                            PhoneNumber = "+35699112233"
                        },
                        new PersonDataModel()
                        {
                            Id = 2,
                            CompanyRef = 1,
                            FullAddress = "50, Main Street, Fgura, Malta",
                            FullName = "Albert Vella",
                            PhoneNumber = "+35699445511"
                        }
                    }
                }
            });

            list.Add(new PersonDataModel()
            {
                Id = 3,
                CompanyRef = 2,
                FullAddress = "25, Saint Paul Street, Zabbar, Malta",
                FullName = "Jake Attard",
                PhoneNumber = "+35699778899",
                Company = new CompanyDataModel()
                {
                    ID = 2,
                    CompanyName = "Company B",
                    RegistrationDate = new DateTime(2022, 5, 20),
                    Persons = new List<PersonDataModel>()
                    {
                        new PersonDataModel()
                        {
                            Id = 3,
                            CompanyRef = 2,
                            FullAddress = "25, Saint Paul Street, Zabbar, Malta",
                            FullName = "Jake Attard",
                            PhoneNumber = "+35699778899"
                        }
                    }
                }
            });

            return list;
        }

        public static List<CompanyDataModel> GetListOfCompanies()
        {
            var list = new List<CompanyDataModel>();
            list.Add(new CompanyDataModel()
            {
                ID = 1,
                CompanyName = "Company A",
                RegistrationDate = new DateTime(2020, 1, 1),
                Persons = new List<PersonDataModel>()
                {
                    new PersonDataModel()
                    {
                        Id = 1,
                        CompanyRef = 1,
                        FullAddress = "1, Regeant Street, Sliema, Malta",
                        FullName = "Matthew Caruana",
                        PhoneNumber = "+35699112233"
                    },
                    new PersonDataModel()
                    {
                        Id = 2,
                        CompanyRef = 1,
                        FullAddress = "50, Main Street, Fgura, Malta",
                        FullName = "Albert Vella",
                        PhoneNumber = "+35699445511"
                    }
                }
            });

            list.Add(new CompanyDataModel()
            {
                ID = 2,
                CompanyName = "Company B",
                RegistrationDate = new DateTime(2022, 5, 20),
                Persons = new List<PersonDataModel>()
                {
                    new PersonDataModel()
                    {
                        Id = 3,
                        CompanyRef = 2,
                        FullAddress = "25, Saint Paul Street, Zabbar, Malta",
                        FullName = "Jake Attard",
                        PhoneNumber = "+35699778899"
                    }
                }
                
             });

            list.Add(new CompanyDataModel()
            {
                ID = 3,
                CompanyName = "CCC Company",
                RegistrationDate = new DateTime(2023, 2, 4),
                Persons = new List<PersonDataModel>()
            });

            return list;
        }
    }
}
