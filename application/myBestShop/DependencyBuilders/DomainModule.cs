﻿using myBestShop.Domain.Database;
using myBestShop.Domain.Repository;
using myBestShop.Domain.WebService;
using myBestShop.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static myBestShop.Utils.AppConfig;
using static myBestShop.Utils.UserTypeExt;

namespace myBestShop.DependencyBuilders
{
    public static class DomainModule
    {
        public static WebServiceConfig createWebConfig(ConfigType type)
        {
            return WebServiceConfig.createWebConfig(type);
        }

        public static RepositoryConfig createRepositoryConfig(ConfigType configType, UserType userType)
        {
            return RepositoryConfig.createConfig(configType, userType);
        }

        public static AdminWebService createAdminWebService(WebServiceConfig config)
        {
            return new AdminWebService(config.baseUrl);
        }

        public static IUserWebService createUserWebService(WebServiceConfig config)
        {
            if (AppConfig.BUILD_CONFIG == AppConfig.ConfigType.DEBUG_CONFIG)
            {
                return new UserWebServiceMock(config);
            } else
            {
                return new UserWebService(config);
            }
        }

        public static Domain.Repository.IRepository createRepository(RepositoryConfig config)
        {
            if (config == null)
            {
                throw new ArgumentException("Provided repository config is null");
            }

            var webServiceConfig = createWebConfig(BUILD_CONFIG);
            var userWebService = createUserWebService(webServiceConfig);
            var adminWebService = createAdminWebService(webServiceConfig);
            var dbManager = DatabaseManager.instance;
            if ((config.type & (int)UserType.USER) == 1)
            {
                return new UserRepository(userWebService);
            } else
            {
                return new AdminRepository(adminWebService, dbManager);
            }
        }
    }
}
