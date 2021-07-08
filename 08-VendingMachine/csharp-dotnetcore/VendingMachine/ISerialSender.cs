using System.Net.Sockets;

namespace VendingMachine
{
    public interface ISerialSender
    {
        void Send(string message);
    }
}