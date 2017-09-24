﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookMe.Domain.Concrete.Repository.Interfaces;
using BookMe.Domain.Entities;

namespace BookMe.Domain.Concrete.Repository {
    public class PhotoRepository : Repository<Photo>, IPhotoRepository{
        public PhotoRepository(DbContext dbContext) : base(dbContext){
        }

    }
}
