using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DoorController : MonoBehaviour
{
   public List<Door> Doors;

   public AudioSource source;
   private void Start()
   {
      Doors = GetComponentsInChildren<Door>().ToList();
      //StartCoroutine(CycleDoors());
   }

   public void TriggerRandomDoor()
   {
      List<Door> inactiveDoors = Doors.Where(d => !d.Active).ToList();
      if (inactiveDoors.Any())
      {
         source.Play();
         inactiveDoors[Random.Range(0, inactiveDoors.Count)].TriggerDoor();
      }
   }


   private IEnumerator CycleDoors()
   {
      while(Doors.Any(d => !d.Active))
      {
         yield return new WaitForSeconds(10);
         TriggerRandomDoor();
      }
   }

}
