using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace supply_activity_app
{
    public class InvalidSignDateException : Exception
    {
		public DateTime SignDate { get; set; }

		public InvalidSignDateException(DateTime signDate)
		{
			SignDate = signDate;
		}

		public override string Message
		{
			get
			{
				return "Singning date " + SignDate + " is invalid";
			}
		}
	}
}
