﻿using DataAccess.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Security;
using Modelo.Models;



public class CodeFirstMembershipProvider : MembershipProvider
{

    #region Properties

    private const int TokenSizeInBytes = 16;

    public override string ApplicationName
    {
        get
        {
            return this.GetType().Assembly.GetName().Name.ToString();
        }
        set
        {
            this.ApplicationName = this.GetType().Assembly.GetName().Name.ToString();
        }
    }

    public override int MaxInvalidPasswordAttempts
    {
        get { return 5; }
    }

    public override int MinRequiredNonAlphanumericCharacters
    {
        get { return 0; }
    }

    public override int MinRequiredPasswordLength
    {
        get { return 6; }
    }

    public override int PasswordAttemptWindow
    {
        get { return 0; }
    }

    public override MembershipPasswordFormat PasswordFormat
    {
        get { return MembershipPasswordFormat.Hashed; }
    }

    public override string PasswordStrengthRegularExpression
    {
        get { return String.Empty; }
    }

    public override bool RequiresUniqueEmail
    {
        get { return true; }
    }

    #endregion

    #region Functions

    public override MembershipUser CreateUser(string username, string password, string email, string passwordQuestion, string passwordAnswer, bool isApproved, object providerUserKey, out MembershipCreateStatus status)
    {
        if (string.IsNullOrEmpty(username))
        {
            status = MembershipCreateStatus.InvalidUserName;
            return null;
        }
        if (string.IsNullOrEmpty(password))
        {
            status = MembershipCreateStatus.InvalidPassword;
            return null;
        }
        if (string.IsNullOrEmpty(email))
        {
            status = MembershipCreateStatus.InvalidEmail;
            return null;
        }


        using (Context Context = new Context())
        {
            if (Context.Users.Where(Usr => Usr.Username == username).Any())
            {
                status = MembershipCreateStatus.DuplicateUserName;
                return null;
            }

            if (Context.Users.Where(Usr => Usr.Email == email).Any())
            {
                status = MembershipCreateStatus.DuplicateEmail;
                return null;
            }

            User NewUser = new User
            {
                UserId = Guid.NewGuid(),
                Username = username,
                Password = password,
                IsApproved = isApproved,
                Email = email,
                CreateDate = DateTime.UtcNow,
                LastPasswordChangedDate = DateTime.UtcNow,
                PasswordFailuresSinceLastSuccess = 0,
                LastLoginDate = DateTime.UtcNow,
                LastActivityDate = DateTime.UtcNow,
                LastLockoutDate = DateTime.UtcNow,
                IsLockedOut = false,
                LastPasswordFailureDate = DateTime.UtcNow
            };

            Context.Users.Add(NewUser);
            Context.SaveChanges();
            status = MembershipCreateStatus.Success;
            return new MembershipUser(Membership.Provider.Name, NewUser.Username, NewUser.UserId, NewUser.Email, null, null, NewUser.IsApproved, NewUser.IsLockedOut, NewUser.CreateDate.Value, NewUser.LastLoginDate.Value, NewUser.LastActivityDate.Value, NewUser.LastPasswordChangedDate.Value, NewUser.LastLockoutDate.Value);
        }
    }

    public string CreateUserAndAccount(string userName, string password, bool requireConfirmation, IDictionary<string, object> values)
    {
        return CreateAccount(userName, password, requireConfirmation);
    }

