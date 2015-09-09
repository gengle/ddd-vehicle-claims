namespace Domain.Shared
{
    public interface IAggregateRoot<out T>
    {
        T Id { get; }
    }
}