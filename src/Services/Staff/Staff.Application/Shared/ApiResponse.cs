using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Staff.Application.Shared
{
    public class ApiResponse<T>
    {
        public int StatusCode { get; set; }
        public string Url { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }
        public IDictionary<string, string[]> ValidationErrors { get; set; }
    }
}
