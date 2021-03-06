﻿using System;
using System.Collections.Generic;

namespace Whatever.Payments.Infrastructure
{
    public class Bus : IBus
    {
        private Dictionary<Type, List<Action<IMessage>>> handlers = new Dictionary<Type, List<Action<IMessage>>>();

        public void RegisterHandlerFor<T>(IHandlMessage<T> handler) where T : IMessage
        {
            if (!handlers.ContainsKey(typeof(T)))
            {
                handlers.Add(typeof(T), new List<Action<IMessage>>());
            }

            var handlersForType = handlers[typeof(T)];
            handlersForType.Add(x => handler.Handle((T)x));
        }

        public void Send(IMessage message)
        {
            var messageType = message.GetType();

            if (!handlers.ContainsKey(messageType))
            {
                throw new InvalidOperationException($"No handler registered for {messageType}");
            }

            var handlersToCall = handlers[messageType];
            foreach (var handler in handlersToCall)
            {
                handler.Invoke(message);
            }
        }
    }
}
