using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;

public class Shape : MonoBehaviour
{
   public bool placed;
   public GameObject ShapePrefab;

   // Start is called before the first frame update
   void Start()
   {
      placed = false;
      BoxManager.Instance.OnBoxComplete.AddListener(RemoveShape);
   }

   // Update is called once per frame
   void Update()
   {
      if (!placed)
      {
         Vector3 position = Camera.main.ScreenToWorldPoint(Input.mousePosition) + new Vector3(.5f, .5f, 0);
         this.transform.position = new Vector3(Mathf.FloorToInt(position.x), Mathf.FloorToInt(position.y), 0);
         if (Input.GetMouseButtonDown(1))
         {
            this.transform.rotation = this.transform.rotation * Quaternion.Euler(0, 0, -90);
         }
         if (Input.GetMouseButtonDown(0) && CanPlaceHere())
         {
            PlaceHere();
            //TODO: Actual selection for new tiles
            Instantiate(ShapePrefab, Vector3.zero, Quaternion.identity, this.transform.parent);
         }
      }
   }

   private void PlaceHere()
   {
      foreach (ShapeSquare square in transform.GetComponentsInChildren<ShapeSquare>())
      {
         square.PlaceHere();
      }
      placed = true;
   }

   private bool CanPlaceHere()
   {
      foreach (ShapeSquare square in transform.GetComponentsInChildren<ShapeSquare>())
      {
         if (!square.CanBePlaced())
         {
            return false;
         }
      }
      return true;
   }

   public void RemoveShape()
   {
      //TODO: This should not be needed once placing shapes doesnt spawn new ones
      if (placed)
      {
         BoxManager.Instance.OnBoxComplete.RemoveListener(RemoveShape);
         Destroy(this.gameObject);
      }
   }
}
