using ListGenerator.Shared.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ListGenerator.Client.Services
{
    public interface ICultureService
    {
        Task<BaseResponse> ChangeCulture(string culture);
    }
}
