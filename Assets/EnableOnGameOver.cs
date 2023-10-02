using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableOnGameOver : MonoBehaviour
{
   public GameObject ToEnable;
    // Start is called before the first frame update
    void Start()
    {
      PlayerHealth.OnPlayerDeath.AddListener(OnGameOver);
    }

   private void OnGameOver()
   {
      ToEnable.SetActive(true);
   }
}
