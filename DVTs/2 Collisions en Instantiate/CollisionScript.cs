using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Has Collision with " + collision.);
    }
}
