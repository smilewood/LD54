using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : Powerup
{
   internal override bool Activate()
   {
      base.Activate();
      PlayerHealth.OnPlayerDamage.Invoke((int)-Power);
      return true;
   }
}
