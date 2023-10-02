using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePause : MonoBehaviour
{
   public GameObject PauseMenu;

   // Start is called before the first frame update
   void Start()
   {
      PlayerHealth.OnPlayerDeath.AddListener(Pause);
   }


   // Update is called once per frame
   void Update()
   {
      if (Input.GetButtonDown("Pause"))
      {
         Pause();
      }
   }

   public void Pause()
   {
      Time.timeScale = Time.timeScale == 0 ? 1 : 0;
      PauseMenu.SetActive(Time.timeScale == 0);
   }
}
