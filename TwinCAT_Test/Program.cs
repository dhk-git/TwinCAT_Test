using TwinCAT.Ads;

namespace TwinCAT_Test
{
    class Program
    {
        static void Main(string[] args)
        {
            TwinCatDriver twinCatDriver = new TwinCatDriver("127.0.0.1.1.1", 851);
            twinCatDriver.Connect();
            for (int i = 0; i < 5; i++)
            {
                twinCatDriver.Read();
                Thread.Sleep(1000);
            }
            twinCatDriver.DisConnect();
        }
    }

    public class TwinCatDriver
    {
        private AdsClient _adsClient;
        private string _ip;
        private int _port;

        public TwinCatDriver(string ip, int port)
        {
            _ip = ip;
            _port = port;
        }

        public void DisConnect()
        {
            _adsClient.Close();
        }

        public void Connect()
        {
            try
            {
                _adsClient = new AdsClient();
                _adsClient.Connect(_ip, _port);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void Read()
        {
            string[] tags = { "GVL.sn1", "GVL.sn2", "GVL.sn3", "GVL.sn4", "GVL.sn5", "GVL.sn6", "GVL.sn7", "GVL.sn8" };
            try
            {
                foreach (var tag in tags)
                {
                    var value = _adsClient.ReadValue("GVL.sn1", typeof(double));
                    Console.WriteLine($"{tag} : {value.ToString()}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

    }

}


