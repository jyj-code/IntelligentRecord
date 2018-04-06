using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Oraycn.MCapture;
using Oraycn.MFile;
using System.Configuration;

namespace IntelligentRecord
{
    public partial class Form1 : Form
    {
        private IMicrophoneCapturer microphoneCapturer;
        private MyaudioFileMaker audioFileMaker = new MyaudioFileMaker(); //录制器    
        private accumulater lowDBFrameCounter = new accumulater();//低分贝计数器
        private accumulater frameCounter = new accumulater();//帧数计数器 
     
        /*【大致思路】
         * 程序启动时开启采集，用分贝显示器来获取每一帧的分贝。
           在采集事件处理函数中轮询分贝值。
           如果分贝值高于一定值，开启录制 
           如果分贝值低于一定值，低分贝计数器加一，帧数计数器加一
           如果低分贝计数器在一定帧数内，低分贝计数器等于帧数计数器，即该段时间内持续低分贝，关闭录制
         */

        public Form1()
        {
            InitializeComponent();
            this.microphoneCapturer = CapturerFactory.CreateMicrophoneCapturer(0);//采集器，启动程序时即开启
            this.microphoneCapturer.AudioCaptured += new ESBasic.CbGeneric<byte[]>(microphoneCapturer_AudioCaptured);//预定采集事件
            this.microphoneCapturer.Start();//开始采集
            //初始化录制器所需的参数
            this.audioFileMaker.Initialize("test.mp3", this.microphoneCapturer.SampleRate, this.microphoneCapturer.ChannelCount);
        }

        void microphoneCapturer_AudioCaptured(byte[] data)
        {
            this.audioFileMaker.StartMakeFile(data);//录制器安插此处，通过IsWorking参数来控制其工作状态
            this.frameCounter.Start(); //帧数计数器安插此处，用于记录在低分贝时期内的总帧数。通过IsWorking参数来控制其工作状态
           
            this.decibelDisplayer1.DisplayAudioData(data);//分贝显示器显示音量
            this.label_db.Text = this.decibelDisplayer1.Volume.ToString();//显示当前音量
            this.label_RecordSign.Text = this.audioFileMaker.IsWorking ? "正在录音" : "未录音";
            this.label_RecordSign.ForeColor = this.audioFileMaker.IsWorking ? Color.Blue : Color.Red;

            //当音量高于开启值时，打开录制器
            if (this.decibelDisplayer1.Volume > int.Parse(ConfigurationManager.AppSettings["DB2Open"]))
            {
                this.audioFileMaker.IsWorking = true;
            }
            //当记录的低分贝帧数达到一定值时，关闭两个计数器，然后总结这段时间内的帧状况
            if (this.lowDBFrameCounter.Count > int.Parse(ConfigurationManager.AppSettings["checkCount"]))
            {
                //若低分贝帧数与总帧数一直，即该段时间内持续低分贝，则关闭录制
                if (this.lowDBFrameCounter.Count == this.frameCounter.Count)
                {
                    this.audioFileMaker.IsWorking = false;                   
                }
                this.frameCounter.IsWorking = false;
                this.lowDBFrameCounter.IsWorking = false;
                return;
            }

            //当音量低于阈值时，开启低分贝计数器与帧数计数器的计数
            if (this.decibelDisplayer1.Volume < int.Parse(ConfigurationManager.AppSettings["DB2Close"]))
            {
                this.frameCounter.IsWorking = true;
                this.lowDBFrameCounter.IsWorking = true;
                this.lowDBFrameCounter.Start();
            }            
        }

        //关闭主窗时，释放采集器与录制器
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.microphoneCapturer.Dispose();
            this.audioFileMaker.Dispose();
        }
        //打开文件夹
        private void button_OpenDirectory_Click(object sender, EventArgs e)
        {
            this.audioFileMaker.OpenFileDirectory();
        }
    }
}
