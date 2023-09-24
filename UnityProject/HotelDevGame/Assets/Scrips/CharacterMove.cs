using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;

public class CharacterMove : MonoBehaviour
{
    public float movementSpeed = 1.0f;
    public int all1;
    public int all2;
    public Transform playerTransform;

    private Vector2 vectorMovement;

    void Start()
    {

    }


    void FixedUpdate()
    {
        if (UnityEngine.Input.GetKey("w"))
        {
            Debug.Log("Going Up");

            all1 = -2;
            all2 = 1;
            
        }
        if (UnityEngine.Input.GetKey("s"))
        {
            Debug.Log("Going Down");

            all1 = 2;
            all2 = -1;

        }
        if (UnityEngine.Input.GetKey("a"))
        {
            Debug.Log("Going Left");

            all1 = -2;
            all2 = -1;

        }
        if (UnityEngine.Input.GetKey("d"))
        {
            Debug.Log("Going Right");

            all1 = 2;
            all2 = 1;

        }
        else
        {
            all1 = 0;
            all2 = 0;
        }

        vectorMovement = new Vector2(all1, all2);

        playerTransform.Translate(vectorMovement * movementSpeed * Time.deltaTime);
    }
}
