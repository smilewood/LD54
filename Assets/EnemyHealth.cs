using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyDeathEvent : UnityEvent<int> { }

public class EnemyHealth : MonoBehaviour
{
   public int ScoreForKill;
   public int MaxHealth;
   public AudioSource source;
   private static EnemyDeathEvent _onEnemyDeath;
   public static EnemyDeathEvent OnEnemyDeath
   {
      get
      {
         _onEnemyDeath ??= new EnemyDeathEvent();
         return _onEnemyDeath;
      }
   }

   private int currentHealth;

   // Start is called before the first frame update
   void Start()
   {
      currentHealth = MaxHealth;
   }

   public void TakeDamage(int amount)
   {
      currentHealth -= amount;
      if(currentHealth <= 0)
      {
         OnEnemyDeath.Invoke(ScoreForKill);
         source.Play();
         Destroy(this.gameObject, source.clip.length);
      }
   }
}
