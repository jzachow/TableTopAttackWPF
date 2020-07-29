﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

namespace TabletopAttack
{
    class SwordDamage
    {
        private const int BASE_DAMAGE = 3;
        private const int FLAME_DAMAGE = 2;

        /// <summary>
        /// Contains the calculated damage
        /// </summary>
        public int Damage { get; private set; }


        private int roll;

        /// <summary>
        /// Sets or gets the 3d6 roll
        /// </summary>
        public int Roll
        {
            get
            { return roll; }
            set
            {
                roll = value;
                CalculateDamage();
            }
        }


        private bool magic;

        /// <summary>
        /// True if the sword is magic, false otherwise
        /// </summary>
        public bool Magic
        {
            get
            { return magic; }
            set
            {
                magic = value;
                CalculateDamage();
            }
        }

        private bool flaming;

        /// <summary>
        /// True if the sword is flaming, false otherwise
        /// </summary>
        public bool Flaming
        {
            get { return flaming; }
            set
            {
                flaming = value;
                CalculateDamage();
            }
        }


        /// <summary>
        /// Calculates the damage based on the currect properties
        /// </summary>
        private void CalculateDamage()
        {
            decimal magicMultiplier = 1M;
            if (magic) magicMultiplier = 1.75M;

            Damage = (int)(Roll * magicMultiplier) + BASE_DAMAGE;
            if (Flaming) Damage += FLAME_DAMAGE;
        }

        /// <summary>
        /// The constructor calculates damage based on default Magic
        /// and Flaming values and a starting 3d6 roll
        /// </summary>
        /// <param name="startingRoll">Starting 3d6 roll</param>
        public SwordDamage(int startingRoll)
        {
            roll = startingRoll;
            CalculateDamage();
        }



    }
}
