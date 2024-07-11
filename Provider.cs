using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace supply_activity_app
{
    [Serializable]
    public class Provider
    {
        private string name;
        private int founded;
        private List<Material> materials;

        public Provider()
        {
            name = "n/a";
            founded = 1600;
            materials = null;
        }

        public Provider(string name, int founded, List<Material> materials)
        {
            this.name = name;
            this.founded = founded;
            this.materials = materials;
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

        public int Founded
        {
            get { return founded; }
            set
            {
                if (value != 0 && value >= 1600)
                {
                    founded = value;
                }
            }
        }

        public List<Material> Materials
        {
            get { return materials; }
            set
            {
                if (value != null)
                {
                    materials = value;
                }
            }
        }

        public override string ToString()
        {
            string s = "Provider name: " + name + "; Founded: " + founded + "; Materials: " 
                + String.Join(", ", materials.Select(m => m.ToString()).ToArray());
            return s;
        }
    }
}
