public interface IGameManager
{
    ManagerStatus status { get; }
    //Перечисление, которое нужно определить.
    void Startup(NetworkService service);
}
public enum ManagerStatus
{
    Shutdown,
    Initializing,
    Started
}
