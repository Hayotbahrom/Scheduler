using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautyScheduler.Service.Exceptions
{
    public class BeautySchedulerException : Exception
    {
        public int StatusCode {  get; set; }
        public BeautySchedulerException(int statusCode, string message) : base (message)
        {
            this.StatusCode = statusCode;
        }
    }
}
