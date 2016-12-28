namespace Golf.Model.Interfaces
{
    public interface IEntity<T>
    {
        T Id { get; set; }
    }
}
