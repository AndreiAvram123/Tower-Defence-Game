using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameOverUIHandler : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] TextMeshProUGUI bestScore;
    
    void Start()
    {
        bestScore.text = FindObjectOfType<ScoreBoard>().GetFinalScore().ToString();
    }

   public void GoToMainMenu()
    {
        FindObjectOfType<SceneLoader>().StartMainMenu();
    }
    public void ExitGame()
    {
        FindObjectOfType<SceneLoader>().ExitGame();
    }
}
