namespace Notes.Persistance
{
    public class DbInitializer
    {
        public static void Initializer (NotesDBContext context)
        {
            context.Database.EnsureCreated ();
        }
    }
}
