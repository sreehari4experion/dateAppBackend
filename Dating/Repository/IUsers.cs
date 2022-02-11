using Dating.Models;
using Dating.View_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dating.Repository
{
    public interface IUsers
    {
        Task<List<UserView>> GetUsers();
        //Task<string> GetMostHobby();
         Task<int> AddUser(Users user);
        Task UpdateUser(Users user);
        //Task<UserView> GetUserbyId(int id);
        // Task<UserView> GetUserbyUsername(string username);

        // Task<UserView> GetUserbyPhone(long phone);
        Task<UserView> GetUserbyId(int? id);
        Task<int> DeleteUser(int? id);
        Task<UserModel> GetUserbyNameandPassword(string user, string pass);

        Task<HobbyView> GetMostLikedHobby();
    }
}
