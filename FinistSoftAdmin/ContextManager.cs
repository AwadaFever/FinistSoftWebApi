using FinistSoftWebApi;
using Microsoft.EntityFrameworkCore;

namespace FinistSoftAdmin
{
    public class ContextManager
    {
        public static ApplicationContext context;

        public static void FillContext()
        {
            DbContextOptionsBuilder<ApplicationContext> optionsBuilder = new DbContextOptionsBuilder<ApplicationContext>();
            optionsBuilder.UseSqlite("Data Source=.\\..\\..\\..\\..\\FinistSoftWebApi\\Data\\FinistDb.db");
            context = new ApplicationContext(optionsBuilder.Options);
        }
    }
}
