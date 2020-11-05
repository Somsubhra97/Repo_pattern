using System.Collections.Generic;
using PostDomain.PostsAggregate;
using System.Threading.Tasks;
using System;

namespace PostRepo
{
public class MockPost : IPostsRepository
    {
   
    private readonly DataContext _context;
    public MockPost(DataContext dbcontext)
    {  
         _context=dbcontext;

    }
 
    
    public async Task<ServiceResponse<List<Post>>> GetterDB(){
        ServiceResponse<List<Post>> ob=new ServiceResponse<List<Post>>();
        List<Post> db=new List<Post>();
        db=await _context.Posts.ToListAsync();
        ob.Data=db;
        return ob;
    } 


    public async Task<ServiceResponse<Post>> GetPostByIdDB(int id){
        ServiceResponse<Post> ob=new ServiceResponse<Post>();        
        Post x=await _context.Posts.FirstOrDefaultAsync(i=>i.id==id);
        ob.Data= x;
        return ob;
    }



    public async Task<ServiceResponse<List<Post>>> CreatePostDB(Post data){
        ServiceResponse<List<Post>> ob=new ServiceResponse<List<Post>>();
        
        await _context.Commands.AddAsync(cmd);
        await _context.SaveChanges();

        ob.Data =await _context.Posts.ToListAsync();
        return ob;

    }


    
    public async Task<ServiceResponse<Post>> UpdatePostDB(Post data,int id){
       ServiceResponse<Post> ob=new ServiceResponse<Post>();

       try{
        Command obj=await _context.Posts.FirstOrDefaultAsync(i=>i.id==id);
        obj.title=data.title;
        obj.content=data.content;
        _context.Posts.Update(obj);
        await _context.SaveChanges();

        ob.Data = obj;
       }
       catch(Exception e){
        ob.Message=e.Message;
        ob.Success=false;
       }
       return ob;
   }



    public async Task<ServiceResponse<List<Post>>> DeleteDB(int id){
        ServiceResponse<Post> ob=new ServiceResponse<Post>();
        try{
            Command x=await _context.Commands.FirstAsync(i=>i.id==id);
            _context.Posts.Remove(x);

            ob.Data =await _context.Posts.ToListAsync();
        }
        catch(Exception e){
            ob.Message=e.Message;
            ob.Success=false;
        }
        return ob;
    }

   }
}
  
    