namespace Core
{
    public interface IAggregateRoot<out T>
    {
        T Id { get; }
    }
}