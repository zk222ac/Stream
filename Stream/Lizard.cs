using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stream
{
    [Serializable]
    public class Lizard
    {
        // define Instance fields............................................... 
        private string _type;
        private string _number;
        private bool _healthy;

        // define properties .............................................
        public string Type
        {
            get => _type;
            set => _type = value;
        }

        public string Number
        {
            get => _number;
            set => _number = value;
        }

        public bool Healthy
        {
            get => _healthy;
            set => _healthy = value;
        }

        // define Constructor ......................................
        public Lizard(string type, string number, bool healthy)
        {
            this._type = type;
            this._number = number;
            this._healthy = healthy;
        }

        // Data behavior ( Method ...............
        public void Eat()
        {
            Console.WriteLine("Lizards eat insects");
        }
    }
}
