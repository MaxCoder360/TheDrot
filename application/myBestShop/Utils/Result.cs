using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myBestShop.Utils
{
    class Result<T>
    {
        public T data = default;
        public bool isError = false;
        public bool isLoading = false;

        public Result(T data, bool isError, bool isLoading)
        {
            this.data = data;
            this.isError = isError;
            this.isLoading = isLoading;
        }
       
        public Result() {}

        public Result<T> copy(T anotherData, bool isError, bool isLoading)
        {
            return new Result<T> { data = anotherData, isError = isError, isLoading = isLoading };
        }
    }
}
