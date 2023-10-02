using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PowerupManager : MonoBehaviour
{
   public enum PowerupType
   {
      Speed,
      FireRate,
      Damage,
      Heal
   }

   private Dictionary<PowerupType, PowerupEffect> activePowerups;

   private PlatformerController moveController;
   private PlayerShoot shootingController;

   public GameObject DamageIndicator, FireRateIndicator, SpeedIndicator;

   // Start is called before the first frame update
   void Start()
   {
      activePowerups = new Dictionary<PowerupType, PowerupEffect>();
      moveController = gameObject.GetComponent<PlatformerController>();
      shootingController = gameObject.GetComponentInChildren<PlayerShoot>();
      SpeedIndicator.SetActive(false);
      FireRateIndicator.SetActive(false);
      DamageIndicator.SetActive(false);
   }

   private void Update()
   {
      foreach(PowerupType type in activePowerups.Keys.ToList())
      {
         activePowerups[type].duration -= Time.deltaTime;
         if (activePowerups[type].duration <= 0)
         {
            EndEffect(activePowerups[type]);
         }
      }
   }

   private void ApplyEffect(PowerupEffect effect)
   {
      if (activePowerups.TryGetValue(effect.type, out PowerupEffect activeEffect))
      {
         EndEffect(activeEffect);
      }

      switch (effect.type)
      {
         case PowerupType.Speed:
         {
            moveController.Speed += effect.power;
            SpeedIndicator.SetActive(true);
            break;
         }
         case PowerupType.FireRate:
         {
            shootingController.Cooldown -= effect.power;
            FireRateIndicator.SetActive(true);
            break;
         }
         case PowerupType.Damage:
         {
            shootingController.ShotDamage += (int)effect.power;
            DamageIndicator.SetActive(true);
            break;
         }
      }
      activePowerups[effect.type] = effect;
   }

   private void EndEffect(PowerupEffect effect)
   {
      switch (effect.type)
      {
         case PowerupType.Speed:
         {
            moveController.Speed -= effect.power;
            SpeedIndicator.SetActive(false);
            break;
         }
         case PowerupType.FireRate:
         {
            shootingController.Cooldown += effect.power;
            FireRateIndicator.SetActive(false);
            break;
         }
         case PowerupType.Damage:
         {
            shootingController.ShotDamage -= (int)effect.power;
            DamageIndicator.SetActive(false);
            break;
         }
      }
      activePowerups.Remove(effect.type);
   }

   private void OnTriggerEnter2D(Collider2D collision)
   {
      if (collision.gameObject.CompareTag("Powerup") && collision.gameObject.GetComponent<Powerup>() is Powerup powerup)
      {
         if (!powerup.Activate())
         {
            ApplyEffect(powerup.Effect());
         }
      }
   }
   

   public class PowerupEffect
   {
      public PowerupType type;
      public float duration;
      public float power;
   }
}
