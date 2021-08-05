using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayLibrary
{
    public class ArrayClass
    {
        #region Fields & Properties
        private int min, max;
        public int[] intArray;

        public int Min
        {
            private set
            {
                min = value;
            }
            get
            {
                return min;
            }
        }

        public int Max
        {
            private set
            {
                max = value;
            }
            get
            {
                return max;
            }
        }
        #endregion

        #region Constructor
        
        #endregion
    }
}
