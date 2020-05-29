using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mov4e.Service.ProfileScreenService;
using Mov4e.View.ProfileScreenView;

namespace Mov4e.Presenter.ProfileScreenPresenter
{
    public class ProfileScreenPresenter : IProfileScreenPresenter
    {
        IProfileScreen _profileScreen;
        IProfileScreenService _profileScreenService = new ProfileScreenService();

        public ProfileScreenPresenter(IProfileScreen newProfileScreen)
        {
            this._profileScreen = newProfileScreen;
        }

        public ProfileScreenPresenter(IProfileScreen newProfileScreen,IProfileScreenService profileScreenService)
        {
            this._profileScreen = newProfileScreen;
            this._profileScreenService = profileScreenService;

        }

        //Gets information for the user from DB through service
        private void GetUserInformation(int id)
        {
            _profileScreenService.UserAndUserInfoFromDBAndStoreitInModels(id);
        }

        /// <summary>
        /// This method sets user information in the view
        /// </summary>
        /// <param name="id"></param>
        public void SetUserInformation(int id)
        {
            this.GetUserInformation(id);
            _profileScreen.UserName = _profileScreenService.GiveUserInformation().username;
            _profileScreen.FirstName = _profileScreenService.GiveUserInformation().firstname;
            _profileScreen.LastName = _profileScreenService.GiveUserInformation().lastname;
            _profileScreen.Email = _profileScreenService.GiveUserInformation().email;
            _profileScreen.Gender = _profileScreenService.GiveUserInformation().gender;
            _profileScreen.Age = _profileScreenService.GiveUserInformation().age;
            _profileScreen.Picture = _profileScreenService.GiveUserInformation().picture;
            _profileScreen.watchList = _profileScreenService.GiveWatchList(_profileScreen.id);
        }

        /// <summary>
        /// This method update the dictionary with movies in the form. This method is used in specific situation!
        /// </summary>
        /// <param name="id"></param>
        public void UpdateWatchListWhenMovieAdded(int id)
        {
            this.GetUserInformation(id);
            _profileScreen.watchList = _profileScreenService.GiveWatchList(_profileScreen.id);
        }

        

        /// <summary>
        /// This method changes the profile picture of the user.
        /// </summary>
        /// <param name="profilePic"></param>
        public void ChangeProfilePicture(byte[] profilePic)
        {
            try
            {
                _profileScreenService.UpdateProfilePicture(profilePic);
                _profileScreen.Picture = profilePic;
            }
            catch (Exception e)
            {
                Logger.Logger.WriteToLogFile(DateTime.Now.ToString()
                         + "\n" + e.ToString());
                _profileScreen.ErrorMessage("In the application sprang up an error! Please, check errors.txt file for more information!\n" + e.Message);
            }
        }

        /// <summary>
        /// This method removes movie from the watchList.
        /// </summary>
        /// <param name="movieId"></param>
        public void DeleteMovieFromwatchList(int movieId)
        {
            try
            {
                _profileScreenService.MovieRemover(movieId);
            }
            catch (Exception e)
            {
                Logger.Logger.WriteToLogFile(DateTime.Now.ToString()
                         + "\n" + e.ToString());
                _profileScreen.ErrorMessage("In the application sprang up an error! Please, check errors.txt file for more information!\n" + e.Message);
            }
        }
        
        /// <summary>
        /// This method gets the title for the movie with id.
        /// </summary>
        /// <param name="movieId"></param>
        /// <returns></returns>
        public string SetMovieTitelInView(int movieId)
        {
            return _profileScreenService.SetMovieTitleForMoviesInWatchList(movieId);
        }
    }
}
