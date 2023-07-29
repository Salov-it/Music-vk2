

namespace Persistance.Base
{
    public class DbInit
    {
        public static void init(Context context)
        {
            context.Database.EnsureCreated();
        }
    }
}
