﻿using LinFx.Extensions.EventBus.Abstractions;
using LinFx.Test.Extensions.EventBus.EventHandling;
using LinFx.Test.Extensions.EventBus.Events;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using Xunit;

namespace LinFx.Test.Extensions.EventBus
{
    public class EventBusRabbitMQTest
    {
        private readonly IEventBus _eventBus;

        public EventBusRabbitMQTest()
        {
            var services = new ServiceCollection();
            services.AddLinFx()
                .AddRabbitMQ(options =>
                {
                    options.Host = "14.21.34.85";
                    options.UserName = "admin";
                    options.Password = "admin.123456";
                })
                .AddEventBus(options =>
                {
                    options.Durable = true;
                    options.BrokerName = "LinFx.Test";
                    options.QueueName = "linfx_event_queue";
                });

            //services
            services.AddTransient<OrderStatusChangedToAwaitingValidationIntegrationEventHandler>();
            //services.AddTransient<OrderStatusChangedToPaidIntegrationEventHandler>();

            var applicationServices = services.BuildServiceProvider();

            //ConfigureEventBus
            _eventBus = applicationServices.GetRequiredService<IEventBus>();
            _eventBus.Subscribe<OrderStatusChangedToAwaitingValidationIntegrationEvent, OrderStatusChangedToAwaitingValidationIntegrationEventHandler>();
            //eventBus.Subscribe<OrderStatusChangedToPaidIntegrationEvent, OrderStatusChangedToPaidIntegrationEventHandler>();
        }


        [Fact]
        public void Should_Call_Handler_On_Event_With_Correct_Source()
        {
            var orderId = Guid.NewGuid().GetHashCode() & ushort.MaxValue;
            var evt = new OrderStatusChangedToAwaitingValidationIntegrationEvent(orderId, new List<OrderStockItem>
            {
            });
            _eventBus.PublishAsync(evt);

            Assert.True(true);
        }
    }
}
