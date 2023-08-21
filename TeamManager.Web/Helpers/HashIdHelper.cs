using HashidsNet;

namespace TeamManager.Web.Helpers
{
    public static class HashIdHelper
    {
        private static string Salt = "ijyNMX3OOWiEo6hokHSm";

        public static string Encode(int id)
        {
            var hashids = new Hashids(Salt);
            var hash = hashids.Encode(id);

            return hash;
        }

        public static int Decode(string hash)
        {
            var hashids = new Hashids(Salt);
            var ids = hashids.Decode(hash);

            return ids[0];
        }
    }
}
