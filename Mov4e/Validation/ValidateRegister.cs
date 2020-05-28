using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using Mov4e.Exceptions;
using static Mov4e.Hash;
using System.Net.Mail;

namespace Mov4e.Validation
{
     public static class ValidateRegister
    {
        /// <summary>
        ///  This method checks if the username is already taken.
        /// </summary>
        /// <param name="listOfAllUserUserNames"></param>
        /// <param name="UserName"></param>
        public static void isUserNameTaken(ICollection<string> listOfAllUserUserNames, string UserName)
        {
            if (listOfAllUserUserNames.Contains(UserName))
            {
                throw new IncorrectUserDataException("Username Already Taken!");
            }
        }

        /// <summary>
        /// This method checks if the user name is correct (matches the requirements).
        /// </summary>
        /// <param name="UserName"></param>
        public static void isUserNameValid(string UserName)
        {
            string UsernameRegex = "^[A-Za-z0-9]+(?:[_-][A-Za-z0-9]+)*$";

            if (!Regex.IsMatch(UserName, UsernameRegex) || UserName.Length < 4)
            {
                throw new IncorrectUserDataException("UserName is not valid!");
            }
        }

        /// <summary>
        /// This method checks if the password is correct (matches the requirements).
        /// </summary>
        /// <param name="password"></param>
        public static void isPasswordCorrect(string password)
        {
            string passwordRegex = "^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}";

            if (!Regex.IsMatch(password, passwordRegex))
            {
                throw new IncorrectUserDataException("Password format doesn't match!\nIt must contains one uppercase and one lowercase letter, one symbol,\none number and it must be at least 8 symbols long!");
            }
        }

        /// <summary>
        /// This method checks if the first and last name are correct (matches the requirements).
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        public static void areFirstAndLastNameValid(string firstName, string lastName)
        {
            string nameRegex = "^[A-Za-z]*$";

            if (!Regex.IsMatch(firstName, nameRegex) || !Regex.IsMatch(lastName, nameRegex) || string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName) || string.IsNullOrEmpty(lastName) || string.IsNullOrWhiteSpace(firstName) || string.IsNullOrWhiteSpace(lastName))
            {
                throw new IncorrectUserDataException("The format of First or Last Name is incorrect!");
            }
        }

        /// <summary>
        /// This method checks if the e-mail is correct (matches the requirements).
        /// </summary>
        /// <param name="email"></param>
        public static void isEMailCorrect(string email)
        {
            try
            {
                MailAddress mail = new MailAddress(email);
            }
            catch(Exception)
            { 
                throw new IncorrectUserDataException("Inserted e-mail is incorrect!");
            }
        }

        /// <summary>
        /// This method checks if the e-mail is taken.
        /// </summary>
        /// <param name="listOfAllEMails"></param>
        /// <param name="email"></param>
        public static void isEMailTaken(ICollection<string> listOfAllEMails, string email)
        {
            if (listOfAllEMails.Contains(email))
            {
                throw new IncorrectUserDataException("Inserted e-mail is taken!");
            }
        }

        /// <summary>
        /// This method cecks if the gender is correct (matches the requirements).
        /// </summary>
        /// <param name="gender"></param>
        public static void isGenderValid(string gender)
        {
            string genderRegex = "^[MF]$";
            if (!Regex.IsMatch(gender, genderRegex) && gender != null)
                throw new IncorrectUserDataException("Your gender can be ONLY female or male!!!");
        }

        /// <summary>
        /// This method cecks if the age is correct (matches the requirements).
        /// </summary>
        /// <param name="age"></param>
        public static void isAgeValid(int age)
        {
            if (age < 0)
                throw new IncorrectUserDataException("Your age can't be under 0!");
        }
    }
}
