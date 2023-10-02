using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotDamage : MonoBehaviour
{
   public int Damage;
   public AudioSource Sound;
   private void OnCollisionEnter2D(Collision2D collision)
   {
      if (collision.gameObject.CompareTag("Enemy"))
      {
         collision.gameObject.GetComponent<EnemyHealth>().TakeDamage(Damage);
         Sound.Play();
      }
      GetComponent<SpriteRenderer>().enabled = false;
      Destroy(this.gameObject, Sound.clip.length);
   }
}
