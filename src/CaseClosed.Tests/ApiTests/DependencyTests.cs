﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CaseClosed.Api.DependencyResolution;
using MediatR;
using System.Collections.Generic;
using CaseClosed.Model.SmokeTests;
using CaseClosed.Api.Features.SmokeTests;
using StructureMap;
using System.Threading.Tasks;

namespace CaseClosed.Tests.ApiTests
{
    [TestClass]
    public class DependencyTests
    {
        private static IContainer _container;

        [ClassInitialize]
        public static void ClassInitialize(TestContext context)
        {
            _container = IoC.Initialize();
        }

        [TestMethod]
        public void CanResolveRequestHandler()
        {
            // Act
            var handler = _container.GetInstance<IAsyncRequestHandler<Index.Query, List<SmokeTest>>>();

            // Assert
            Assert.IsNotNull(handler);
        }

        [TestMethod]
        public async Task CanResolveMediator()
        {
            // ARrange
            var mediator = _container.GetInstance<IMediator>();

            // Act
            var result = await mediator.SendAsync(new Index.Query());

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
