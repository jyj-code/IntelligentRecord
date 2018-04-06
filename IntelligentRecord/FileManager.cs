using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Diagnostics;

namespace IntelligentRecord
{
    //文件管理器
    class FileManager
    {
        private string directoryPath;//文件夹路径

        public string DirectoryPath
        {
            get { return directoryPath; }           
        }

        private List<string> fileList = new List<string>();//文件名集合

        public List<string> FileList
        {
            get { return fileList; }
        }

        private int fileIndex;//文件计数，用于命名文件的序号

        public int FileIndex
        {
            get { return fileIndex; }           
        }
        //构造方法
        public FileManager(string _directoryPath)
        {
            this.directoryPath = _directoryPath;
            this.Intialize();
        }
        //将状态初始化
        private void Intialize()
        {
            if (!Directory.Exists(this.directoryPath))
            {
                Directory.CreateDirectory(this.directoryPath);
            }
            this.Traverse(); //遍历文件以获得新插入文件的序号          
        }

        //打开目录
        public void OpenDirectory()
        {
            Process.Start("explorer.exe", this.directoryPath); 
        }

        //遍历文件以获得新插入文件的序号
        public void Traverse()
        {
            this.fileIndex = 0;
            string[] fileNames = Directory.GetFiles(this.directoryPath);
            foreach (string fileName in fileNames)
            {
                this.fileList.Add(fileName);
                this.fileIndex++;
            } 
        }     
    }
}
