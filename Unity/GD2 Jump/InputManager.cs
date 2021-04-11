using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour {

    public bool Jump(){
        return Input.GetButton("Jump");
    }
    public bool JumpDown()
    {
        return Input.GetButtonDown("Jump");
    }
}
