using PostDomain.PostsAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace PostStore.PostRepo
{
    public class PostStoreDbContext : DbContext
    {
    	public DbSet<Post> Posts { get; set; }

        public PostStoreDbContext(DbContextOptions<PostStoreDbContext> options) : base(options) 
        {
        	
        }       
              
     }
}