namespace Jaunts.Portal.Web.Client.Models.IdentityViews
{
    public class ResetPasswordView
    {
        public string Token { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string Email { get; set; }
    }
}
