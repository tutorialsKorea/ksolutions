using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace QueryApi.Models.Users
{
	public class BizRule
	{
		public string EXECUTE_TYPE { get; set; }
		public string CLASS_NAME { get; set; }
		public string RULE_NAME { get; set; }
		public string USER_ID { get; set; }
		public object DATA { get; set; }
	}
}
