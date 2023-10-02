using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CompleteBoxEvent : UnityEvent { }
public class BoxManager : MonoBehaviour
{
   #region singleton
   private static BoxManager _instance;
   public static BoxManager Instance
   {
      get 
      {
         return _instance;
      }
      private set
      {
         _instance = value;
      }
   }
   //private BoxManager() { }

   #endregion singleton

   public List<GameObject> Boxes;
   public CompleteBoxEvent OnBoxComplete;

   // Start is called before the first frame update
   void Awake()
   {
      if(Instance == null)
      {
         Instance = this;
      }
      else
      {
         Debug.LogError("BoxManager already existed, why are we creating a new one?");
      }
      OnBoxComplete = new CompleteBoxEvent();
   }

   public Box ActiveBox;

   public void FinishBox()
   {
      //TODO: Score the box
      Destroy(ActiveBox.gameObject);
      OnBoxComplete.Invoke();
      ActiveBox = Instantiate(Boxes[Random.Range(0, Boxes.Count)], this.transform).GetComponent<Box>();
   }
}
