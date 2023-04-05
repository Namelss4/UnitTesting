using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sumas__TheGame
{
    internal class Character
    {
        public enum type
        {
            main, 
            evil, 
            help
        }
        private type chType;
        private int level;

        public Character(int level, type characterType)
        {
            this.level = level;
            this.chType = characterType;
        }

        public int Level { get => level; set => level = value; }
        public type ChType { get => chType; set => chType = value; }
        
    }
}
