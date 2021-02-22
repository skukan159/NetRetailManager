using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataManager.Contracts
{
    public static class ApiRoutes
    {
        public const string Version = "v1";
        public const string Root = "api";

        public const string Base = Root + "/" + Version;

        public static class User
        {
            public const string GetAll = Base + "/user";
            public const string GetByNeighborhood = Base + "/moments/{neighborhoodId}";
            public const string Get = Base + "/moments/{momentId}";
            public const string Create = Base + "/moments";
            public const string Update = Base + "/moments/{momentId}";
            public const string Delete = Base + "/moments/{momentId}";
        }

        public static class Identity
        {
            public const string Login = Base + "/identity/login";
            public const string Register = Base + "/identity/register";
            public const string Refresh = Base + "/identity/refresh";
            public const string GetById = Base + "/identity/getUserById/{userId}";
            public const string GetUsers = Base + "/identity/users";
            public const string DeleteUser = Base + "/identity/deleteUser/{userId}";
            public const string GetRoles = Base + "/identity/roles";
            public const string GetUserRoles = Base + "/identity/userrole/{userId}";
            public const string SetUserRole = Base + "/identity/setuserrole";
        }
    }
}
