﻿using IdentityText.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace IdentityText.Repository.IRepository
{
    public interface IClassGroupRepository : IRepository<ClassGroup>
    {

        Task<IEnumerable<SelectListItem>> SelectListClassGroupAsync();
        Task<int> CountAsync();

    }
    
}
