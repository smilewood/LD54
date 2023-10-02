using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class ShotMove : MonoBehaviour
{
   public float Speed;

   private bool left;
   private Rigidbody2D rb;

   private void Start()
   {
      rb = GetComponent<Rigidbody2D>();
   }

   public void Initialize(bool left)
   {
      this.left = left;
   }

   private void Update()
   {
      float delta = Speed * (left ? -1 : 1) * Time.deltaTime;
      rb.MovePosition(new Vector2(rb.position.x + delta, rb.position.y));
   }

}
