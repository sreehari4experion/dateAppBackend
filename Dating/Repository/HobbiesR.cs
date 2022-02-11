using Dating.Models;
using Dating.View_Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dating.Repository
{
    public class HobbiesR : IHobbies
    {
        private readonly DateContext dating;
        public HobbiesR(DateContext contextone)
        {
            dating = contextone;
        }
        //public async Task<int> AddHobby(Hobby hobby)
        //{
        //    if (dating != null)
        //    {
        //        await dating.Hobby.AddAsync(hobby);
        //        await dating.SaveChangesAsync();
        //        return hobby.HobbyId;
        //    }
        //    return 0;
        //}

        public async Task<List<HobbyView>> GetAllHobbies()
        {
            if (dating != null)
            {
                return await (from p in dating.Hobby

                              select new HobbyView
                              {
                                  HobbyId = p.HobbyId,
                                  HobbyName = p.Hobby1
                              }
                              ).ToListAsync();
            }
            return null;
        }

        //public async Task UpdateHobby(Hobby hobby)
        //{
        //    if (dating != null)
        //    {
        //        dating.Entry(hobby).State = EntityState.Modified;
        //        dating.Hobby.Update(hobby);
        //        await dating.SaveChangesAsync();
        //    }
        //}
    }
}
