namespace Core.Misc.GV
{
    public static class GlobalVariables
    {
        public static EFVariables EF { get; set; } = new();

        public class EFVariables
        {
            public readonly string DesignServer = "localhost";
            public readonly string DesignUser = "designer";
            public readonly string ManagerDatabaseFormat = "DEManager";
            public readonly string SetDatabaseFormat = "DESet_{0}";
        }
    }
}
