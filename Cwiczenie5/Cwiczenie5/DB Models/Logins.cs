using System;
using System.Collections.Generic;

namespace Cwiczenie5
{
    public partial class Logins
    {
        public string IndexNumber { get; set; }
        public string Password { get; set; }
        public string Salt { get; set; }
        public string RefreshToken { get; set; }

        public virtual Student IndexNumberNavigation { get; set; }
    }
}
