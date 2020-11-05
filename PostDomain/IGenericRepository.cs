using System.Collections.Generic;
using System.Threading.Tasks;

namespace PostDomain
{
    public interface IGenericRepository<T> where T : class
    {
      Task<ServiceResponse<List<Post>>> Getter();
      Task<ServiceResponse<Post>> GetPostById(int id);
      Task<ServiceResponse<List<Post>>> AddPost(Post data);
      Task<ServiceResponse<List<Post>>> UpdatePost( Post model, int id);
      Task<ServiceResponse<List<Post>>> Delete(int id);
    }
}
