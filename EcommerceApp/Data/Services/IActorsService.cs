﻿using EcommerceApp.Models;

namespace EcommerceApp.Data.Services
{
    public interface IActorsService
    {
        Task<IEnumerable<Actor>> GetAll();
        Actor GetById(int id);
        void Add(Actor actor); //insert
        Actor Update(int id, Actor newActor);
        void Delete(int id);
    }
}
