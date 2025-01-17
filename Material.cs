﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace supply_activity_app
{
    [Serializable]
    public class Material 
    {
        public long Id { get; set; }
        private string name;
        private long price;

        public Material()
        {
            name = "n/a";
            price = 1;
        }

        public Material(string name, long price)
        {
            this.name = name;
            this.price = price;
        }

        public Material(long id, string name, long price)
            : this(name, price)
        {
            Id = id;
        }

        public string Name
        {
            get { return name; }
            set
            {
                if (value != null)
                {
                    name = value;
                }
            }
        }

        public long Price
        {
            get { return price; }
            set
            {
                if (value > 0)
                {
                    price = value;
                }
            }
        }


        public override string ToString()
        {
            string s = "Material name: " + name + "; Price: " + price;
            return s;
        }
    }
}
