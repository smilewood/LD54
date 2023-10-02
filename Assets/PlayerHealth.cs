using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerDamageEvent : UnityEvent<int> { }

public class PlayerHealth : MonoBehaviour
{
   public GameObject HPBar;
   public float MaxHealth;
   private float currentHP;
   public AudioSource source;

   private static PlayerDamageEvent _onPlayerDamage;
   public static PlayerDamageEvent OnPlayerDamage
   {
      get
      {
         _onPlayerDamage ??= new PlayerDamageEvent();
         return _onPlayerDamage;
      }
   }

   private static UnityEvent _onPlayerDeath;
   public static UnityEvent OnPlayerDeath
   {
      get
      {
         _onPlayerDeath ??= new UnityEvent();
         return _onPlayerDeath;
      }
   }

   // Start is called before the first frame update
   void Start()
   {
      OnPlayerDamage.AddListener(DamagePlayer);
      currentHP = MaxHealth;
      UpdateHPBar();
   }

   private void DamagePlayer(int damage)
   {
      currentHP -= damage;
      source.Play();
      if(currentHP > MaxHealth)
      {
         //negative damage == healing, don't allow overhealth
         currentHP = MaxHealth;
      }

      if(currentHP <= 0)
      {
         OnPlayerDeath.Invoke();
         //Game Over
      }

      UpdateHPBar();
   }

   public void UpdateHPBar()
   {
      HPBar.transform.localScale = new Vector3(currentHP / MaxHealth, HPBar.transform.localScale.y, HPBar.transform.localScale.z);
   }
}
