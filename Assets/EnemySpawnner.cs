using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class EnemySpawnner : MonoBehaviour
{
   public List<GameObject> BasicEnemyPrefabs;
   
   public float SpawnCooldown;
   public float Wobble;
   public float CooldownRamp, RampSpeed;
   // Start is called before the first frame update
   void Start()
   {
      if (BasicEnemyPrefabs.Any())
      {
         StartCoroutine(SpawnLoop());
         StartCoroutine(CooldownRampLoop());
      }
   }

   IEnumerator SpawnLoop()
   {
      yield return new WaitForSeconds(Random.Range(0, 1));
      while (true)
      {
         Instantiate(BasicEnemyPrefabs[Random.Range(0, BasicEnemyPrefabs.Count)], this.transform.position, Quaternion.identity, this.transform);
         yield return new WaitForSeconds(SpawnCooldown + Random.Range(-Wobble, Wobble));
      }
   }

   IEnumerator CooldownRampLoop()
   {
      while(SpawnCooldown - CooldownRamp > 0)
      {
         yield return new WaitForSeconds(RampSpeed);
         SpawnCooldown -= CooldownRamp;
      }
   }
}
