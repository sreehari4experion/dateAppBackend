using Dating.Models;
using Dating.View_Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dating.Repository
{
    public class UsersR : IUsers
    {
        private readonly DateContext _contextone;
        public UsersR(DateContext contextone)
        {
            _contextone = contextone;
        }

        public async Task<int> AddUser(Users user)
        {
            if (_contextone != null)
            {
                await _contextone.Users.AddAsync(user);
                await _contextone.SaveChangesAsync();
                return user.UserId;
            }
            return 0;
        }

      
        public async Task<List<UserView>> GetUsers()
        {
            
            if (_contextone != null)
            {
                return await (
                              from p in _contextone.Users
                              
                              select new UserView
                              {
                                  UserId = p.UserId,
                                  Name = p.Cname,
                                  Phone = p.Phone,
                                  Password=p.Password,
                                  Occupation = p.Occupation,
                                  Hobby = (from c in _contextone.Hobby
                                           join
                                           h in _contextone.Hobbylist
                                           on c.HobbyId equals h.HobbyId
                                           where h.UserId == p.UserId
                                           select c.Hobby1).ToList(),
                                  Food=(from m in _contextone.Food
                                              join 
                                              k in _contextone.Foodlist on m.FoodId equals k.FoodId
                                              where k.UserId == p.UserId
                                              select m.Food1).ToList(),
                                  MovieGenre = (from q in _contextone.Movie
                                                where q.MovId == p.MovId
                                                select q.MovieGenre).FirstOrDefault()



            }).ToListAsync();  //FirstorDefaultAsync();
            }
            return null;
        }

        public async Task UpdateUser(Users user)
        {
            if (_contextone != null)
            {
                _contextone.Entry(user).State = EntityState.Modified;
                _contextone.Users.Update(user);
                await _contextone.SaveChangesAsync();
            }
        }
        #region get user by id
        public async Task<UserView> GetUserbyId(int? id)
        {
            if (_contextone != null)
            {
                return await (
                              from p in _contextone.Users
                              where p.UserId==id

                              select new UserView
                              {
                                  UserId = p.UserId,
                                  Name = p.Cname,
                                  Phone = p.Phone,
                                  Password = p.Password,

                                  Occupation = p.Occupation,
                                  Hobby = (from c in _contextone.Hobby
                                           join
                                           h in _contextone.Hobbylist
                                           on c.HobbyId equals h.HobbyId
                                           where h.UserId == p.UserId
                                           select c.Hobby1).ToList(),
                                  Food = (from m in _contextone.Food
                                          join
                                          k in _contextone.Foodlist on m.FoodId equals k.FoodId
                                          where k.UserId == p.UserId
                                          select m.Food1).ToList(),
                                  MovieGenre = (from q in _contextone.Movie
                                                where q.MovId == p.MovId
                                                select q.MovieGenre).FirstOrDefault()



                              }).FirstOrDefaultAsync();  //FirstorDefaultAsync();
            }
            return null;
            //throw new NotImplementedException();
        }
        #endregion

        //delete a category
        #region delete User
        public async Task<int> DeleteUser(int? id)
        {
            // declare result
            int result = 0;
            if (_contextone != null)
            {
                var item = await _contextone.Users.FirstOrDefaultAsync(u => u.UserId == id);
                if (item != null)
                {
                    // perform delete
                    _contextone.Users.Remove(item);
                    result = await _contextone.SaveChangesAsync(); // commit 
                    //return succcess;
                    result = 1;

                }
                return result;
            }
            return result;

            //throw new NotImplementedException();
        }
        #endregion


        //get user by userid and password
        public async Task<UserModel> GetUserbyNameandPassword(string user, string pass)
        {
            if (_contextone != null)
            {
                return await (from p in _contextone.Users
                              
                              where p.Cname == user && p.Password == pass
                              select new UserModel
                              {
                                  UserName=p.Cname,
                                  Password=p.Password



                              }).FirstOrDefaultAsync();
            }
            return null;
        }

        public async Task<HobbyView> GetMostLikedHobby()
        {
            if(_contextone != null)
            {
                return await (from h in _contextone.Hobby
                              select new HobbyView
                              {
                                  HobbyId = (from p in _contextone.Users
                                             join hl in _contextone.Hobbylist on p.UserId equals hl.UserId
                                             join hb in _contextone.Hobby on hl.HobbyId equals hb.HobbyId
                                             group hb.HobbyId by hb.HobbyId into grp
                                             orderby grp.Count() descending
                                             select grp.Key).FirstOrDefault(),
                                  HobbyName = (from p in _contextone.Users
                                               join hl in _contextone.Hobbylist on p.UserId equals hl.UserId
                                               join hb in _contextone.Hobby on hl.HobbyId equals hb.HobbyId
                                               group hb.Hobby1 by hb.Hobby1 into grp
                                               orderby grp.Count() descending
                                               select grp.Key).FirstOrDefault()
                              }
                              ).FirstOrDefaultAsync();
            }
            return null;
        }

    }
}
