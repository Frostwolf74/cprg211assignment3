﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3
{
    /// <summary>
    /// Represents a User with ID, name, email, and password.
    /// Serializable to support object persistence (e.g., in linked list serialization).
    /// </summary>
    [Serializable]
    [DataContract]
    public class User : IEquatable<User>
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Email { get; set; }
        [DataMember]
        public string Password { get; set; }

        /// <summary>
        /// Required by the serializer to create an empty instance.
        /// </summary>
        public User() { }

        /// <summary>
        /// Initializes a User object.
        /// </summary>
        /// <param name="id">ID</param>
        /// <param name="name">Name</param>
        /// <param name="email">Email</param>
        /// <param name="password">Plain-text password</param>
        public User(int id, string name, string email, string password)
        {
            Id = id;
            Name = name;
            Email = email;
            Password = password;
        }

        /// <summary>
        /// Checks if the passed password is correct.
        /// </summary>
        /// <param name="input">Inputted password</param>
        /// <returns>True if password is correct</returns>
        public bool IsCorrectPassword(string input)
        {
            if (string.IsNullOrEmpty(Password) == string.IsNullOrEmpty(input))
                // Return true if both input and password are null or empty
                return true;
            else if (string.IsNullOrEmpty(Password) != string.IsNullOrEmpty(input))
                // Return false if input or password is null or empty (not both)
                return false;
            else
                // Otherwise, check if input and Password match.
                return Password.Equals(input);
        }

        /// <summary>
        /// Checks if object is equal to another object.
        /// </summary>
        /// <param name="obj">Other object</param>
        /// <returns>True if this object is equal to other object</returns>
        public override bool Equals(object other)
        {
            if (!(other is User otherUser))
                return false;

            return Id == otherUser.Id && Name.Equals(otherUser.Name) && Email.Equals(otherUser.Email);
        }

        public bool Equals(User other)
        {
            return !(other is null) &&
                   Id == other.Id &&
                   Name == other.Name &&
                   Email == other.Email &&
                   Password == other.Password;
        }

        /// <summary>
        /// Generates unique ID for User object
        /// </summary>
        /// <returns>Unique hash code/ID</returns>
        public override int GetHashCode()
        {
            int hashCode = 825453597;
            hashCode = hashCode * -1521134295 + Id.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Email);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Password);
            return hashCode;
        }
    }
}
