using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.CompilerServices;
using UnityEditor;
using UnityEngine;
using UnityEngine.TextCore.LowLevel;

public class Box : MonoBehaviour
{
   public Vector2Int Size;
   public Vector2Int Offset;

   private Grid grid;

   private void Start()
   {
      grid = new Grid(Size);
      
   }

   public Vector2Int OffsetLocation(Vector2Int initialLocation)
   {
      return new Vector2Int(initialLocation.x + Offset.x, initialLocation.y + Offset.y);
   }

   public bool IsSquareFilled(Vector2Int location)
   {
      Vector2Int adjustedLoc = OffsetLocation(location);
      if(!adjustedLoc.x.InRange(0, Size.x) || !adjustedLoc.y.InRange(0, Size.y))
      {
         //Any square outside of bounds is considered filled
         return true;
      }

      bool valid = grid[adjustedLoc].Valid;
      bool occupied = grid[adjustedLoc].Occupant != null;

      Debug.Log($"Grid {adjustedLoc} Occupied: {occupied}");
      return !valid || occupied;
   }

   public void FillSquare(Vector2Int location, ShapeSquare square)
   {
      grid[OffsetLocation(location)].Occupant = square;
   }

   private void OnDrawGizmos()
   {
      if (Application.isPlaying)
      {

         for (int i = -Offset.x; i < Size.x - Offset.x; ++i)
         {
            for (int j = -Offset.y; j < Size.y - Offset.y; ++j)
            {
               //Handles.Label(new Vector3(i, j, 0), $"{i}, {j} : {grid[OffsetLocation(new Vector2Int(i, j))].Occupant != null}");
            }
         }
      }
   }


   [System.Diagnostics.DebuggerDisplay("{Valid}, {Occupant}")]
   private class BoxSquare
   {
      //used for non-rect boxes eventually
      public bool Valid;
      //what shape part is in the square
      public ShapeSquare Occupant;
   }

   private class Grid
   {
      private BoxSquare[,] grid;

      public Grid(Vector2Int size)
      {
         grid = new BoxSquare[size.x, size.y];

         for (int i = 0; i < size.x; ++i)
         {
            for (int j = 0; j < size.y; ++j)
            {
               grid[i, j] = new BoxSquare() { Valid = true };
            }
         }
      }

      public BoxSquare this[Vector2Int index]
      {
         get
         {
            return grid[index.x, index.y];
         }
         set
         {
            grid[index.x, index.y] = value;
         }
      }
   }

}
