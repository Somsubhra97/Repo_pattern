using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

using PostDomain;
using PostDomain.PostsAggregate;

namespace PostAPI.Controllers
{

    [Route("api/posts")]
    [ApiController]
    public class PostsController : ControllerBase
    {
      
       private IUnitOfWork _unitOfWork;       
       public BooksController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]        
        public async Task<IActionResult> GetAll (){
           var ob=await _unitOfWork.Posts.GetterDB();
                    
             return Ok(ob);
        } 
       
        
        // GET api/commands/{id}        
        [HttpGet("{id}", Name="GetPostById")]
        public async Task<IActionResult> GetPostById(int id){
             ServiceResponse<Post> x=await  _unitOfWork.Posts.GetPostByIdDB(id);
            if(x.Success)
              return Ok(x);  
            return NotFound();                
   
        }  
       
 
   
        [HttpPost]
        public async Task<IActionResult> Add(Post cmd){
           ServiceResponse<Post> x=await  _unitOfWork.Posts.GetPostByIdDB(id);
                _unitOfWork.Posts.AddPostDB(cmd); 
                _unitOfWork.Complete();
                x.Success=true;
                x.Message="Stored Successfully";                    
                return Ok(x);            
            }
            


        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Post cmd,int id){       
            var ret=await  _unitOfWork.Posts.UpdatePostDB(cmd,id);        
            if(!ret.Success){
               return NotFound(ret);
             }      
            return Ok(ret);            
        } 

        [HttpDelete("{id}")]    
        public async Task<IActionResult> Delete(int id){
                ServiceResponse<List<Post>> response = await  _unitOfWork.Posts.DeleteDB(id);
                return Ok(response);
        }         
        
  }
}