using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{

    public Text highScore;



    // Start is called before the first frame update
    void Start()
    {
        if (SceneManager.GetSceneByName("GameScene").name == "GameScene")
            SceneManager.UnloadScene("GameScene");
        if (SceneManager.GetSceneByName("RetryTransition").name == "RetryTransition")
            SceneManager.UnloadScene("RetryTransition");

        HighScoreFunction();
    }

    // Update is called once per frame
    void Update()
    {
        
    }






    void HighScoreFunction()
    {
        highScore.text = PlayerPrefs.GetInt("HighScore").ToString();
    }



    public void PlayButton()
    {
        SceneManager.LoadScene("GameScene", LoadSceneMode.Single);
    }


    public void ExitButton()
    {
        Application.Quit();
    }

}
