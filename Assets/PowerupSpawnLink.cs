using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupSpawnLink : MonoBehaviour
{
   public PickupSpawnner Spawnner;

   private void OnDestroy()
   {
      Spawnner.PickupUsed();
   }
}
