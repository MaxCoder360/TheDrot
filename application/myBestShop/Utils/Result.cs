using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myBestShop.Utils
{
    public class Result<T>
    {
        public T data = default;
        public Exception exception = null;
        public bool isLoading = false;

        public bool isError
        {
            get { return exception != null; }
            private set { }
        }

        public Result(T data, Exception exception, bool isLoading)
        {
            this.data = data;
            this.exception = exception;
            this.isLoading = isLoading;
        }
       
        public Result() {}

        public Result<T> copy(T anotherData, Exception exception, bool isLoading)
        {
            return new Result<T> { data = anotherData, exception = exception, isLoading = isLoading };
        }
    }
}
