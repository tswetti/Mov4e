namespace Mov4e.Service.ProfileScreenService
{
    public interface IProfileScreenSettingsService
    {

        /// <summary>
        /// This method updates user e-mail but furst validates it.
        /// </summary>
        /// <param name="Mail"></param>
        void UpdateMail(string Mail);

        /// <summary>
        /// This method updates user age but furst validates it.
        /// </summary>
        /// <param name="Age"></param>
        void UpdateAge(int Age);

        /// <summary>
        /// This method updates user gender but furst validates it.
        /// </summary>
        /// <param name="Gender"></param>
        void UpdateGender(string Gender);

        /// <summary>
        /// This method updates user password but furst validates it.
        /// </summary>
        /// <param name="oldPass"></param>
        /// <param name="newPass"></param>
        void UpdatePassword(string oldPass, string newPass, string repeatedPass);

        /// <summary>
        /// This method updates user UserName but furst validates it.
        /// </summary>
        /// <param name="userName"></param>
        void UpdateUserName(string userName);

        /// <summary>
        /// This method updates user first name but furst validates it.
        /// </summary>
        /// <param name="firstName"></param>
        void UpdateFirstName(string firstName);

        /// <summary>
        /// This method updates user last name but furst validates it.
        /// </summary>
        /// <param name="lastName"></param>
        void UpdateLastName(string lastName);
    }
}