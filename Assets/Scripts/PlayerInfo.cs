using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;

namespace Assets.Scripts
{
	[DataContract]
	public class PlayerInfo
	{
		[DataMember]
		public int Coins { get; set; }
		[DataMember]
		public int BestScore { get; set; }
	}
}
