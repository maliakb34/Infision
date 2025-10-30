using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Infision.Configure
{
    public class HubUser
    {
        public int UserID { get; set; }
        public int CompanyID { get; set; }
        public string ConnectionID { get; set; }
    }

    public class AppSettings
    {
        public Kafka Kafka { get; set; }
        public NetworkSettings NetworkSetting { get; set; }
        public string DBSqlConnection { get; set; }
        public string DBRedisConnection { get; set; }
        public int DBRedisDataBase { get; set; }
        public string SignalRURI { get; set; }
        public string StoragePath { get; set; }
        public string BaseDomain { get; set; }
        public string CompanyName { get; set; }
        public ProxyServer ProxyServer { get; set; }
        
        public List<HubUser> HubUsers { get; set; }


    }



    public class ProxyServer
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Url { get; set; }
    }
    public class Kafka
    {
        public string Bootstrap { get; set; }
        public string TopicRaw { get; set; }
        public string Folder { get; set; }
    }
    public class Root
    {
        public AppSettings AppSettings { get; set; }


    }
    public static class RootSetting
    {
        public static Root Roots { get; set; }


    }

    public sealed record NetworkSettings
    {
        public string HttpUrl { get; set; } = "http://0.0.0.0:5000";
        public int TcpPort { get; set; } = 26801;
        public int UdpListenPort { get; set; } = 26800;
        public string ServerIp { get; set; } = "192.168.1.100";

        public int UdpBroadcastIntervalMs { get; set; } = 2000;
    }



}