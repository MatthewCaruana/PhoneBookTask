﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Persistence.Models
{
    public class PersonDataModel
    {
        public string Id { get; set; }
        public string CompanyRef { get; set; }
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public string FullAddress { get; set; }

        public virtual CompanyDataModel Company { get; set; }
    }
}