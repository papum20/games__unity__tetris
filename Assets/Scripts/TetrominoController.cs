using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;



public class TetrominoController : MonoBehaviour
{

    private float previousTime = 0;
    public float speed;

    public static int width = 10, height = 20;

    public Vector3 rotationPoint;

    private static Transform[,] grid = new Transform[height, width];

    private TetrominoSpawner spawner;





    // Start is called before the first frame update
    void Start()
    {
        spawner = GameObject.FindGameObjectWithTag("spawner").GetComponent<TetrominoSpawner>();
        speed = spawner.GetSpeed();
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.position += new Vector3(-1, 0, 0);
            if(!Valid()) transform.position -= new Vector3(-1, 0, 0);
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            transform.position += new Vector3(1, 0, 0);
            if (!Valid()) transform.position -= new Vector3(1, 0, 0);
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            transform.RotateAround(transform.TransformPoint(rotationPoint), new Vector3(0,0,1), -90);
            if(!Valid()) transform.RotateAround(transform.TransformPoint(rotationPoint), new Vector3(0, 0, 1), 90);
        }

        if (Time.time - previousTime >= (Input.GetKey(KeyCode.DownArrow)? speed/10 : speed) )
        {
            transform.position += new Vector3(0, -1, 0);
            previousTime = Time.time;

            if (!Valid())
            {
                transform.position -= new Vector3(0, -1, 0);
                if (!checkGameOver())
                {
                    AddToGrid();
                    DeleteLines();
                    this.enabled = false;
                    FindObjectOfType<TetrominoSpawner>().NewTetromino();
                }
                else
                {
                    PlayerPrefs.SetInt("HighScore", (int)Mathf.Max(PlayerPrefs.GetInt("HighScore"), spawner.getScoreNumber()) );
                    spawner.setGameOverPanel();
                    spawner.setRetryButton();
                }
            }

        }

    }







    bool Valid()
    {
        foreach(Transform children in transform)
        {
            int tmpX = Mathf.RoundToInt(children.transform.position.x);
            int tmpY = Mathf.RoundToInt(children.transform.position.y);

            if (tmpX < 0 || tmpX >= width || tmpY < 0 || (tmpY < height && grid[tmpY,tmpX] != null)) return false;
        }

        return true;
    }


    bool checkGameOver()
    {
        foreach(Transform child in transform)
            if (child.position.y >= height) return true;

        return false;
    }







    void AddToGrid()
    {
        foreach(Transform child in transform)
        {
            int tmpX = Mathf.RoundToInt(child.transform.position.x);
            int tmpY = Mathf.RoundToInt(child.transform.position.y);
            grid[tmpY, tmpX] = child;
        }
    }





    void DeleteLines()
    {
        for(int y = height-1; y >= 0; y--)
        {
            if(CheckLine(y))
            {
                spawner.IncreaseScorePanel();

                //DESTROY LINE
                for(int x = 0; x < width; x++) {
                    Destroy(grid[y, x].gameObject);
                    grid[y, x] = null;
                }
                
                //MOVE DOWN
                for(int y1 = y+1; y1 < height; y1++) {
                    for (int x = 0; x < width; x++) {
                        if (grid[y1, x] != null)
                        {
                            grid[y1 - 1, x] = grid[y1, x];
                            grid[y1, x] = null;
                            grid[y1 - 1, x].transform.position += new Vector3(0, -1, 0);
                        }
                    }
                }


            }
        }


    }

    bool CheckLine(int y)
    {
        for(int x = 0; x < width; x++){
            if (grid[y, x] == null) return false;
        }
        return true;
    }



}
