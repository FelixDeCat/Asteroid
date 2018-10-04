namespace PoolSystem
{
    public interface IPooleable<T>
    {
        void Activate();
        void Deactivate();
    }
}
