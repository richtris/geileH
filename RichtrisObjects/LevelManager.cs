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
         
        private int level = 1;
        private int linesToNextLevel = 1;
        private int maxLevel = 20;

        private int lineCounter = 0;

        public LevelManager(Spielfeld spielfeld)
        {
            this.gravityTimer = new Timer(startInterval);
            this.gravityTimer.Elapsed += spielfeld.OnGravity;
        }

        public void Start()
        {
            this.gravityTimer.Start();
        }

        public void Stop()
        {
            this.gravityTimer.Stop();
        }

        public void LinesCleared(int count)
        {
            lineCounter += count;
            var newlevel = (lineCounter / linesToNextLevel) + 1;
            if (newlevel >= maxLevel)
            {
                newlevel = maxLevel;
            }

            if(newlevel > level)
            {
                int levelUp = newlevel - level;
                for (int i = levelUp; i > 0; i--)
                {
                    gravityTimer.Interval *= 0.8;
                }
                level = newlevel;
            }
            Console.WriteLine("Level: {0}",level);
        }

    }
}
