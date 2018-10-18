namespace PoolSystem.Core
{
    using System;

    public class Factory<T>
    {
        Func<T> func;

        public Factory(Func<T> _func)
        {
            func = _func;
        }

        public T InstantiateObject()
        {
            return func();
        }
    }
}


