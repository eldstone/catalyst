using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Catalyst.Models.View
{
	/// <summary>
	/// View model for handling search requests
	/// </summary>
	[Serializable]
	[JsonObject]
	public class ViewSearch
	{
		public string q { get; set; } = "";
		public long min { get; set; }
		public long max { get; set; }
	}
}