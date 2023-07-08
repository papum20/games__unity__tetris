using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;




public class TetrominoSpawner : MonoBehaviour
{

    public GameObject[] Tetrominoes;
    private float speed = 0.8f;

    private int nextTetrominoIndex;
    private Vector3 nextTetrominoPosition;
    private GameObject nextTetromino;
    private GameObject currentTetromino;

    public GameObject gameOverPanel;
    public GameObject retryButton;
    public Text scorePanel;
    private int scoreNumber = 0;

    public GameObject optionsCanvas;
    public Text speedValue;
    public Slider speedSlider;


    


    private void Awake()
    {
        gameOverPanel.SetActive(false);
        retryButton.SetActive(false);

        optionsCanvas.SetActive(false);

        speed = PlayerPrefs.GetFloat("Speed");
        if (speed == 0) speed = 0.8f;
        nextTetrominoPosition = GameObject.FindGameObjectWithTag("nextPos").transform.position;
    }


    // Start is called before the first frame update
    void Start()
    {
        currentTetromino = (GameObject)Instantiate(Tetrominoes[Random.Range(0, Tetrominoes.Length)], transform.position, Quaternion.identity);

        nextTetrominoIndex = Random.Range(0, Tetrominoes.Length);
        Vector3 tmpPos = nextTetrominoPosition;
        if (nextTetrominoIndex == 0)
            tmpPos += new Vector3(0.5f, -0.5f, 0);
        else if (nextTetrominoIndex == 1)
            tmpPos += new Vector3(0.5f, 0, 0);
        nextTetromino = (GameObject)Instantiate(Tetrominoes[nextTetrominoIndex], tmpPos, Quaternion.identity);
        nextTetromino.GetComponent<TetrominoController>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {

    }



    public void NewTetromino()
    {
        currentTetromino = (GameObject)Instantiate(Tetrominoes[nextTetrominoIndex], transform.position, Quaternion.identity);

        nextTetrominoIndex = Random.Range(0, Tetrominoes.Length);
        Destroy(nextTetromino);
        Vector3 tmpPos = nextTetrominoPosition;
        if (nextTetrominoIndex == 0)
            tmpPos += new Vector3(0.5f, -0.5f, 0);
        else if (nextTetrominoIndex == 1)
            tmpPos += new Vector3(0.5f, 0, 0);
        nextTetromino = (GameObject)Instantiate(Tetrominoes[nextTetrominoIndex], tmpPos, Quaternion.identity);
        nextTetromino.GetComponent<TetrominoController>().enabled = false;
    }






    public float GetSpeed()
    {
        return speed;
    }


    public void setGameOverPanel()
    {
        gameOverPanel.SetActive(true);
    }
    public void setRetryButton()
    {
        retryButton.SetActive(true);
    }
    public void IncreaseScorePanel()
    {
        scoreNumber++;
        scorePanel.text = scoreNumber.ToString();
    }
    public int getScoreNumber()
    {
        return scoreNumber;
    }





    public void Retry()
    {
        SceneManager.LoadScene("RetryTransition", LoadSceneMode.Single);
    }

    public void MainMenuFunction()
    {
        SceneManager.LoadScene("MenuScene", LoadSceneMode.Single);
    }

    public void OptionsEnter()
    {
        currentTetromino.GetComponent<TetrominoController>().enabled = false;
        optionsCanvas.SetActive(true);
        speedSlider.value = (int)(speed * 10);
    }

    public void OptionsExit()
    {
        optionsCanvas.SetActive(false);
        currentTetromino.GetComponent<TetrominoController>().enabled = true;
    }

    public void SpeedSlider(float newSpeed)
    {
        speed = newSpeed/10f;
        currentTetromino.GetComponent<TetrominoController>().speed = speed;      
        speedValue.text = speed.ToString() + "s";
        PlayerPrefs.SetFloat("Speed", speed);
    }


}
