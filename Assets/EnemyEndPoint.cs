using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyEndPoint : MonoBehaviour
{
   private DoorController doors;

   // Start is called before the first frame update
   void Start()
   {
      doors = GameObject.Find("Doors").GetComponent<DoorController>();
   }

   // Update is called once per frame
   void Update()
   {

   }

   private void OnCollisionEnter2D(Collision2D collision)
   {
      Debug.Log("CollisionEnter");
      if (collision.gameObject.CompareTag("Enemy"))
      {
         //Enemy made it to the end
         doors.TriggerRandomDoor();

         Destroy(collision.gameObject);
      }
   }

}
