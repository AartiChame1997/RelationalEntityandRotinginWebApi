using RelationalEntityandRotinginWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RelationalEntityandRotinginWebApi.Infrastructure
{
    public interface IPost
    {
        IEnumerable<Category> GetCategories();

       IEnumerable<PostViewModel> GetPosts();

        Task<PostViewModel> GetPost(int? postId);

        Task<int> AddPost(Post post);

        Task<int> UpdatePost(Post post);

        int DeletePost(int id);

        int SignupEmp(EmployeeRegistration employeeRegistration);



    }
}
