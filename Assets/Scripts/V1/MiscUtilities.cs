using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Box;

public static class MiscUtilities 
{
   public static bool InRange(this int value, int lowBound, int highBound)
   {
      Debug.Assert(lowBound < highBound);
      return lowBound <= value && value < highBound;
   }
}
