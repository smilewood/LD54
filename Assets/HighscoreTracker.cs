using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighscoreTracker : MonoBehaviour
{
   private int highScore;
   public int HighScore
   {
      get
      {
         return highScore;
      }

      set
      {
         if(highScore < value)
         {
            highScore = value;
         }
      }
   }
   
   // Start is called before the first frame update
   void Start()
   {
      DontDestroyOnLoad(this);
   }

}
