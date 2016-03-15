Select Users.Username, users.IsApproved, Roles.RoleName
from Users, RoleUsers, Roles
where Users.UserId = RoleUsers.User_UserId and Roles.RoleId = RoleUsers.Role_RoleId;