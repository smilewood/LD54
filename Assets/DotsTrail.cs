using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DotsTrail : MonoBehaviour
{
   public GameObject Dot;
   public GameObject Parent;
   public float Interval;
   // Start is called before the first frame update
   void Start()
   {
      if(Parent == null)
      {
         Parent = GameObject.Find("Dots");
      }
      StartCoroutine(Dotty());
   }

   private IEnumerator Dotty()
   {
      while (true)
      {
         yield return new WaitForSeconds(Interval);
         Instantiate(Dot, this.transform.position, Quaternion.identity, Parent.transform);
      }
   }
}
