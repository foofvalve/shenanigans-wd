using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jetmax.Testing.Gui.Pages
{
    public class Login
    {
        public static string CreateAccountLink = "//a[text()='Create an account']";
        public static string EmailField = "[placeholder='Email']";
        public static string PasswordField = "[placeholder='Password']";
        public static string ConfirmPasswordField = "[placeholder='Confirm Password']";
        public static string LogInButton = "#submit";
    }
}
