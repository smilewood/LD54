using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyDamage : MonoBehaviour
{
   public int Damage;

   private void OnCollisionEnter2D(Collision2D collision)
   {
      if (collision.gameObject.CompareTag("Player"))
      {
         PlayerHealth.OnPlayerDamage.Invoke(Damage);
         Destroy(this.gameObject);
      }
   }

}
