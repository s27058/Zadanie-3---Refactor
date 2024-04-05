using System;

namespace LegacyApp
{
    public class User
    {
        public object Client { get; internal set; }
        private DateTime _dateOfBirth;

        public DateTime DateOfBirth
        {
            get => _dateOfBirth;
            internal set
            {
                if (value > DateTime.Now.AddYears(-21))
                {
                    throw new ArgumentException("User is younger than 21 years.", "DateOfBirth");
                }

                _dateOfBirth = DateOfBirth;
            }
        }
        private string _emailAddress;
        public string EmailAddress
        {
            get => _emailAddress;
            internal set
            {
                if (!value.Contains("@") && !value.Contains("."))
                {
                    throw new ArgumentException("EmailAddress is invalid", "EmailAddress");
                }

                _emailAddress = value;
            }
        }
        private string _firstName;
        public string FirstName {
            get => _firstName;
            internal set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("FirstName is empty or null", "FirstName");
                }

                _firstName = value;
            }
        }
        private string _lastName;
        public string LastName {
            get => _lastName;
            internal set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("LastName is empty or null", "LastName");
                }

                _lastName = value;
            }
        }
        public bool HasCreditLimit { get; internal set; }
        private int _creditLimit;

        public int CreditLimit
        {
            get => _creditLimit;
            internal set
            {
                if (value < 500 && HasCreditLimit)
                {
                    throw new ArgumentException("CreditLimit is too low.", "CreditLimit");
                }

                _creditLimit = value;
            }
        }
    }
}