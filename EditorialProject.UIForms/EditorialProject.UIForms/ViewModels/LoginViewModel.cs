namespace EditorialProject.UIForms.ViewModels
{
    using System.Windows.Input;
    public class LoginViewModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public ICommand LoginCommand { get; }
    }
}