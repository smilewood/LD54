using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformerController : MonoBehaviour
{
   private Rigidbody2D rb;
   public float JumpPower;
   public float Speed;
   public float turnSpeed;

   public bool CanJump;
   public float CoyoteTime;
   private Coroutine coyoteTime;
   public AudioSource JumpSource;
   // Start is called before the first frame update
   void Start()
   {
      rb = GetComponent<Rigidbody2D>();
   }

   // Update is called once per frame
   void Update()
   {
      if (Input.GetButtonDown("Jump"))
      {
         //jump
         if (CanJump)
         {
            rb.velocity = new Vector2(rb.velocity.x, JumpPower);
            JumpSource.Play();
            CanJump = false;
         }
      }
      if (Input.GetButton("Jump"))
      {
         rb.gravityScale = 4;
      }
      else
      {
         rb.gravityScale = 10;
      }

      float targetVelocity = Input.GetAxis("Horizontal") * Speed;
      float frameVelocity = targetVelocity < 0 ?
         Mathf.Max(targetVelocity, rb.velocity.x + targetVelocity * turnSpeed) :
         Mathf.Min(targetVelocity, rb.velocity.x + targetVelocity * turnSpeed);
      rb.velocity = new Vector2(frameVelocity, rb.velocity.y);
   }

   private void OnTriggerEnter2D(Collider2D collision)
   {
      if (collision.gameObject.CompareTag("Ground"))
      {
         if (coyoteTime != null)
         {
            StopCoroutine(coyoteTime);
         }
         CanJump = true;
      }
   }
   private void OnTriggerExit2D(Collider2D collision)
   {
      if (collision.gameObject.CompareTag("Ground"))
      {
         coyoteTime = StartCoroutine(CoyoteTimer());
      }
   }

   private IEnumerator CoyoteTimer()
   {
      yield return new WaitForSeconds(CoyoteTime);
      CanJump = false;
   }
}
