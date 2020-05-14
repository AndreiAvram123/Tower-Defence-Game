using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneLoader : MonoBehaviour
{
  

    // Start is called before the first frame update
    public void StartGame()
    {
       
        SceneManager.LoadScene(1);
       
    }
    public void GoToMainMenu()
    {
        //destroy all ScoreBoard objects
        foreach(ScoreBoard scoreBoard in FindObjectsOfType<ScoreBoard>())
        {
            Destroy(scoreBoard);
        }
        SceneManager.LoadScene(1);

    }
    public void StartMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void EndGame()
    {
        SceneManager.LoadScene(2);
    }
    
}
