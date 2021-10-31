using System;
using System.Diagnostics;

namespace Utils
{
    public class CommandRunner
    {
        public string Command { get; set; }

        public string OutputCache { get; set; }

        private readonly string CMD_PROCESS = "cmd.exe";

        public bool Excute()
        {
            using (var p = new Process())
            {
                try
                {
                    p.StartInfo.FileName = CMD_PROCESS;
                    //是否使用操作系统shell启动
                    p.StartInfo.UseShellExecute = false;
                    // 接受来自调用程序的输入信息
                    p.StartInfo.RedirectStandardInput = true;
                    //输出信息
                    p.StartInfo.RedirectStandardOutput = true;
                    // 输出错误
                    p.StartInfo.RedirectStandardError = true;
                    //不显示程序窗口
                    p.StartInfo.CreateNoWindow = true;
                    //启动程序
                    p.Start();

                    //向cmd窗口发送命令
                    p.StandardInput.WriteLine(Command + "&exit");
                    p.StandardInput.AutoFlush = true;

                    //获取输出信息
                    OutputCache = p.StandardOutput.ReadToEnd();
                    //等待程序执行完退出进程
                    p.WaitForExit();
                    p.Close();

                    Console.WriteLine(OutputCache);
                }
                catch (Exception e) 
                {
                    Console.WriteLine($"Run Command Error >> {e}");
                }
            }
            return true;
        }
    }
}
