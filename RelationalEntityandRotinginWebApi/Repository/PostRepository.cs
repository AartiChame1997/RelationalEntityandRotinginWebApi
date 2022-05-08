using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RelationalEntityandRotinginWebApi.Data;
using RelationalEntityandRotinginWebApi.Infrastructure;
using RelationalEntityandRotinginWebApi.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace RelationalEntityandRotinginWebApi.Repository
{
    public class PostRepository:IPost
    {
        private readonly DataContext _Context;
        private readonly IHostingEnvironment hostingEnvironment;
        public PostRepository(DataContext context, IHostingEnvironment _hostingEnvironment)
        {
            _Context = context;
            hostingEnvironment = _hostingEnvironment;
        }

        public async Task<int> AddPost(Post post)
        {
            if (_Context!=null)
            {
                _Context.post.Add(post);
                _Context.SaveChanges();
                return post.PostId;
            }
            return 0;
            
        }

        public int DeletePost(int id)
        {

            int result = 0;

            if (_Context!= null)
            {
                //Find the post for specific post id
                var post =  _Context.post.Where(x => x.PostId == id).FirstOrDefault();

                if (post != null)
                {
                    //Delete that post
                    _Context.post.Remove(post);

                    //Commit the transaction
                    result =_Context.SaveChanges();
                }
                return result;
            }

            return result;





        }

        public  IEnumerable<Category> GetCategories()
        {
            if (_Context != null)
            {
                return _Context.Category.ToList();
            }

            return null;

        }

        public Task<PostViewModel> GetPost(int? postId)
        {
            if (_Context != null)
            {
                return (from p in _Context.post
                       
                       where p.PostId == postId
                             select new PostViewModel
                             {
                                 PostId = p.PostId,
                                 Title = p.Title,
                                 Description = p.Description,
                                 CategoryId = p.CategoryId,
                                 CategoryName =p.Category.Name,
                                 CreatedDate = p.CreatedDate
                             }).FirstOrDefaultAsync();
            }

            return null;
        }

        public IEnumerable<PostViewModel> GetPosts()
        {
            
            if(_Context!=null)
            {
                var res = from p in _Context.post
                          from c in _Context.Category
                          where p.CategoryId == c.Id
                          select new PostViewModel
                          {
                              PostId = p.PostId,
                              Title = p.Title,
                              Description = p.Description,
                              CategoryId = (int)p.CategoryId,
                              CategoryName = c.Name,
                              CreatedDate = p.CreatedDate
                          };

                return res;
            }

            return null;
        }

        public Task<int> UpdatePost(Post post)
        {
            throw new NotImplementedException();
        }

        public int SignupEmp(EmployeeRegistration employeeRegistration)
        {
            int res = 0;
            employeeRegistration.Imagepath = SaveImage(employeeRegistration.ImageFile);
            _Context.tbl_registeremp.Add(employeeRegistration);
            res = _Context.SaveChanges();
            return res;
        }
        [NonAction]
        public string SaveImage(IFormFile file)
        {
            // string fName = file.FileName;
            //string path = Path.Combine(hostingEnvironment.ContentRootPath, "Images/" + file.FileName);
            //using (var stream = new FileStream(path, FileMode.Create))
            //{
            //    file.CopyTo(stream);
            //}
            //return file.FileName;

            string Imagename = new string(Path.GetFileNameWithoutExtension(file.FileName).Take(10).ToArray()).Replace(' ', '_');
            Imagename = Imagename + DateTime.Now.ToString("yymmsfff") + Path.GetExtension(file.FileName);
            var imgpath = Path.Combine(hostingEnvironment.ContentRootPath, "Images", Imagename);
            //using (var filesream = new FileStream(imgpath, FileMode.Create))
            //{
            //    file.CopyTo(filesream);
            //}
            return Imagename;

        }
    }
}
