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
				/// 주어진 파일이 CheckIn 등을 통해 vob object 로 등록 된 파일인 지 여부를 반환
				/// ls 결과에 @@\main 이 포함 돼 있다면 vob object 로 판단한다.
				/// </summary>
				public bool IsVobObject(string pname)
				{
					List<string> argList = new List<string>();
					argList.Add("ls" + @" """ + pname + @"""");

					List<string> lsResult = GetExecutedResultList(argList);

					return lsResult[0].IndexOf("@@\\main") != -1;
				}

				/// <summary>
				/// 주어진 파일이 Checked Out 상태인 지 여부를 반환
				/// ls 결과에 Rule: CHECKEDOUT 이 포함 돼 있다면 Checked Out 상태로 판단한다.
				/// </summary>
				public bool IsCheckedOut(string pname)
				{
					List<string> argList = new List<string>();
					argList.Add("ls" + @" """ + pname + @"""");

					List<string> lsResult = GetExecutedResultList(argList);

					return lsResult[0].IndexOf("Rule: CHECKEDOUT") != -1;
				}

        /// <summary>
        /// 매개변수로 주어진 파일에서 해당 브랜치로 작업한 ClearCase history 반환
        /// </summary>
        public List<CCElementVersion> Lshistory(string branch, List<string> pnameList)
        {
            List<string> argList = new List<string>(pnameList.Count);

						foreach (string pname in pnameList)
						{
							// CheckIn 등을 통해 vob object 로 등록 된 파일에만 적용
							if (IsVobObject(pname))
							{
								argList.Add("lshistory -fmt " + this.fmt + @" """ + pname + @"""");
							}
						}

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
					Execute(@"checkout -unreserved -ncomment -version """ + element.ElementName + "@@" + element.Version + @"""");
        }

        public void Uncheckout(string pname, bool keep)
        {
					if (keep)
					{
						Execute(@"uncheckout -keep """ + pname + @"""");
					}
					else
					{
						Execute(@"uncheckout -rm """ + pname + @"""");
					}
        }
    }
}
