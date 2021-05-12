namespace SuperSocket.SocketBase.Logging
{
    /// <summary>
    /// LogFactory Interface
    /// </summary>
    public interface ILogFactory
    {
        ILog GetLog(string name);
    }
}
