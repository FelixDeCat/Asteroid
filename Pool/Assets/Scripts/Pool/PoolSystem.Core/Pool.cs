namespace PoolSystem.Core
{
    using System.Collections.Generic;
    using System;

    public class Pool<T>
    {
        int cant;

        List<PoolObj<T>> pool = new List<PoolObj<T>>();

        Factory<T> factory;
        Action<PoolObj<T>> OnActive;
        Action<PoolObj<T>> OnDisable;

        public Pool(Func<T> factory, Action<PoolObj<T>> OnActive, Action<PoolObj<T>> OnDisable, int cant = 10)
        {
            this.factory = new Factory<T>(factory);
            this.OnActive = OnActive;
            this.OnDisable = OnDisable;
            this.cant = cant;
        }

        PoolObj<T> CreateAndReturnLast()
        {
            //como es una sola lista ahora, no agregamos el doble, porque al final de la lista vamos
            //a tener "cant" + "cant * 2"
            //por eso lo multiplicamos luego
            //asi tenemos "cant" + "cant" y luego recien ahi lo multiplicamos
            //asi la proxima iteracion vamos a tener...
            // "cant_multiplicada" + "cant_multiplicada"
            for (int i = 0; i < cant; i++)
            {
                PoolObj<T> obj = new PoolObj<T>(factory.InstantiateObject(), OnActive, OnDisable);
                obj.Deactivate();
                pool.Add(obj);
            }
            cant = cant * 2;
            return pool[pool.Count - 1];
        }

        void Create()
        {

        }

        public PoolObj<T> GetObject()
        {
            return GetNext().Activate();
        }

        PoolObj<T> GetNext()
        {
            for (int i = pool.Count - 1; i > 0; i--)
                if (!pool[i].IsActive) return pool[i];
            return CreateAndReturnLast();
        }

        public void ReleaseObject(T obj)
        {
            for (int i = 0; i < pool.Count; i++)
            {
                if (pool[i].GetObj.Equals(obj))
                {
                    pool[i].Deactivate();
                    return;
                }
            }
        }
    }
}

