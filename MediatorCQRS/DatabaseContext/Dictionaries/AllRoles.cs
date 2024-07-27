namespace Naqleen.Domain.Dictionaries
{
    public static class AllRoles
    {
        public static Dictionary<int, string> MainRoles = new Dictionary<int, string>
        {
             {1 ,"Admin"},
             {2 ,"Worker"},
             {3 ,"Region Supervisor"},
             {4 ,"Station Manager"},
             {5 ,"Super Admin"}
        };

        public static bool IsRoleExist(int roleId) => MainRoles.ContainsKey(roleId);

        public static string GetRole(int roleId)
        {
            if (MainRoles.TryGetValue(roleId, out string role))
                return role;
            else
                return null;
        }
    }
}
