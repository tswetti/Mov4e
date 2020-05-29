using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mov4e.View.ProfileScreenView;

namespace Mov4eTests.PresenterTests.ProfileScreenPresenterSettingsTests
{
    class MockedDummyProfileScreenView:IProfileScreen
    {
        public int id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }
        public byte[] Picture { get; set; }
        public string UserName { get; set; }
        public Dictionary<int, byte[]> watchList { get; set; }

        public void ErrorMessage(string msg)
        {
            //works
        }

        public void ShowForm()
        {
            
        }

        public void UpdateBirthYear()
        {
            
        }

        public void UpdateEmail()
        {
          
        }

        public void UpdateFirstNmae()
        {
            
        }

        public void UpdateGender()
        {
            
        }

        public void UpdateLastName()
        {
           
        }


        public void UpdateUserName()
        {
            
        }

        public void Visible(bool isVisible)
        {
            //works
        }
    }
}
