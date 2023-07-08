using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;



public class GameController : MonoBehaviour
{

    public GameObject prefab;
    public float speed;
    public GameObject StartPosition;
    private Vector2 brickPosition;
    private GameObject[] brick = new GameObject[4];




    void Start()
    {
        BrickT();
        InvokeRepeating("MoveDown", 0, speed);
    }

    void Update()
    {
        Rotate();
        MoveSide();
    }




    void MoveDown()
    {
        brickPosition.y -= 1;
        foreach (GameObject g in brick)
        {
            g.transform.Translate(Vector3.down);
        }
    }

    void MoveSide()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            brickPosition.x -= 1;
            foreach (GameObject g in brick) g.transform.Translate(Vector2.left);
        }
        else if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            brickPosition.x += 1;
            foreach (GameObject g in brick) g.transform.Translate(Vector2.right);
        }
    }

    void Rotate()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            foreach (GameObject g in brick)
            {
                Vector3 translationVector = new Vector3(0, 0, 0);
                translationVector.x = (brickPosition.x - g.transform.position.x) + (g.transform.position.y - brickPosition.y);
                translationVector.y = (brickPosition.y - g.transform.position.y) + (brickPosition.x - g.transform.position.x);
                g.transform.Translate(translationVector);
            }
        }
    }





    void BrickCube()
    {
        brickPosition = StartPosition.transform.position;
        Vector2 tmp = brickPosition;
        tmp.x += 0.5f;
        tmp.y += 0.5f;
        brick[0] = (GameObject)Instantiate(prefab, tmp, prefab.transform.rotation);
        tmp.y -= 1;
        brick[1] = (GameObject)Instantiate(prefab, tmp, prefab.transform.rotation);
        tmp.x -= 1;
        brick[2] = (GameObject)Instantiate(prefab, tmp, prefab.transform.rotation);
        tmp.y += 1;
        brick[3] = (GameObject)Instantiate(prefab, tmp, prefab.transform.rotation);
    }

    void BrickLine()
    {
        brickPosition = StartPosition.transform.position;
        Vector2 tmp = brickPosition;
        tmp.y -= 0.5f;
        tmp.x += 1.5f;
        for (int i = 0; i < 4; i++)
        {
            brick[i] = (GameObject)Instantiate(prefab, tmp, prefab.transform.rotation);
            tmp.x -= 1;
        }
    }

    void BrickT()
    {
        brickPosition = StartPosition.transform.position;
        brickPosition.y -= 0.5f;
        brickPosition.x += 0.5f;
        Vector2 tmp = brickPosition;
        brick[0] = (GameObject)Instantiate(prefab, tmp, prefab.transform.rotation);
        tmp.y += 1;
        brick[1] = (GameObject)Instantiate(prefab, tmp, prefab.transform.rotation);
        tmp.y -= 1;
        tmp.x += 1;
        brick[2] = (GameObject)Instantiate(prefab, tmp, prefab.transform.rotation);
        tmp.x -= 2;
        brick[3] = (GameObject)Instantiate(prefab, tmp, prefab.transform.rotation);
    }

    void BrickLeftL()
    {
        brickPosition = StartPosition.transform.position;
        brickPosition.y -= 0.5f;
        brickPosition.x += 0.5f;
        Vector2 tmp = brickPosition;
        brick[0] = (GameObject)Instantiate(prefab, tmp, prefab.transform.rotation);
        tmp.x += 1;
        brick[1] = (GameObject)Instantiate(prefab, tmp, prefab.transform.rotation);
        tmp.x -= 2;
        brick[2] = (GameObject)Instantiate(prefab, tmp, prefab.transform.rotation);
        tmp.y += 1;
        brick[3] = (GameObject)Instantiate(prefab, tmp, prefab.transform.rotation);
    }

    void BrickRightL()
    {
        brickPosition = StartPosition.transform.position;
        brickPosition.y -= 0.5f;
        brickPosition.x += 0.5f;
        Vector2 tmp = brickPosition;
        brick[0] = (GameObject)Instantiate(prefab, tmp, prefab.transform.rotation);
        tmp.x -= 1;
        brick[1] = (GameObject)Instantiate(prefab, tmp, prefab.transform.rotation);
        tmp.x += 2;
        brick[2] = (GameObject)Instantiate(prefab, tmp, prefab.transform.rotation);
        tmp.y+= 1;
        brick[3] = (GameObject)Instantiate(prefab, tmp, prefab.transform.rotation);
    }

    void BrickLeftS()
    {
        brickPosition = StartPosition.transform.position;
        brickPosition.y -= 0.5f;
        brickPosition.x += 0.5f;
        Vector2 tmp = brickPosition;
        brick[0] = (GameObject)Instantiate(prefab, tmp, prefab.transform.rotation);
        tmp.x += 1;
        brick[1] = (GameObject)Instantiate(prefab, tmp, prefab.transform.rotation);
        tmp.x -= 1;
        tmp.y += 1;
        brick[2] = (GameObject)Instantiate(prefab, tmp, prefab.transform.rotation);
        tmp.x -= 1;
        brick[3] = (GameObject)Instantiate(prefab, tmp, prefab.transform.rotation);
    }

    void BrickRightS()
    {
        brickPosition = StartPosition.transform.position;
        brickPosition.y -= 0.5f;
        brickPosition.x += 0.5f;
        Vector2 tmp = brickPosition;
        brick[0] = (GameObject)Instantiate(prefab, tmp, prefab.transform.rotation);
        tmp.x -= 1;
        brick[1] = (GameObject)Instantiate(prefab, tmp, prefab.transform.rotation);
        tmp.x += 1;
        tmp.y += 1;
        brick[2] = (GameObject)Instantiate(prefab, tmp, prefab.transform.rotation);
        tmp.x += 1;
        brick[3] = (GameObject)Instantiate(prefab, tmp, prefab.transform.rotation);
    }



}
