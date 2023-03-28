using myBestShop.Domain.WebService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using myBestShop.DependencyBuilders;

namespace myBestShop.Domain.Repository
{
    class AdminMainRepository
    {
        private AdminWebService webService;
        public AdminMainRepository()
        {
            webService = DependencyBuilders.DomainModule.
        }
    }
}
