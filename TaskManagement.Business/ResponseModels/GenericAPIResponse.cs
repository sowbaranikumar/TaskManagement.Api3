using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagement.Business.ResponseModels
{
    public class GenericAPIResponse<T>
    {
        public int StatusCode { get; set; }

        public string StatusMsg { get; set; } = null!;

        public ICollection<string> ErrorMsg { get; set; } = new List<string>();

        public T? Response { get; set; }
    }
}

