using Common.DataAccess.EFCore.Repositories;
using Common.Entities;
using Common.Services.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Common.DataAccess.EFCore
{
    public class RespondRepository: Repository<Respond>, IRespondRepository
    {
        private readonly DataContext Context;
        public RespondRepository(DataContext context) : base(context)
        {
            Context = context;
        }
    }
}
