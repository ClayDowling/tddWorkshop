namespace VendingMachine
{
    public class CoinAccepter
    {
        public Gpio Coin1; 
        public Gpio Coin2; 
        public Gpio Coin3; 
        public Gpio Coin4; 
        
        public void Setup()
        {
            Coin1 = new Gpio(13);
            Coin2 = new Gpio(14);
            Coin3 = new Gpio(15);
            Coin4 = new Gpio(16);
        }
        
        public void Loop()
        {
            
        }
    }
}