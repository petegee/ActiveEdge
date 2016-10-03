using System;
using System.Collections.Generic;
using Microsoft.AspNet.Identity;

namespace Shared.Authorization
{
    public class IdentityUser : IUser
    {
        public virtual string Id { get; set; }
        public virtual string UserName { get; set; }
        public virtual string PasswordHash { get; set; }
        public virtual string SecurityStamp { get; set; }
        public virtual string Email { get; set; }
        public virtual string PhoneNumber { get; set; }
        public virtual bool IsEmailConfirmed { get; set; }
        public virtual bool IsPhoneNumberConfirmed { get; set; }
        public virtual int AccessFailedCount { get; set; }
        public virtual bool LockoutEnabled { get; set; }
        public virtual DateTimeOffset LockoutEndDate { get; set; }
        public virtual bool TwoFactorAuthEnabled { get; set; }
        public virtual List<string> Roles { get; private set; }
        public virtual List<IdentityUserClaim> Claims { get; private set; }
        public virtual List<UserLoginInfo> Logins { get; private set; }

        public IdentityUser()
        {
            this.Claims = new List<IdentityUserClaim>();
            this.Roles = new List<string>();
            this.Logins = new List<UserLoginInfo>();
        }

        public IdentityUser(string userId, string userName)
            : this()
        {
            this.Id = userId;
            this.UserName = userName;
        }
    }
}