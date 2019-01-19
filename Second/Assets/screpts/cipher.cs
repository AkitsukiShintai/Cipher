using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Reflection;
using System.Diagnostics;
using UnityEngine.UI;

public class cipher : MonoBehaviour {

    public InputField answer;
    public InputField result;
    public Text  show;
    int currentCount = 0;
    List<string> a = new List<string>{ "1000100101101100100111110000011101010011100001101101111001011010101111001100101110100000111101111010101111101001111100110010000111100110101",
        "000010010101001101110000111110100101011000110101",
        "0101001101110000111110100111010111000011011001011110101010000101011110001101101111000011110010011111101001111100" ,
        "0101100011010100110010111110011110011110101101011001000111100010101100010101001101011010100001010111110100111010111000011011000001111110000111010011001001111100010000000101110010110000001100000"};

    private void Start()
    {
        show.text = a[currentCount];
    }

    public void next()
    {
        ++currentCount;
        if (currentCount>3)
        {
            currentCount = 0;
        }
        show.text = a[currentCount];
    }

        public void click()
    {
        //ProcessStartInfo startInfo = new ProcessStartInfo();
        string CmdPath = @"C:\Windows\System32\cmd.exe";
         //Application.OpenURL("cipher.exe 000001");
        string cmd = Application.dataPath+@"/cipher.exe";
        //cmd = @"ipconfig/all";
        //cmd = cmd.Trim().TrimEnd('&') + "&exit";//说明：不管命令是否成功均执行exit命令，否则当调用ReadToEnd()方法时，会处于假死状态
        using (Process p = new Process())
        {
            p.StartInfo.FileName = cmd;
            string resultText = result.text==""? show.text:result.text;
        
            p.StartInfo.Arguments = resultText  +" "+ answer.text; //answer.text + result.text;
            p.StartInfo.UseShellExecute = false;        //是否使用操作系统shell启动
            //p.StartInfo.RedirectStandardInput = true;   //接受来自调用程序的输入信息
           // p.StartInfo.RedirectStandardOutput = true;  //由调用程序获取输出信息
            //p.StartInfo.RedirectStandardError = true;   //重定向标准错误输出
           // p.StartInfo.CreateNoWindow = false;          //不显示程序窗口
            p.StartInfo.WindowStyle = ProcessWindowStyle.Normal;
            p.Start();//启动程序

            //向cmd窗口写入命令
            //p.StandardInput.WriteLine(cmd);
            //p.StandardInput.AutoFlush = true;

            //获取cmd窗口的输出信息
           // string output = p.StandardOutput.ReadToEnd();
           //print(output);
            p.WaitForExit();//等待程序执行完退出进程
            p.Close();
         }
    }


    public void helpclick()
    {
        //ProcessStartInfo startInfo = new ProcessStartInfo();
        string cmd = Application.dataPath + @"/指导手册.txt";
        Application.OpenURL(cmd);
        //cmd = @"ipconfig/all";
        //cmd = cmd.Trim().TrimEnd('&') + "&exit";//说明：不管命令是否成功均执行exit命令，否则当调用ReadToEnd()方法时，会处于假死状态
        
    }

    public void webclick()
    {
        //ProcessStartInfo startInfo = new ProcessStartInfo();
        string cmd = Application.dataPath + @"/web.html";
        Application.OpenURL(cmd);
        //cmd = @"ipconfig/all";
        //cmd = cmd.Trim().TrimEnd('&') + "&exit";//说明：不管命令是否成功均执行exit命令，否则当调用ReadToEnd()方法时，会处于假死状态

    }
}

