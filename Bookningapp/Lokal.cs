using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookningapp
{
    public class Lokal
    {
        public string Namn { get; set; }
        public string Plats { get; set; }
        public bool Tillgänglighet { get; set; }

        public Lokal(string namn, string plats, bool tillgänglighet)
        {
            Namn = namn;
            Plats = plats;
            Tillgänglighet = tillgänglighet;
        }
        public virtual void VisaInfo()
        {


        }

    }


}
