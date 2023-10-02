using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour
{
   public PowerupManager.PowerupType Type;
   public float Duration;
   public float Power;

   /// <summary>
   /// Activate the powerup
   /// </summary>
   /// <returns>True if the powerup effect was activated, false otherwise</returns>
   internal virtual bool Activate()
   {
      Destroy(this.gameObject);
      return false;
   }

   internal PowerupManager.PowerupEffect Effect()
   {
      return new PowerupManager.PowerupEffect() { type = Type, duration = Duration, power = Power };
   }
}
