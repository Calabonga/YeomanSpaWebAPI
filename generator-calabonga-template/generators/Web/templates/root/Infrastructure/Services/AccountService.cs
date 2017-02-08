using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Calabonga.OperationResults;
using YeomanTemplate.Web.Infrastructure.Helpers;
using YeomanTemplate.Web.Infrastructure.Models;
using ValidatedUser = YeomanTemplate.Models.Infrastructure.ValidatedUser;

namespace YeomanTemplate.Web.Infrastructure.Services {

    /// <summary>
    /// AccountService for managing log in and log off
    /// </summary>
    public class AccountService : IAccountService {

        /// <summary>
        /// Return true if user exists in the list of users.
        /// The data comes from mobile clients.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public Task<OperationResult<ValidatedUser>> AuthorizeUserAsync(LoginViewModel data) {
            var result = OperationResult.CreateResult<ValidatedUser>();
            if (data.Password == "p@ssword" && data.UserName.ToLowerInvariant() == "administrator") {
                result.Result = new ValidatedUser { UserName = data.UserName, Claims = ClaimsHelper.CreateClaims(data, GetOtherStaff()) };
                return Task.FromResult(result);
            }
            result.AddError($"Извините, {data.UserName} не существует в системе.");
            return Task.FromResult(result);
        }

        private IEnumerable<Claim> GetOtherStaff() {
            var userProfile = new UserProfile {
                Id = Guid.Parse("D798480B-CB45-4B14-A8E0-5D88FA05436A"),
                BirthDate = new DateTime(1921, 12, 31),
                FirstName = "Дормидонт",
                LastName = "Суходрищев",
                MiddleName = "Валерьевич",
                UserName = "Administrator"
            };

            var result = ClaimsHelper.CreateClaims(userProfile, new[] {
                     new Claim(ClaimTypes.Role,"Administrator"),
                     new Claim(ClaimTypes.Role,"Postman"),
                     new Claim(ClaimTypes.Role,"User"),
                     new Claim(ClaimTypes.Role,"Operator"),
                     new Claim(ClaimTypes.Role,"Manager")
                });
            return result;
        }

    }

    /// <summary>
    /// AccountService for managing log in and log off
    /// </summary>
    public interface IAccountService {
        Task<OperationResult<ValidatedUser>> AuthorizeUserAsync(LoginViewModel data);
    }
}
