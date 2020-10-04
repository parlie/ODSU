using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;

namespace ODSU
{
    public class Tribit
    {
                /// <summary>
        /// Global variable for storing final three bits to convert to color.
        /// </summary>
        private readonly bool[] _bits = new bool[3];
        
        /// <summary>
        /// Constructor for ODTS class.
        /// </summary>
        // ReSharper disable once UnusedMember.Local
        Tribit()
        {
            _bits[0] = false;
            _bits[1] = false;
            _bits[2] = false;
        }

        /// <summary>
        /// Constructor for ODTS class.
        /// </summary>
        /// <param name="bit1">First bit</param>
        /// <param name="bit2">Second bit</param>
        /// <param name="bit3">Third bit</param>
        Tribit(bool bit1, bool bit2, bool bit3)
        {
            _bits[0] = bit1;
            _bits[1] = bit2;
            _bits[2] = bit3;
        }

        /// <summary>
        /// Converts bits to color; False = 0; True = 255;
        /// </summary>
        /// <returns>Returns color in ARGB format.</returns>
        public Color ToColor()
        {
            int r = 0;
            int g = 0;
            int b = 0;

            if (_bits[0])
            {
                r = 255;
            }

            if (_bits[1])
            {
                g = 255;
            }

            if (_bits[2])
            {
                b = 255;
            }

            return Color.FromArgb(r, g, b);
        }

        /// <summary>
        /// Converts bytes to Tribits
        /// </summary>
        /// <param name="bytes">Byte array</param>
        /// <returns>Returns Tribits</returns>
        public static Tribit[] FromBytes(byte[] bytes)
        {
            List<Tribit> tribits = new List<Tribit>();
            BitArray bts = new BitArray(bytes);

            for (int i = 0; i < bts.Length - bts.Length % 3; i = i + 3)
            {
                tribits.Add(new Tribit(bts.Get(i), bts.Get(i + 1), bts.Get(i + 2)));
            }

            switch (bts.Length % 3)
            {
                case 0:
                    tribits.Add(new Tribit(false,false,false));
                    break;
                case 1:
                    tribits.Add(new Tribit(bts.Get(bts.Length - 1),false,false));
                    break;
                case 2:
                    tribits.Add(new Tribit(bts.Get(bts.Length - 2),bts.Get(bts.Length - 1),false));
                    break;
            }

            return tribits.ToArray();
        }

        /// <summary>
        /// Converts Tribits to bytes.
        /// </summary>
        /// <param name="tribits">ODTS array</param>
        /// <returns>Returns bytes</returns>
        public static byte[] ToBytes(Tribit[] tribits)
        {
            bool[] localBites = new bool[tribits.Length * 3];

            for (int i = 0; i < localBites.Length; i = i + 3)
            {
                localBites[i + 0] = tribits[i / 3]._bits[0];
                localBites[i + 1] = tribits[i / 3]._bits[1];
                localBites[i + 2] = tribits[i / 3]._bits[2];
            }

            BitArray bitArray = new BitArray(localBites);

            int numBytes = bitArray.Length / 8;

            if (bitArray.Length % 8 != 0)
            {
                numBytes += 1;
            }
                
            var bytes = new byte[numBytes];
            bitArray.CopyTo(bytes,0);
            Array.Resize(ref bytes,bytes.Length - 1);
            return bytes;
            
        }
    }
}