namespace PoolSystem.Core
{
    using System;

    public class PoolObj<T>
    {
        private T obj;
        public T GetObj
        {
            get
            {
                return obj;
            }
        }

        bool isActive;
        public bool IsActive
        {
            get
            {
                return isActive;
            }
        }

        private Action<PoolObj<T>> OnActive;
        private Action<PoolObj<T>> OnDisable;

        public PoolObj(T _obj, Action<PoolObj<T>> _OnActive, Action<PoolObj<T>> _OnDisable)
        {
            obj = _obj;
            OnActive = _OnActive;
            OnDisable = _OnDisable;
        }

        public PoolObj<T> Activate()
        {
            isActive = true;
            OnActive(this);
            return this;
        }
        public PoolObj<T> Deactivate()
        {
            isActive = false;
            OnDisable(this);
            return this;
        }
    }

}
