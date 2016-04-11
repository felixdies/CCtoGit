using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CCtoGit
{
    public abstract class Executor
    {
			private string ExecutionResult = string.Empty;

        protected abstract string Command { get; }

        protected string ExecutingPath { get; set; }

        public Executor(string executingPath)
        {
            this.ExecutingPath = executingPath;
        }

        /// <summary>
        /// 첫 번째 매개변수를 인자로 하는 Command 를 실행 합니다.
        /// </summary>
        /// <param name="arg"></param>
        /// <param name="wait">해당 명령을 synchronized 처리합니다.</param>
        protected void Execute(string arg, bool wait = true)
        {
            Process proc = new Process();
            ProcessStartInfo proInfo = new ProcessStartInfo()
            {
                WorkingDirectory = ExecutingPath,
                FileName = @"powershell", // "cmd" doesn't execute the passed command.
                Arguments = Command + " " + arg,
                CreateNoWindow = true,
                UseShellExecute = false,
                RedirectStandardError = true
            };

            proc.StartInfo = proInfo;
            proc.Start();

            if (wait)
            {
                using (StreamReader errReader = proc.StandardError)
                {
                    string err = errReader.ReadToEnd(); // wait for exit
                    if (!string.IsNullOrWhiteSpace(err))
                    {
                        throw new ApplicationException(err);
                    }
                }
            }
        }

				private void ReadExecutionResult(object sendingProcess, DataReceivedEventArgs outLine)
				{
					if (!String.IsNullOrEmpty(outLine.Data))
					{
						this.ExecutionResult += outLine.Data + Environment.NewLine;
					}
				}

        /// <summary>
        /// 주어진 명령어 리스트를 모두 실행하고 그 결과를 반환 한다.
        /// Input 을 redirect 하기 위해 CreateNoWindow 를 false 로 설정하므로, 커맨드창이 나타나는 부작용이 있다.
        /// </summary>
        protected string GetExecutedResult(List<string> argList)
        {
					this.ExecutionResult = string.Empty;

            ProcessStartInfo proInfo = new ProcessStartInfo("cmd")
            {
                WorkingDirectory = ExecutingPath,
                CreateNoWindow = false,
                UseShellExecute = false,
                RedirectStandardInput = true,
                RedirectStandardOutput = true,
                RedirectStandardError = true
            };

            Process proc = new Process();
            proc.StartInfo = proInfo;
            proc.Start();

						proc.OutputDataReceived += new DataReceivedEventHandler(this.ReadExecutionResult);
						proc.BeginOutputReadLine();
						
            foreach (string arg in argList)
            {
							proc.StandardInput.WriteLine(Command + " " + arg);
            }

						proc.StandardInput.WriteLine("exit");

            string err = proc.StandardError.ReadToEnd();
            if (!string.IsNullOrWhiteSpace(err))
            {
                throw new ApplicationException(err);
            }

						// 비동기로 실행되는 ReadExecutionResult 함수가 아직 끝까지 읽지 못한 경우, 기다린다.
						proc.WaitForExit();

						return this.ExecutionResult;
        }

        /// <summary>
        /// 주어진 명령어 리스트를 모두 실행하고 그 결과를 리스트로 반환 한다.
        /// 반환되는 리스트의 크기는 명령어 리스트의 크기와 동일하다.
        /// Input 을 redirect 하기 위해 CreateNoWindow 를 false 로 설정하므로, 커맨드창이 나타나는 부작용이 있다.
        /// </summary>
        protected List<string> GetExecutedResultList(List<string> argList)
        {
            string executedResult = GetExecutedResult(argList);
            string[] resultLines = executedResult.Split(Environment.NewLine.ToCharArray());

            List<string> resultList = Enumerable.Repeat(string.Empty, argList.Count).ToList();

            int index = -1;
            foreach (string line in resultLines)
            {
                if (line.StartsWith(ExecutingPath + ">"))
                {
                    // 명령문 1개당 결과 1개
                    index++;
                    continue;
                }

                if (string.IsNullOrWhiteSpace(line))
                {
                    continue;
                }

                if (index < 0)
                {
                    continue;
                }

                resultList[index] += line + Environment.NewLine;
            }

            return resultList.Select(result => result.Trim()).ToList();
        }
    }
}
