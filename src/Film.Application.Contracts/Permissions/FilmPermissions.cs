namespace Film.Permissions;

public static class FilmPermissions
{
    public const string GroupName = "Film";

    //paginas 
    public const string Paginas = "Paginas";

    // secciones
    public static class Movie
    {
        public const string Default = GroupName + ".Movie";
        public const string Ver = Default + ".Ver";
        public const string Update = Default + ".Update";
        public const string Create = Default + ".Create";
        public const string Delete = Default + ".Delete";
    }
}
