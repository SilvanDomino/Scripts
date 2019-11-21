using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveScript : MonoBehaviour
{
    public float speed;

    void Start()
    {
        Debug.Log("Hello World");
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            transform.position = transform.position + new Vector3(speed, 0, 0);
        }
        
    }
}