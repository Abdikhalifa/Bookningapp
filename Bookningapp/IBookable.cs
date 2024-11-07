using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookningapp
{
    internal interface IBookable
    {
        bool Boka(DateTime startTid, DateTime slutTid);
        bool Avboka(DateTime startTid);
        bool ÄrTillgänglig(DateTime startTid, DateTime slutTid);
    }
}
