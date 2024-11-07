using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookningapp
{
    internal class Sal : Lokal
    {
        public bool HarProjektor { get; set; }
        
        public Sal(string namn, int kapacitet, bool harProjektor) : base(namn, kapacitet)
        {
            HarProjektor = harProjektor;
        }
        public override void VisaInfo()
        {
            base.VisaInfo();
            Console.WriteLine($"Projektor: {(HarProjektor ? "Ja" : "Nej")}");
        }
    }
}
