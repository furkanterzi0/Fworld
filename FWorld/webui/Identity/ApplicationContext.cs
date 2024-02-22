using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
// tools olarak efc.identity design ve sqlserver
namespace webui.Identity;

public class ApplicationContext: IdentityDbContext<User>
{
    public ApplicationContext(DbContextOptions<ApplicationContext>options) : base(options)
    {
        
    }

}
