using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseForms
{
    public class Concert
    {
        public string Name { get; private set; }
        public string Date { get; private set; }
        public string HallName { get; private set; }
        public string HallAddress { get; private set; }
        public decimal ArtistMoney { get; private set; }

        public Concert(string name, string date, string hallName, string hallAddress, decimal artistMoney)
        {
            Name = name;
            Date = date;
            HallName = hallName;
            HallAddress = hallAddress;
            ArtistMoney = artistMoney;
        }
    }
}
