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
            var dbManager = DatabaseManager.instance;
            if (BUILD_CONFIG == ConfigType.DEBUG_CONFIG) {
                throw new NotImplementedException();
            } else
            {
                return AdminWebService.getInstance(dbManager);
            }
        }

        public static UserWebService createUserWebService(WebServiceConfig config)
        {
            if (BUILD_CONFIG == ConfigType.DEBUG_CONFIG)
            {
                throw new NotImplementedException();
            }
            else
            {
                return UserWebService.getInstance(config);
            }
        }

        public static IRepository createRepository(RepositoryConfig config)
        {
            if (config == null)
            {
                throw new ArgumentException("Provided repository config is null");
            }

            var webServiceConfig = createWebConfig(BUILD_CONFIG);
            var dbManager = DatabaseManager.instance;
            if ((config.type & (int)UserType.USER) == (int)UserType.USER)
            {
                var userWebService = createUserWebService(webServiceConfig);
                return new UserRepository(userWebService, dbManager);
            } else
            {
                var adminWebService = createAdminWebService(webServiceConfig);
                return new AdminRepository(adminWebService, dbManager);
            }
        }
    }
}
