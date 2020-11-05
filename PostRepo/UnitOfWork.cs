using System;
using PostDomain;
using PostDomain.BooksAggregate;

namespace PostRepo
{
    public class UnitOfWork :IUnitOfWork
    {
        private readonly PostStoreDbContext _context;
        public IPostsRepository Posts { get; }
       

        public UnitOfWork(PostStoreDbContext postStoreDbContext,
            IPostsRepository postsRepository)
        {
            this._context = postStoreDbContext;            
            this.Post = postsRepository;            
        }
        public int Complete()
        {
            return _context.SaveChanges();
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
        }
    }
}
