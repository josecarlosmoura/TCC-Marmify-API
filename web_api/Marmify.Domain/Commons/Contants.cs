using System;
using System.Collections.Generic;
using System.Text;

namespace Marmify.Domain.Commons
{
    public static class ConstProfiles
    {
        public const string Administrator = "Administrator";
        public const string Establishment = "Establishment";
        public const string User = "User";

        public static IEnumerable<string> GetListConstProfiles()
        {
            List<string> list = new List<string>();

            list.Add(Administrator);
            list.Add(Establishment);
            list.Add(User);

            return list;
        }
    }

}