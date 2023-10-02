using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyTracker : MonoBehaviour
{
   public GameObject KeyPrefab;

   public int RemainingKeys;


   // Start is called before the first frame update
   void Start()
   {
      EnemyHealth.OnEnemyDeath.AddListener(EnemyDeath);
   }

   private void EnemyDeath(int score)
   {
      if(score > 100)
      {
         Instantiate(KeyPrefab, this.transform);
         ++RemainingKeys;
      }
   }

   public bool UseKey()
   {
      if(RemainingKeys == 0)
      {
         return false;
      }
      else
      {
         --RemainingKeys;
         Destroy(this.transform.GetChild(0).gameObject);
         return true;
      }
   }

}
