namespace VendingMachine.Display
{
    public  class MachineDisplay : IMachineDisplay
    {
        public void DisplayMessage(string message)
        {
            System.Console.WriteLine(message);
        }
    }
}