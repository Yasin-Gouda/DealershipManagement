using System;
using System.Collections.Generic;
using System.Text;

namespace DealershipManagement
{
    internal class Customer
    {
        public int Id
        {
            get;
            init
            {
                if (value <= 0)
                    throw new ArgumentOutOfRangeException(
                        nameof(Id), "Id must be positive.");
                field = value;
            }
        }

        public string FullName { get; private set; }

        public string PhoneNumber { get; private set; }

        public string Email { get; private set; }

        public Customer(int id, string fullName, string phoneNumber, string email)
        {
            if (string.IsNullOrWhiteSpace(fullName))
                throw new ArgumentException("Full name cannot be null or empty.", nameof(fullName));
            if (string.IsNullOrWhiteSpace(phoneNumber))
                throw new ArgumentException("Phone number cannot be null or empty.", nameof(phoneNumber));
            if (string.IsNullOrWhiteSpace(email))
                throw new ArgumentException("Email cannot be null or empty.", nameof(email));
            if (!email.Contains("@") || email.StartsWith('@') || email.EndsWith('@'))
                throw new ArgumentException("Invalid Email address.", nameof(email));
            Id = id;
            FullName = fullName;
            PhoneNumber = phoneNumber;
            Email = email;
        }

        public void UpdatePhoneNumber(string phoneNumber)
        {
            if (string.IsNullOrWhiteSpace(phoneNumber))
                throw new ArgumentException("Phone number cannot be null or empty.", nameof(phoneNumber));
            
            PhoneNumber = phoneNumber;
            
        }

        public void UpdateEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                throw new ArgumentException("Email cannot be null or empty.", nameof(email));
            if (!email.Contains("@") || email.StartsWith('@') || email.EndsWith('@'))
                throw new ArgumentException("Invalid Email address.", nameof(email));

            Email = email;
        }

        public void UpdateFullName(string fullName)
        {
            if (string.IsNullOrWhiteSpace(fullName))
                throw new ArgumentException("Full name cannot be null or empty.", nameof(fullName));
            FullName = fullName;
        }


    }
}
