namespace LoginRegistration.Models
{
    public class CombinedLoginAndRegistrationViewModel
    {
        public LoginViewModel Login {get;set;}
        public RegistrationViewModel Register {get;set;}
        public User _newUser;
        public CombinedLoginAndRegistrationViewModel(User newUser)
        {
            _newUser = newUser;
        }
    }
}