using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class ScoreEvent : UnityEvent<int> { }

public class ScoreTracker : MonoBehaviour
{
   private static ScoreEvent _onScoreEvent;
   public static ScoreEvent OnScoreEvent
   {
      get
      {
         _onScoreEvent ??= new ScoreEvent();
         return _onScoreEvent;
      }
   }
   public TMP_Text GameOverText;

   public int CurrentScore;
   private TMP_Text text;
   // Start is called before the first frame update
   void Start()
   {
      text = this.gameObject.GetComponent<TMP_Text>();
      CurrentScore = 0;
      UpdateScore(0);
      EnemyHealth.OnEnemyDeath.AddListener(UpdateScore);
      OnScoreEvent.AddListener(UpdateScore);
   }



   private void UpdateScore(int addedScore)
   {
      CurrentScore += addedScore;
      GameObject.Find("HighScore").GetComponent<HighscoreTracker>().HighScore = CurrentScore;
      text.text = CurrentScore.ToString("D8");
      if(!(GameOverText == null))
      {
         GameOverText.text = CurrentScore.ToString("D8");
      }
   }
}
