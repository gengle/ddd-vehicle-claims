namespace Domain
{
    public interface IAggregateRoot<out T>
    {
        T Id { get; }
    }
}