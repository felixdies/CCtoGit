using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CCtoGit.Test
{
	[TestClass]
	public class ClearCaseTest
	{
		[TestMethod]
		public void TestLshistory()
		{
			ClearCase cc = new ClearCase(@"");
			
			List<string> pnameList = new List<string>();
			pnameList.Add(@"");

			var result = cc.Lshistory("main", pnameList);

			return;
		}
	}
}
