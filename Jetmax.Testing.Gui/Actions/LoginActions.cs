using Jetmax.Testing.Gui.Core;
using Jetmax.Testing.Gui.Pages;

namespace Jetmax.Testing.Gui.Actions
{
    class LoginActions : AutotestContext
    {
        public static void CreateAccount(TestData data)
        {
            Wd.Get(Login.CreateAccountLink).PerformClick();
            Wd.Get(Login.EmailField).SetText(data.Find("email"));
            Wd.Get(Login.PasswordField).SetText(data.Find("password"));
            Wd.Get(Login.ConfirmPasswordField).SetText(data.Find("password"));
            Wd.Get(Login.LogInButton).PerformClick();
        }
    }
}
