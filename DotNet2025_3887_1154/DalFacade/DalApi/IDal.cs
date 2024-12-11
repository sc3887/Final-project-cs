using System;

namespace DalApi
{
    public interface IDal
    {
        public IClient Client { get; }
        public IProducts Products { get; }
        public ISale Sale { get; }
    }
}