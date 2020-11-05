using System.Collections.Generic;
using System.Threading.Tasks;

namespace PostDomain
{
    public interface IGenericRepository<T> where T : class
    {
      Task<ServiceResponse<List<T>>> GetAll();
      Task<ServiceResponse<T>> GetPostById(int id);
      Task<ServiceResponse<List<T>>> AddPost(T data);
      Task<ServiceResponse<List<T>>> UpdatePost( T model, int id);
      Task<ServiceResponse<List<T>>> Delete(int id);
    }
}
