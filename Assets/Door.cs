using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
   private SpriteRenderer _renderer;
   private BoxCollider2D _collider;
   public bool Active;
   private KeyTracker keys;

   // Start is called before the first frame update
   void Start()
   {
      _renderer = GetComponent<SpriteRenderer>();
      _collider = GetComponent<BoxCollider2D>();
      if (!Active)
      {
         _renderer.enabled = false;
         _collider.enabled = false;
      }
      keys = GameObject.Find("Keys").GetComponent<KeyTracker>();
   }

   public bool TriggerDoor()
   {
      if (Active)
      {
         return false;
      }
      StartCoroutine(EnableDoor());

      return true;
   }


   private IEnumerator EnableDoor()
   {
      //Hardcoded time and flash rate, maybe do better code sometime
      _renderer.color = new Color(_renderer.color.r, _renderer.color.g, _renderer.color.b, .5f);
      for (int i = 0; i < 5; ++i)
      {
         _renderer.enabled = true;
         yield return new WaitForSeconds(.5f);
         _renderer.enabled = false;
         yield return new WaitForSeconds(.5f);
      }
      _renderer.color = new Color(_renderer.color.r, _renderer.color.g, _renderer.color.b, 1f);
      _renderer.enabled = true;
      _collider.enabled = true;
      Active = true;
   }
   private void OnCollisionEnter2D(Collision2D collision)
   {
      if (collision.gameObject.CompareTag("Player") && keys.UseKey())
      {
         this.Active = false;
         _renderer.enabled = false;
         _collider.enabled = false;
      }
   }
}
