using System.Net.Sockets;

namespace VendingMachine
{
    public interface ISerialReceiver
    {
        void Receive(string message);
    }
}