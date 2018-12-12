﻿using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace LinFx.Test
{
    public class LinFxTest
    {
        [Fact]
        public void Startup()
        {
            var services = new ServiceCollection();
            services.AddLinFx();
            var container = services.BuildServiceProvider();
        }
    }
}