    public override bool ValidateUser(string username, string password)
    {
        if (string.IsNullOrEmpty(username))
        {
            return false;
        }
        if (string.IsNullOrEmpty(password))
        {
            return false;
        }
        using (Context Context = new Context())
        {
            User User = null;
            User = Context.Users.SingleOrDefault(Usr => Usr.Username == username);
            if (User == null)
            {
                return false;
            }
            if (!User.IsApproved)
            {
                return false;
            }
            if (User.IsLockedOut)
            {
                return false;
            }
            String HashedPassword = User.Password;
            Boolean VerificationSucceeded = (HashedPassword != null) && (password == HashedPassword);
            if (VerificationSucceeded)
            {
                User.PasswordFailuresSinceLastSuccess = 0;
                User.LastLoginDate = DateTime.UtcNow;
                User.LastActivityDate = DateTime.UtcNow;
            }
            else
            {
                int Failures = User.PasswordFailuresSinceLastSuccess;
                if (Failures < MaxInvalidPasswordAttempts)
                {
                    User.PasswordFailuresSinceLastSuccess += 1;
                    User.LastPasswordFailureDate = DateTime.UtcNow;
                }
                else if (Failures >= MaxInvalidPasswordAttempts)
                {
                    User.LastPasswordFailureDate = DateTime.UtcNow;
                    User.LastLockoutDate = DateTime.UtcNow;
                    User.IsLockedOut = true;
                }
            }
            Context.SaveChanges();
            if (VerificationSucceeded)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }

    public override MembershipUser GetUser(string username, bool userIsOnline)
    {
        if (string.IsNullOrEmpty(username))
        {
            return null;
        }
        using (Context Context = new Context())
        {
            User User = null;
            User = Context.Users.FirstOrDefault(Usr => Usr.Username == username);
            if (User != null)
            {
                if (userIsOnline)
                {
                    User.LastActivityDate = DateTime.UtcNow;
                    Context.SaveChanges();
                }
                
                return new MembershipUser(Membership.Provider.Name, User.Username, User.UserId, User.Email, null, null, User.IsApproved, User.IsLockedOut, User.CreateDate.Value, User.LastLoginDate.Value, User.LastActivityDate.Value, User.LastPasswordChangedDate.Value, User.LastLockoutDate.Value);
            }
            else
            {
                return null;
            }
        }
    }

    public override MembershipUser GetUser(object providerUserKey, bool userIsOnline)
    {
        if (providerUserKey is Guid) { }
        else
        {
            return null;
        }

        using (Context Context = new Context())
        {
            User User = null;
            User = Context.Users.Find(providerUserKey);
            if (User != null)
            {
                if (userIsOnline)
                {
                    User.LastActivityDate = DateTime.UtcNow;
                    Context.SaveChanges();
                }
                return new MembershipUser(Membership.Provider.Name, User.Username, User.UserId, User.Email, null, null, User.IsApproved, User.IsLockedOut, User.CreateDate.Value, User.LastLoginDate.Value, User.LastActivityDate.Value, User.LastPasswordChangedDate.Value, User.LastLockoutDate.Value);
            }
            else
            {
                return null;
            }
        }
    }

    public override bool ChangePassword(string username, string oldPassword, string newPassword)
    {
        if (string.IsNullOrEmpty(username))
        {
            return false;
        }
        if (string.IsNullOrEmpty(oldPassword))
        {
            return false;
        }
        if (string.IsNullOrEmpty(newPassword))
        {
            return false;
        }
        using (Context Context = new Context())
        {
            User user = null;
            user = Context.Users.FirstOrDefault(Usr => Usr.Username == username);
            if (user == null)
            {
                return false;
            }

            string pass = user.Password;
            Boolean VerificationSucceeded = (pass != null) && user.Password == oldPassword;

            if (VerificationSucceeded)
            {
                user.PasswordFailuresSinceLastSuccess = 0;
            }
            else
            {
                int Failures = user.PasswordFailuresSinceLastSuccess;
                if (Failures < MaxInvalidPasswordAttempts)
                {
                    user.PasswordFailuresSinceLastSuccess += 1;
                    user.LastPasswordFailureDate = DateTime.UtcNow;
                }
                else if (Failures >= MaxInvalidPasswordAttempts)
                {
                    user.LastPasswordFailureDate = DateTime.UtcNow;
                    user.LastLockoutDate = DateTime.UtcNow;
                    user.IsLockedOut = true;
                }
                Context.SaveChanges();
                return false;
            }

            user.Password = newPassword;
            user.LastPasswordChangedDate = DateTime.UtcNow;
            Context.SaveChanges();
            return true;
        }
    }

    public override bool UnlockUser(string userName)
    {
        using (Context Context = new Context())
        {
            User User = null;
            User = Context.Users.FirstOrDefault(Usr => Usr.Username == userName);
            if (User != null)
            {
                User.IsLockedOut = false;
                User.PasswordFailuresSinceLastSuccess = 0;
                Context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
    }

    public override int GetNumberOfUsersOnline()
    {
        DateTime DateActive = DateTime.UtcNow.Subtract(TimeSpan.FromMinutes(Convert.ToDouble(Membership.UserIsOnlineTimeWindow)));
        using (Context Context = new Context())
        {
            return Context.Users.Where(Usr => Usr.LastActivityDate > DateActive).Count();
        }
    }

    public override bool DeleteUser(string username, bool deleteAllRelatedData)
    {
        if (string.IsNullOrEmpty(username))
        {
            return false;
        }
        using (Context Context = new Context())
        {
            User User = null;
            User = Context.Users.FirstOrDefault(Usr => Usr.Username == username);
            if (User != null)
            {
                Context.Users.Remove(User);
                Context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
    }

    public override string GetUserNameByEmail(string email)
    {
        using (Context Context = new Context())
        {
            User User = null;
            User = Context.Users.FirstOrDefault(Usr => Usr.Email == email);
            if (User != null)
            {
                return User.Username;
            }
            else
            {
                return string.Empty;
            }
        }
    }

    public override MembershipUserCollection FindUsersByEmail(string emailToMatch, int pageIndex, int pageSize, out int totalRecords)
    {
        MembershipUserCollection MembershipUsers = new MembershipUserCollection();
        using (Context Context = new Context())
        {
            totalRecords = Context.Users.Where(Usr => Usr.Email == emailToMatch).Count();
            IQueryable<User> Users = Context.Users.Where(Usr => Usr.Email == emailToMatch).OrderBy(Usrn => Usrn.Username).Skip(pageIndex * pageSize).Take(pageSize);
            foreach (User user in Users)
            {
                MembershipUsers.Add(new MembershipUser(Membership.Provider.Name, user.Username, user.UserId, user.Email, null, null, user.IsApproved, user.IsLockedOut, user.CreateDate.Value, user.LastLoginDate.Value, user.LastActivityDate.Value, user.LastPasswordChangedDate.Value, user.LastLockoutDate.Value));
            }
        }
        return MembershipUsers;
    }

    public override MembershipUserCollection FindUsersByName(string usernameToMatch, int pageIndex, int pageSize, out int totalRecords)
    {
        MembershipUserCollection MembershipUsers = new MembershipUserCollection();
        using (Context Context = new Context())
        {
            totalRecords = Context.Users.Where(Usr => Usr.Username == usernameToMatch).Count();
            IQueryable<User> Users = Context.Users.Where(Usr => Usr.Username == usernameToMatch).OrderBy(Usrn => Usrn.Username).Skip(pageIndex * pageSize).Take(pageSize);
            foreach (User user in Users)
            {
                MembershipUsers.Add(new MembershipUser(Membership.Provider.Name, user.Username, user.UserId, user.Email, null, null, user.IsApproved, user.IsLockedOut, user.CreateDate.Value, user.LastLoginDate.Value, user.LastActivityDate.Value, user.LastPasswordChangedDate.Value, user.LastLockoutDate.Value));
            }
        }
        return MembershipUsers;
    }

    public override MembershipUserCollection GetAllUsers(int pageIndex, int pageSize, out int totalRecords)
    {
        MembershipUserCollection MembershipUsers = new MembershipUserCollection();
        using (Context Context = new Context())
        {
            totalRecords = Context.Users.Count();
            IQueryable<User> Users = Context.Users.OrderBy(Usrn => Usrn.Username).Skip(pageIndex * pageSize).Take(pageSize);
            foreach (User user in Users)
            {
                MembershipUsers.Add(new MembershipUser(Membership.Provider.Name, user.Username, user.UserId, user.Email, null, null, user.IsApproved, user.IsLockedOut, user.CreateDate.Value, user.LastLoginDate.Value, user.LastActivityDate.Value, user.LastPasswordChangedDate.Value, user.LastLockoutDate.Value));
            }
        }
        return MembershipUsers;
    }

    public string CreateAccount(string userName, string password, bool requireConfirmationToken)
    {

        if (string.IsNullOrEmpty(userName))
        {
            throw new MembershipCreateUserException(MembershipCreateStatus.InvalidUserName);
        }

        if (string.IsNullOrEmpty(password))
        {
            throw new MembershipCreateUserException(MembershipCreateStatus.InvalidPassword);
        }


        using (Context Context = new Context())
        {
            if (Context.Users.Where(Usr => Usr.Username == userName).Any())
            {
                throw new MembershipCreateUserException(MembershipCreateStatus.DuplicateUserName);
            }

            string token = string.Empty;
            if (requireConfirmationToken)
            {
                token = GenerateToken();
            }

            User NewUser = new User
            {
                UserId = Guid.NewGuid(),
                Username = userName,
                Password = password,
                IsApproved = !requireConfirmationToken,
                Email = string.Empty,
                CreateDate = DateTime.UtcNow,
                LastPasswordChangedDate = DateTime.UtcNow,
                PasswordFailuresSinceLastSuccess = 0,
                LastLoginDate = DateTime.UtcNow,
                LastActivityDate = DateTime.UtcNow,
                LastLockoutDate = DateTime.UtcNow,
                IsLockedOut = false,
                LastPasswordFailureDate = DateTime.UtcNow,
                ConfirmationToken = token
            };
            Context.Configuration.LazyLoadingEnabled = false;
            Context.Configuration.ProxyCreationEnabled = false;
            //var rol = Context.Roles.Single(r => r.RoleName == "Administrador");
            Membership.CreateUser(NewUser.Username, NewUser.Password);
            Roles.AddUserToRole(NewUser.Username, "Administrador");

            //Context.Users.Add(NewUser);
            //Context.SaveChanges();
            return token;
        }

    }

    private static string GenerateToken()
    {
        using (var prng = new RNGCryptoServiceProvider())
        {
            return GenerateToken(prng);
        }
    }

    internal static string GenerateToken(RandomNumberGenerator generator)
    {
        byte[] tokenBytes = new byte[TokenSizeInBytes];
        generator.GetBytes(tokenBytes);
        return HttpServerUtility.UrlTokenEncode(tokenBytes);
    }

    #endregion

    #region Not Supported

    //CodeFirstMembershipProvider does not support password retrieval scenarios.
    public override bool EnablePasswordRetrieval
    {
        get { return false; }
    }
    public override string GetPassword(string username, string answer)
    {
        throw new NotSupportedException("Consider using methods from WebSecurity module.");
    }

    //CodeFirstMembershipProvider does not support password reset scenarios.
    public override bool EnablePasswordReset
    {
        get { return false; }
    }
    public override string ResetPassword(string username, string answer)
    {
        throw new NotSupportedException("Consider using methods from WebSecurity module.");
    }

    //CodeFirstMembershipProvider does not support question and answer scenarios.
    public override bool RequiresQuestionAndAnswer
    {
        get { return false; }
    }
    public override bool ChangePasswordQuestionAndAnswer(string username, string password, string newPasswordQuestion, string newPasswordAnswer)
    {
        throw new NotSupportedException("Consider using methods from WebSecurity module.");
    }

    //CodeFirstMembershipProvider does not support UpdateUser because this method is useless.
    public override void UpdateUser(MembershipUser user)
    {
        throw new NotSupportedException();
    }

    #endregion
}
