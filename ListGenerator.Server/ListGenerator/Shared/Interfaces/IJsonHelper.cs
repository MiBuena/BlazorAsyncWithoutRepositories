using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace ListGenerator.Shared.Interfaces
{
    public interface IJsonHelper
    {
        string Serialize<T>(T model);

        T Deserialize<T>(string value);
    }
}
