namespace PoolSystem
{
    using PoolSystem.Core;

    public abstract class PoolHandler<T> where T : IPooleable<T>
    {
        Pool<T> pool;
        public PoolHandler(int cant = 10)
        {
            pool = new Pool<T>(Build, OnActive, OnDisable, cant);
        }
        protected abstract T Build();
        private void OnDisable(PoolObj<T> obj)
        {
            obj.GetObj.Activate();
        }
        private void OnActive(PoolObj<T> obj)
        {
            obj.GetObj.Deactivate();
        }
        public T GetObj()
        {
            return pool.GetObject().GetObj;
        }
    }
}

