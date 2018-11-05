using Products.Subject;

namespace Products.Interfaces
{
    public interface ISubject
    {
        void Register(IObserver<Product> observer);
        void Unregister(IObserver<Product> observer);
        void NotifyAll();
    }
}
