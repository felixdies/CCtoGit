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

            // 1. Vob 내 파일의 history 수집, 정렬
            List<CCElementVersion> ccVersionList = cc.Lshistory("main", srcFileList);
            ccVersionList.Sort((x, y) => x.CreatedDate.CompareTo(y.CreatedDate));

            // 2. Commit 할 단위로 history 묶기
            // todo : 옵션 선택 가능
            //     - 동일 파일이 연속으로 수정 되었으면 하나의 commit 단위로 묶기
            //     - 동일 사용자가 연속으로 check in 하였으면 하나의 commit 단위로 묶기

            // 3. CC checkout, 복사, Git Commit
            foreach(CCElementVersion ccVersion in ccVersionList)
            {
                cc.Checkout(ccVersion);

                File.Copy(Path.Combine(absVobPath, ccVersion.ElementName), Path.Combine(absRepoPath, ccVersion.ElementName));

                git.Commit(ccVersion.Comment, ccVersion.OwnerLoginName, ccVersion.CreatedDate);
                cc.Uncheckout(ccVersion.ElementName);
            }
        }
    }
}
