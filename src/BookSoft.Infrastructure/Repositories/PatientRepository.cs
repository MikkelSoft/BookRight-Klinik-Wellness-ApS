using System;
using System.Collections.Generic;
using System.Text;
using BookSoft.Domain.Entities;
using BookSoft.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace BookSoft.Infrastructure.Repositories
{
    public class PatientRepository
    {
        private readonly BookSoftDbContext _CTX;

        public PatientRepository(BookSoftDbContext CTX)
        {
            _CTX = CTX;
        }


    }
}
