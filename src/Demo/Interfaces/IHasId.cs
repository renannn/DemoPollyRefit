using System;

namespace Demo.Interfaces
{
    public interface IHasId<TType> where TType : struct
    {
        TType Id { get; }
    }
}
