using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EczaDepo
{
    class Item
    {
        public int Id { get; set; }
        public string AdString { get; set; }
        public int MiktarInt { get; set; }

        public Item(int id, string adString, int miktarInt)
        {
            Id = id;
            AdString = adString;
            MiktarInt = miktarInt;
        }
    }
}
