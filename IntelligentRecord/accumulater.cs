using System;
using System.Collections.Generic;
using System.Text;

namespace IntelligentRecord
{    
    class accumulater
    {
        private int count;//计数器
        private bool isWorking;

        public int Count
        {
            get { return count; }
        }

        public bool IsWorking//开关
        {
            get { return isWorking; }
            set 
            {
                isWorking = value;
                if (!value)
                {
                    this.count = 0;
                }
            }
        }
        /// <summary>
        /// 在其工作的地方调用，通过IsWorking来控制工作状态
        /// </summary>
        public void Start()
        {
            if (!this.isWorking)
            {
                return;
            }
            this.count++;
        }
    }
}
