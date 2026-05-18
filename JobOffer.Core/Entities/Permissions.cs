
using System.Reflection;

namespace JobOffer.Core.Entities
{
    public static class Permissions
    {
        public static class Categories
        {
            public const string View = "Permissions.Categories.View";
            public const string Create = "Permissions.Categories.Create";
            public const string Update = "Permissions.Categories.Update";
            public const string Delete = "Permissions.Categories.Delete";
        }


        public static class Cities
        {
            public const string View = "Permissions.Cities.View";
            public const string Create = "Permissions.Cities.Create";
            public const string Update = "Permissions.Cities.Update";
            public const string Delete = "Permissions.Cities.Delete";
        }


        public static class Countries
        {
            public const string View = "Permissions.Countries.View";
            public const string Create = "Permissions.Countries.Create";
            public const string Update = "Permissions.Countries.Update";
            public const string Delete = "Permissions.Countries.Delete";
        }


        public static class Typess
        {
            public const string View = "Permissions.Typess.View";
            public const string Create = "Permissions.Typess.Create";
            public const string Update = "Permissions.Typess.Update";
            public const string Delete = "Permissions.Typess.Delete";
        }


        public static class User
        {
            public const string View = "Permissions.User.View";
            public const string Create = "Permissions.User.Create";
            public const string Update = "Permissions.User.Update";
            public const string Delete = "Permissions.User.Delete";
        }


        public static List<string?> GetAllPermissions()
        {
            return typeof(Permissions)
                .GetNestedTypes()
                .SelectMany(c => c.GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.FlattenHierarchy))
                .Select(f => f.GetValue(null).ToString())
                .ToList();
        }
    }
}
