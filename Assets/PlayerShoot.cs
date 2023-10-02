using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
   public GameObject ShotPrefab;
   public Transform ShotParent;
   public float Cooldown;
   private float cooldownTimer;
   private bool LastDirectionWasLeft;
   public int ShotDamage;
   public AudioSource source;
   // Update is called once per frame
   void Update()
   {
      if(cooldownTimer > 0)
      {
         cooldownTimer -= Time.deltaTime;
      }
      else
      {
         if(Input.GetButtonDown("Fire") || Input.GetButton("Fire"))
         {
            GameObject shot = Instantiate(ShotPrefab, this.transform.position, Quaternion.identity, ShotParent);
            shot.GetComponent<ShotMove>().Initialize(LastDirectionWasLeft);
            shot.GetComponent<ShotDamage>().Damage = ShotDamage;
            cooldownTimer = Cooldown;
            source.Play();
         }
      }

      //Save the last pressed diretion but don't change if standing still
      float direction = Input.GetAxis("Horizontal");
      if(direction < 0)
      {
         LastDirectionWasLeft = true;
      }
      else if(direction > 0)
      {
         LastDirectionWasLeft = false;
      }


   }

}
