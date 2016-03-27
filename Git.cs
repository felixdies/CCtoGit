using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCtoGit
{
    public class Git : Executor
    {
        protected override string Command { get { return "git"; } }

        public string RepoPath { get; set; }

        public Git(string repoPath) : base(repoPath)
        {
            this.RepoPath = repoPath;
        }

        internal void Commit(string message, string author, DateTime date)
        {
            Execute("commit --author='" + author + "' --date='" + date.ToString() + "' -am '" + message + "'");
        }
    }
}
