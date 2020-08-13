﻿using System;

namespace Examples.Entities
{
    public class Employee : IEquatable<Employee>
    {
        #region Constructor
        public Employee(string firstname, string lastname, byte age, DateTime birthday)
        {
            Firstname = firstname;
            Lastname = lastname;
            Age = age;
            Birthday = birthday;
        }
        #endregion

        #region Auto-Implemented Properties
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public byte Age { get; set; }
        public DateTime Birthday { get; set; }
        #endregion

        #region IEquatable Interface Implementation
        /// <summary>
        /// <see cref="IEquatable{T}"/> implementation
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        public bool Equals(Employee employee)
        {
            if(employee == null)
            {
                return false;
            }
            else
            {
                return string.Equals(Firstname, employee.Firstname) &&
                       string.Equals(Lastname, employee.Lastname) &&
                                Age == employee.Age &&
                                Birthday == employee.Birthday;
            }
        }
        #endregion

        #region object.Equals method override
        /// <summary>
        /// Compares an object with the current object to check if they match
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if(obj is null)
            {
                return false;
            }
            if(ReferenceEquals(this, obj))
            {
                return true;
            }
            if(obj.GetType() != GetType())
            {
                return false;
            }
            return Equals(obj as Employee);
        }
        #endregion

        #region object.GetHashCode method override
        /// <summary>
        /// Generates a unique number which only an object with exact same values should be able to provide
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            // Tell CLR we dont care if it overflows or underflows in this instance
           unchecked
            {
                // Prime number so hash collision is more unlikely to happen
                int hash = 17;

                // Multiply hash with a second prime number and add each fields hash code
                hash = hash * 23 + Firstname.GetHashCode();
                hash = hash * 23 + Lastname.GetHashCode();
                hash = hash * 23 + Age.GetHashCode();
                hash = hash * 23 + Birthday.GetHashCode();

                // Return the hash
                return hash;
            }
        }
        #endregion
    }
}