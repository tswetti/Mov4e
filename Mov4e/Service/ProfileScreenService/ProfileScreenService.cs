using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mov4e.Repository.ProfileScreenRepository;
using static Mov4e.Hash;
using static Mov4e.Validation.ValidateProfile;
using Mov4e.Exceptions;
using Mov4e.Model;


namespace Mov4e.Service.ProfileScreenService
{
     public class ProfileScreenService : IProfileScreenService
    {
        private IProfileScreenRepository _profileScreenRepository;
        private User CurrentUser = new User();
        private UserInfo CurrentUserInfo = new UserInfo();

        public ProfileScreenService()
        {
            _profileScreenRepository = new ProfileScreenRepository();
        }

        //for tests
        public ProfileScreenService(IProfileScreenRepository profileScreenRepository)
        {
            _profileScreenRepository = profileScreenRepository;
        }

        //Stores information about current user in models from db context
        public void UserAndUserInfoFromDBAndStoreitInModels(int id)
        {
            CurrentUser= _profileScreenRepository.GetUserFromDB(id);
            CurrentUserInfo= _profileScreenRepository.GetDataForThisUser(id);
        }

        //Returns all information for the user
        public (string username, string firstname, string lastname, string email, string gender, int age, byte[] picture) GiveUserInformation()
        {
           return (CurrentUser.userName, CurrentUserInfo.firstName,
                   CurrentUserInfo.lastName, CurrentUserInfo.email, 
                   CurrentUserInfo.gender, 
                   CurrentUserInfo.age, CurrentUserInfo.picture);
        }
       
        public void UpdateProfilePicture(byte[] profilePic)
        {
            try
            {
                isProfilePictureOK(profilePic);
                _profileScreenRepository.ChangeProfilePicture(CurrentUser.id, profilePic);
                CurrentUserInfo.picture = profilePic;
            }
            catch (IncorrectUserDataException)
            {
                throw;
            }
        }


        //This method returns Id of the movie and its picture from watchlist of current user
        public Dictionary<int, byte[]> GiveWatchList(int id)
        {
            return _profileScreenRepository.GetUserWatchlist(id);
        }

        //Sets Movie Title For Current Movie That is Loading in WatchList
        public string SetMovieTitleForMoviesInWatchList(int movieId)
        {
            return _profileScreenRepository.GetMovieTitle(movieId);
        }

        //This method calls method from Repo that removes movie from current user watchlist
        public void MovieRemover( int movieId)
        {
            try
            {
                isMovieSelected(movieId);
                _profileScreenRepository.RemoveFromWatchList(CurrentUser.id, movieId);
            }
            catch(IncorrectUserDataException)
            {
                throw;
            }
        }

        
    }
}
