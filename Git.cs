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

				internal void AddAll()
				{
					Execute("add .");
				}

        internal void Commit(string author, DateTime date, string message)
        {
					if(string.IsNullOrWhiteSpace(message))
					{
						Execute(@"commit --author=""" + author + @""" --date=""" + date.ToString("ddd MMM d HH:mm:ss yyyy K", new System.Globalization.CultureInfo("en-US")) + @""" -m ""migrated from ClearCase""");
					}
					else
					{
						Execute(@"commit --author=""" + author + @""" --date=""" + date.ToString("ddd MMM d HH:mm:ss yyyy K", new System.Globalization.CultureInfo("en-US")) + @""" -m ""migrated from ClearCase\n" + message.Trim() + @"""");
					}
        }
    }
}
