namespace <%= projectName %>.Web.Infrastructure.Models {
    /// <summary>
    /// Login view model for custom validation
    /// </summary>
    public class LoginViewModel {

        public string Password { get; set; }

        public string UserName { get; set; }
    }
}
