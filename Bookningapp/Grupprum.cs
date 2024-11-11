using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookningapp
{
    internal class Grupprum : Lokal // (Abdikani)
    {
        //public int AntalPlatser { get; set; }
        public bool HarWhiteboard { get; set; }
        public Grupprum(string namn, int kapacitet, bool harWhiteboard) : base(namn, kapacitet)
        {
            HarWhiteboard = harWhiteboard;
        }
        public override void VisaInfo()
        {
            base.VisaInfo();
            Console.WriteLine($"Whiteboard: {(HarWhiteboard ? "Ja" : "Nej")}");

            //(Rebecca)
            //public override string VisaInfo() => $"Grupprum:{Namn}, Antal platser: {Kapacitet}, Har Whiteboard: {HarWhiteboard}"; // Rebecca
        }
    }
   
}
