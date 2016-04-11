using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCtoGit
{
    public class ClearCase : Executor
    {
        protected override string Command { get { return "cleartool"; } }

        private string fmt
        {
            get
            {
                return @""""
                + "Attributes=%a"
                + "|Comment=%Nc"
                + "|CreatedDate=%d"
                + "|EventDescription=%e"
                + "|CheckoutInfo=%Rf"
                + "|HostName=%h"
                + "|IndentLevel=%i"
                + "|Labels=%l"
                + "|ObjectKind=%m"
                + "|ElementName=%En"
                + "|Version=%Vn"
                + "|PredecessorVersion=%PVn"
                + "|Operation=%o"
                + "|Type=%[type]p"
                + "|SymbolicLink=%[slink_text]p"
                + "|OwnerLoginName=%[owner]p"
                + "|OwnerFullName=%[owner]Fp"
                + "|HyperLink=%[hlink]p"
                + @"\n""";
            }
        }

        public string VobPath { get; set; }

        public ClearCase(string vobPath) : base(vobPath)
        {
            this.VobPath = vobPath;
        }

        /// <summary>
        /// 매개변수로 주어진 파일에서 해당 브랜치로 작업한 ClearCase history 반환
        /// </summary>
        public List<CCElementVersion> Lshistory(string branch, List<string> pnameList)
        {
            List<string> argList = new List<string>(pnameList.Count);
            pnameList.ForEach(pname => argList.Add("lshistory -fmt " + this.fmt + @" """ + pname + @""""));

            List<CCElementVersion> resultList = new List<CCElementVersion>();

						foreach (string lines in GetExecutedResultList(argList))
						{
							List<string> lineList = lines.Split(Environment.NewLine.ToCharArray(), StringSplitOptions.RemoveEmptyEntries).ToList();
							lineList.ForEach(elemVersion => resultList.Add(new CCElementVersion(this.VobPath, elemVersion)));
						}

            return resultList;
        }

        public void Checkout(CCElementVersion element)
        {
            Execute("checkout -unreserved -ncomment -version \\" + element.Version + " " + element.ElementName);
        }

        public void Uncheckout(string pname)
        {
            Execute("uncheckout -keep " + pname);
        }
    }
}
