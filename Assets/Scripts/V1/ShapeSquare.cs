using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShapeSquare : MonoBehaviour
{

   public Shape ParentShape;

   private void Start()
   {
      this.ParentShape = this.gameObject.GetComponentInParent<Shape>();
      if (ParentShape == null)
      {
         Debug.LogError("Shape has no parent");
      }
   }

   internal bool CanBePlaced()
   {
      Vector2Int adjustedPos = new Vector2Int((int)(this.transform.position.x + .5), (int)(this.transform.position.y + .5));
      bool canBePlaced = !BoxManager.Instance.ActiveBox.IsSquareFilled(adjustedPos);
      Debug.Log($"Try to place square at {adjustedPos}: CanBePlaced: {canBePlaced}");
      return canBePlaced;
   }

   internal void PlaceHere()
   {
      BoxManager.Instance.ActiveBox.FillSquare(new Vector2Int((int)this.transform.position.x, (int)this.transform.position.y), this);
   }
}
