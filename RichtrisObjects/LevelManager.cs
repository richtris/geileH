using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace RichtrisObjects
{        
    class LevelManager
    {

        public Timer gravityTimer;

        private double startInterval = 2000;

        private double gravityInterval;
         
        private int linesPerLevel = 10;
        private int maxLevel = 20;
        private int lineCounter = 0;
        public int LineCounter { 
            get { return lineCounter; } 
            private set {
                lineCounter = value;
                UpdateLevel();
            }
        }
        private int level = 1;
        public int Level {
            get { return level; }
            private set
            {
                level = value;
                this.gravityTimer.Interval = startInterval - ((level - 1) * startInterval * 0.10); 
            }
        }

        private void UpdateLevel()
        {
            Level = (lineCounter / linesPerLevel) + 1;
        }

        public LevelManager(Spielfeld spielfeld)
        {
            this.gravityTimer = new Timer(startInterval);
            this.gravityTimer.Elapsed += spielfeld.OnGravity;
        }

        public void Start()
        {
            this.gravityTimer.Start();
        }

        public void Reset()
        {
            this.gravityTimer.Interval = startInterval;
            this.LineCounter = 0;
        }

        public void Stop()
        {
            this.gravityTimer.Stop();
        }

        public void LinesCleared(int count)
        {
            LineCounter += count;
        }

    }
}
