namespace Mov4e.Presenter.ProfileScreenPresenter
{
    public interface ISettingsPresenter
    {
        void ChangeAge(int Age);
        void ChangeEmail(string NewMail);
        void ChangeFirstName(string firstName);
        void ChangeGender(string Gender);
        void ChangeLastName(string lastName);
        void ChangePassword(string oldPass, string newPass,string repeatedPass);
        void ChangeUserName(string UserName);
    }
}