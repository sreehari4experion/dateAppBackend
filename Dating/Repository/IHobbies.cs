﻿using Dating.Models;
using Dating.View_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dating.Repository
{
    public interface IHobbies
    {
        Task<List<HobbyView>> GetAllHobbies();
        // Add Users
        //Task<int> AddHobby(Hobby hobby);
        // Update user
        //Task UpdateHobby(Hobby hobby)/*;*/
    }
}
