namespace Products.Interfaces
{
    public interface IObserver<in T>
    {
        void Update(T value);
    }
}
