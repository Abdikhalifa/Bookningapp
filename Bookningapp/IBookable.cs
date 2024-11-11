using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookningapp
{
    public interface IBookable // Interface (Alexandra)
    {
        string Användarnamn { get; set; }

        DateTime StarttidBokning { get; set; }
        DateTime SluttidBokning { get; set; } //inget set om det räknas ut i programmet

        TimeSpan TidslängdBokning => SluttidBokning - StarttidBokning;

        void NyBokning();


        void UppdateraBokning();

        void TaBortBokning();

    }
}
