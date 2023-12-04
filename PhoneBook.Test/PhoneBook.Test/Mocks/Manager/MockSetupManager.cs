﻿using Moq;
using PhoneBook.Persistence.Context;
using PhoneBook.Persistence.Context.Interface;
using PhoneBook.Persistence.Models;
using PhoneBook.Persistence.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
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
                PhoneNumber = "+35699112233"
            });

            list.Add(new PersonDataModel()
            {
                Id = 2,
                CompanyRef = 1,
                FullAddress = "50, Main Street, Fgura, Malta",
                FullName = "Albert Vella",
                PhoneNumber = "+35699445566"
            });

            list.Add(new PersonDataModel()
            {
                Id = 3,
                CompanyRef = 2,
                FullAddress = "25, Saint Paul Street, Zabbar, Malta",
                FullName = "Jake Attard",
                PhoneNumber = "+35699778899"
            });

            return list;
        }
    }
}