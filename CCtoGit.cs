using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace CCtoGit
{
    public class CCtoGit
    {
        /// <summary>
        /// VOB 내에서 선택된 srcFileList 의 ClearCase history 를 Repository 로 이관합니다.
        /// </summary>
        public void Migrate(string absVobPath, List<string> srcFileList, string absRepoPath)
        {
            // todo : main 외 다른 branch 도 탐색
            // todo : Merge 구현

            ClearCase cc = new ClearCase(absVobPath);
            Git git = new Git(absRepoPath);

            // 1. Vob 내 파일의 history 수집, 정렬.
						// 파일 또는 브랜치 생성 등의 작업은 제외
						List<CCElementVersion> ccCheckedInVersionList = cc.Lshistory("main", srcFileList).Where(ver => ver.Operation == "checkin").ToList();
						ccCheckedInVersionList.Sort((x, y) => x.CreatedDate.CompareTo(y.CreatedDate));

            // 2. Commit 할 단위로 history 묶기
            // todo : 옵션 선택 가능
            //     - 동일 파일이 연속으로 수정 되었으면 하나의 commit 단위로 묶기
            //     - 동일 사용자가 연속으로 check in 하였으면 하나의 commit 단위로 묶기

            // 3. CC checkout, 복사, Git Commit
						foreach (CCElementVersion ccVersion in ccCheckedInVersionList)
            {
							cc.Checkout(ccVersion);

							string filePathInRepo = Path.Combine(absRepoPath, ccVersion.RelPathToVob);
							if (!Directory.Exists(Path.GetDirectoryName(filePathInRepo)))
							{
								Directory.CreateDirectory(Path.GetDirectoryName(filePathInRepo));
							}
							File.Copy(ccVersion.ElementName, filePathInRepo, true);

							git.AddAll();
							git.Commit(ccVersion.OwnerLoginName + " <" + ccVersion.OwnerFullName + ">", ccVersion.CreatedDate, ccVersion.Comment);
							cc.Uncheckout(ccVersion.ElementName);
            }
        }
    }
}
