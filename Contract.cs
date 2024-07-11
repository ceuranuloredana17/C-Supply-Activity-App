using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace supply_activity_app
{
    [Serializable]
    public class Contract
    {
        
        public long Id { get; set; }
        public Provider provider;
        public DateTime signDate;
        public long validity; // in ani
        public long _value;

        public Contract()
        {
            provider = null;
            signDate = new DateTime(2021, 1, 1);
            validity = 1;
            _value = 1;
        }

        public Contract(Provider provider, DateTime signDate, long validity, long value)
        {
            this.provider = provider;
            this.signDate = signDate;
            this.validity = validity;
            _value = value;
        }
        public Contract(long id, Provider provider, DateTime signDate, long validity, long value)
            : this(provider, signDate, validity, value)
        {
            Id = id;
        }

        public Provider Provider
        {
            get { return provider; }
            set
            {
                if (value != null)
                {
                    provider = value;
                }
            }
        }

        public DateTime SignDate
        {
            get { return signDate; }
            set
            {
                if (value > DateTime.Today.AddDays(1))
                {
                    throw new InvalidSignDateException(value);
                }
                signDate = value;
            }
        }
        public long Validity
        {
            get { return validity; }
            set
            {
                if (value >= 1)
                {
                    validity = value;
                }
            }
        }
        public long Value
        {
            get { return _value; }
            set
            {
                if (value > 0)
                {
                    _value = value;
                }
            }
        }

        public override string ToString()
        {
            string s = provider + "; Date of signing the contract: " + signDate + "; Validity: " + validity + "; The value of the contract: " + _value;
            return s;
        }
    }
}
