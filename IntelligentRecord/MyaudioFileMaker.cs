using System;
using System.Collections.Generic;
using System.Text;
using Oraycn.MFile;
using System.IO;

namespace IntelligentRecord
{
    class MyaudioFileMaker
    {
        private AudioFileMaker audioFileMaker = new AudioFileMaker();
        private int audioChannelCount;
        private int audioSampleRate;
        private bool isWorking = false;//当前工作状态开关
        private bool preIsWorking = false; //前一次工作状态记录      
        private string OriginalFilePath;
        private FileManager fileManager = new FileManager("录音");//创建一个文件管理对象，用于管理录音文件

        public string FilepreFixIndex
        {
            get
            {
                return this.fileManager.FileIndex.ToString() + ".";
            }
        }

        public string LastFilePath
        {
            get
            {
                return this.fileManager.DirectoryPath + "\\" + (this.fileManager.FileIndex - 1).ToString() + "." + this.OriginalFilePath;
            }
        }

        public bool IsWorking
        {
            get { return isWorking; }
            set
            {
                this.preIsWorking = this.isWorking;
                this.isWorking = value;

                if (this.preIsWorking)
                {
                    if(!this.isWorking)
                    {
                        this.Close();
                    }
                }
                else
                {
                    if(this.isWorking)
                    {
                        this.InitializeAudioFileMaker();
                    }
                }            
            }
        }
        //关闭该对象，此时会将写入文件的数据写完，然后才返回
        private void Close()
        {
            this.audioFileMaker.Close(true);           
        }
        /// <summary>
        /// 初始化该对象所需要的参数
        /// </summary>
        /// <param name="fileName">基础文件名（相对路径）</param>
        /// <param name="audioSampleRate">音频帧率（传输采集器对应属性即可）</param>
        /// <param name="audioChannelCount">声道数传输采集器对应属性即可）</param>
        public void Initialize(string fileName, int audioSampleRate, int audioChannelCount)
        {
            this.OriginalFilePath = fileName;
            this.audioSampleRate = audioSampleRate;
            this.audioChannelCount = audioChannelCount;           
        }
        /// <summary>
        /// 初始化录制部件，此时会生成一个MP3文件
        /// </summary>
        private void InitializeAudioFileMaker()
        {
            this.fileManager.Traverse();//遍历文件夹以获取当前文件应有的序号   
            this.audioFileMaker.Initialize(this.fileManager.DirectoryPath + "\\" + this.FilepreFixIndex + this.OriginalFilePath, this.audioSampleRate, this.audioChannelCount);                   
        }
        /// <summary>
        ///  录制文件，在其工作的地方调用，通过IsWorking来控制工作状态
        /// </summary>
        /// <param name="data">音频数据</param>
        public void StartMakeFile(byte[] data)
        {
            if (!this.isWorking)
            {
                return;
            }            
            this.audioFileMaker.AddAudioFrame(data);
        }
        //销毁
        public void Dispose()
        {
            this.Close();
            this.audioFileMaker.Dispose();
        }
        //打开目录
        public void OpenFileDirectory()
        {
            this.fileManager.OpenDirectory();
        }

      
    }
}
