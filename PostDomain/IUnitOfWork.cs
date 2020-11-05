using System;
using PostStore.PostDomain.PostsAggregate;

namespace PostDomain
{
    public interface IUnitOfWork : IDisposable
    {
        IPostsRepository Posts { get; }       
        int Complete();
    }
}
