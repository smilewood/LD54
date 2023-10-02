using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterTime : MonoBehaviour
{
   public float Time;
   // Start is called before the first frame update
   void Start()
   {
      StartCoroutine(timer());
   }
   private IEnumerator timer()
   {
      yield return new WaitForSeconds(Time);
      Destroy(this.gameObject);
   }
}
