﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CARS.Model
{
    public class Victim
    {
        private int _victimID;
        private string _firstName;
        private string _lastName;
        private DateTime _dateOfBirth;
        private string _gender;
        private string _contactInformation;

        public Victim() { }

        public Victim(int victimID, string firstName, string lastName, DateTime dateOfBirth, string gender, string contactInformation)
        {
            _victimID = victimID;
            _firstName = firstName;
            _lastName = lastName;
            _dateOfBirth = dateOfBirth;
            _gender = gender;
            _contactInformation = contactInformation;
        }

        public int VictimID
        {
            get { return _victimID; }
            set { _victimID = value; }
        }

        public string FirstName
        {
            get { return _firstName; }
            set { _firstName = value; }
        }

        public string LastName
        {
            get { return _lastName; }
            set { _lastName = value; }
        }

        public DateTime DateOfBirth
        {
            get { return _dateOfBirth; }
            set { _dateOfBirth = value; }
        }

        public string Gender
        {
            get { return _gender; }
            set { _gender = value; }
        }

        public string ContactInformation
        {
            get { return _contactInformation; }
            set { _contactInformation = value; }
        }
    }
}
