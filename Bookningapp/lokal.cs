﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookningapp
{
    internal class Lokal : IBookable 
    {
        // Egenskaper för namn och kapacitet
        public string Namn { get; set; }
        public int Kapacitet { get; set; }

        //bokningS hanterar bokningarna för lokelen
        private BokningService bokningS;

        public Lokal(string namn, int kapacitet )
        {
            Namn = namn;
            Kapacitet = kapacitet;
            bokningS = new BokningService();

            
        }
        public virtual void VisaInfo()
        {
            Console.WriteLine($"Namn: {Namn} Kapacitet: {Kapacitet}");

        }
        // Metod för att boka en tid
        public bool Boka(DateTime startTid, DateTime slutTid)
        {
            return bokningS.läggTillBokning(startTid, slutTid);
        }
        // Metod för att avboka 
        public bool Avboka(DateTime startTid)
        {
            return bokningS.TaBortBokning(startTid);
           
        }

       
    }
}



