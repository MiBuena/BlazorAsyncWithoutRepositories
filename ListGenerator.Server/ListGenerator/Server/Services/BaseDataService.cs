using AutoMapper;
using ListGenerator.Server.CommonResources;
using ListGeneratorListGenerator.Data.DB;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ListGenerator.Server.Services
{
    public abstract class BaseDataService
    {
        protected readonly ApplicationDbContext _db;
        protected readonly IMapper _mapper;
        protected readonly IStringLocalizer<Errors> _localizer;

        protected BaseDataService(ApplicationDbContext db,
            IMapper mapper,
            IStringLocalizer<Errors> localizer)
        {
            _db = db;
            _mapper = mapper;
            _localizer = localizer;
        }
    }
}
