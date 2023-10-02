using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HighScoreTextUpdate : MonoBehaviour
{
   private void OnEnable()
   {
      GetComponent<TMP_Text>().text = GameObject.Find("HighScore").GetComponent<HighscoreTracker>().HighScore.ToString("D8");     
   }
}
