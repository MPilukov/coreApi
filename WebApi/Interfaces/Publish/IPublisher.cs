﻿namespace WebApi.Interfaces.Publish
{
    public interface IPublisher
    {
        void Publish<T>(T message) where T : class;
    }
}
