using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CCtoGit.Test
{
	[TestClass]
	public class CCtoGitTest
	{
		[TestMethod]
		public void TestMigrate()
		{
			string absVobPath = "";
			string absRepoPath = "";

			List<string> srcFileList = new List<string>();
			srcFileList.Add("");

			new CCtoGit().Migrate(absVobPath, srcFileList, absRepoPath);
		}
	}
}
