using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyWander : MonoBehaviour
{
   public bool goingLeft;
   private Rigidbody2D rb;
   public float Speed;
   public float turnSpeed;
   private float width;

   // Start is called before the first frame update
   void Start()
   {
      rb = GetComponent<Rigidbody2D>();
      width = transform.localScale.x;
      bounce = Random.Range(0, 2);
   }

   // Update is called once per frame
   void Update()
   {

      float targetVelocity = (goingLeft ? -1 : 1) * Speed;
      float frameVelocity = targetVelocity < 0 ?
               Mathf.Max(targetVelocity, rb.velocity.x + targetVelocity * turnSpeed) :
               Mathf.Min(targetVelocity, rb.velocity.x + targetVelocity * turnSpeed);
      rb.velocity = new Vector2(frameVelocity, rb.velocity.y);
   }

   private void FixedUpdate()
   {
      CheckForTurn();

   }

   bool hasLeftGround, hasRightGround;
   public int bounce;
   private void CheckForTurn()
   {
      Ray2D leftFront = new Ray2D(new Vector2(this.transform.position.x, this.transform.position.y + .1f), Vector2.left);
      Debug.DrawRay(leftFront.origin, leftFront.direction * .1f, Color.red);
      RaycastHit2D hit = Physics2D.Raycast(leftFront.origin, leftFront.direction, .1f);
      if (hit.collider != null)
      {
         if (hit.collider.gameObject.CompareTag("Ground"))
         {
            goingLeft = false;
         }
      }

      Ray2D rightFront = new Ray2D(new Vector2(this.transform.position.x + width, this.transform.position.y + .1f), Vector2.right);
      Debug.DrawRay(rightFront.origin, rightFront.direction * .1f, Color.red);
      hit = Physics2D.Raycast(rightFront.origin, rightFront.direction, .1f);
      if (hit.collider != null)
      {
         if (hit.collider.gameObject.CompareTag("Ground"))
         {
            goingLeft = true;
         }
      }


      Ray2D leftDown = new Ray2D(new Vector2(this.transform.position.x, this.transform.position.y + .4f), Vector2.down);
      Debug.DrawRay(leftDown.origin, leftDown.direction * .5f, Color.green);
      RaycastHit2D hitLD = Physics2D.Raycast(leftDown.origin, leftDown.direction, .5f);
      if (hitLD.collider != null)
      {
         if (hitLD.collider.gameObject.CompareTag("Ground"))
         {
            hasLeftGround = true;
         }
      }

      Ray2D rightDown = new Ray2D(new Vector2(this.transform.position.x + width, this.transform.position.y + .4f), Vector2.down);
      Debug.DrawRay(rightDown.origin, rightDown.direction * .5f, Color.green);
      RaycastHit2D hitRD = Physics2D.Raycast(rightDown.origin, rightDown.direction, .5f);
      if (hitRD.collider != null)
      {
         if (hitRD.collider.gameObject.CompareTag("Ground"))
         {
            hasRightGround = true;
         }
      }


      if (hitLD.collider == null && hasLeftGround)
      {
         //Had ground last frame, going over an dege.
         hasLeftGround = false;
         if (hasRightGround)
         {
           // Debug.Log("Going over edge heading left");
            //bounce = bounce < 2 ? ++bounce : 0;
            //if (bounce != 0)
            //{
            //   goingLeft = false;
            //}
            goingLeft = Random.Range(0, 2) == 0;
         }
      }

      if (hitRD.collider == null && hasRightGround)
      {
         //Had ground last frame, going over an dege.
         hasRightGround = false;
         if (hasLeftGround)
         {
            //Debug.Log("Going over edge heading right");
            bounce = bounce < 2 ? ++bounce : 0;
            if (bounce != 0)
            {
               goingLeft = !(Random.Range(0, 2) == 0);
            }
         }

      }
   }

   //private bool grounded;
   //private void OnTriggerEnter2D(Collider2D collision)
   //{
   //   if (collision.gameObject.CompareTag("Ground"))
   //   {
   //      grounded = true;
   //   }
   //}

   //private void OnTriggerExit2D(Collider2D collision)
   //{
   //   if (collision.gameObject.CompareTag("Ground"))
   //   {
   //      grounded = false;
   //   }
   //}
}
