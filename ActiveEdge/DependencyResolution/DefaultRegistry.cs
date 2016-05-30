// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DefaultRegistry.cs" company="Web Advanced">
// Copyright 2012 Web Advanced (www.webadvanced.com)
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
// http://www.apache.org/licenses/LICENSE-2.0

// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System.Data.Entity;
using ActiveEdge.Infrastructure.Mapping;
using AutoMapper;
using Domain.Context;
using Domain.Model;
using MediatR;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security.DataProtection;
using StructureMap;
using StructureMap.Graph;

namespace ActiveEdge.DependencyResolution
{
    public class DefaultRegistry : Registry
    {
        #region Constructors and Destructors

        public DefaultRegistry()
        {
            Scan(
                scan =>
                {
                    scan.TheCallingAssembly();
                    scan.AssemblyContainingType<IApplicationDbContext>();
                    scan.WithDefaultConventions();
                    scan.With(new ControllerConvention());
                    scan.ConnectImplementationsToTypesClosing(typeof(IRequestHandler<,>));
                    scan.ConnectImplementationsToTypesClosing(typeof(IAsyncRequestHandler<,>));
                    scan.ConnectImplementationsToTypesClosing(typeof(INotificationHandler<>));
                    scan.ConnectImplementationsToTypesClosing(typeof(IAsyncNotificationHandler<>));
                });
            For<MapperConfiguration>().Use(AutoMapperConfiguration.Create());
            For<IMapper>().Use(ctx => ctx.GetInstance<MapperConfiguration>().CreateMapper(ctx.GetInstance));
            For<SingleInstanceFactory>().Use<SingleInstanceFactory>(ctx => t => ctx.GetInstance(t));
            For<MultiInstanceFactory>().Use<MultiInstanceFactory>(ctx => t => ctx.GetAllInstances(t));


            For<IUserStore<ApplicationUser>>()
.Use<UserStore<ApplicationUser>>();

           For<DbContext>().Use(() => new ApplicationDbContext());
            //For<IUserStore<ApplicationUser>>().Use(new UserStore<ApplicationUser>(new ApplicationDbContext())).Singleton();

           // For<IUserStore<IdentityUser>>()
           //.Use(context => new UserStore<ApplicationUser>(context.GetInstance<IApplicationDbContext>()))
           //.
           //.Ctor<DbContext>()
           //.Is<IApplicationDbContext>();

            //For<UserManager<ApplicationUser>>()
            //    .Use(new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext())));
            For<IMediator>().Use<Mediator>();
        }

        #endregion
    }
}