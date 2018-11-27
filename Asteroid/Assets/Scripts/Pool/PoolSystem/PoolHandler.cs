namespace PoolSystem
{
    using PoolSystem.Core;

    public abstract class PoolHandler<T> where T : IPooleable<T>
    {
        protected Pool<T> pool;
        public PoolHandler(int cant = 10)
        {
            pool = new Pool<T>(Build, OnActive, OnDisable, cant);
        }
        protected abstract T Build();

        private void OnDisable(PoolObj<T> obj)
        {
            obj.GetObj.Deactivate();
        }
        private void OnActive(PoolObj<T> obj)
        {
            obj.GetObj.Activate();
        }
        protected virtual T GetObj() {
            return pool.GetObject().GetObj;
        }
        protected void Release(T obj) {
            pool.ReleaseObject(obj);
        }
    }
}

