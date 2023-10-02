using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupSpawnner : MonoBehaviour
{
   public GameObject PickupPrefab;
   public float Cooldown;
   private float cooldownTimer;
   bool pickupActive = false;

   private void Start()
   {
      cooldownTimer = Random.Range(Cooldown/2, Cooldown*3);
   }

   // Update is called once per frame
   void Update()
   {
      if (!pickupActive)
      {
         if(cooldownTimer > 0)
         {
            cooldownTimer -= Time.deltaTime;
         }
         else
         {
            GameObject pickup = Instantiate(PickupPrefab, this.transform.position - new Vector3(0, .5f, 0), this.transform.rotation);
            pickup.GetComponent<PowerupSpawnLink>().Spawnner = this;
            pickupActive = true;
         }
      }
   }

   internal void PickupUsed()
   {
      pickupActive = false;
      ScoreTracker.OnScoreEvent.Invoke((int)Cooldown);
      cooldownTimer = Random.Range(Cooldown, Cooldown * 3); 
   }
}
