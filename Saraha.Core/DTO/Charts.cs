//using System;
//using System.Collections.Generic;
//using System.Text;
using System;
using System.Runtime.Serialization;
namespace Saraha.Core.DTO
{
  
		[DataContract]
		public class Charts
		{
			public Charts(string label, double y)
			{
				this.Label = label;
				this.Y = y;
			}

			//Explicitly setting the name to be used while serializing to JSON.
			[DataMember(Name = "label")]
			public string Label = "";

			//Explicitly setting the name to be used while serializing to JSON.
			[DataMember(Name = "y")]
			public Nullable<double> Y = null;
		}
	}




