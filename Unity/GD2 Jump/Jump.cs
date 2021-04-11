using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour {

    [SerializeField]
    private InputManager input;
    private Rigidbody _rigidbody;
    [SerializeField]
    private float maxJumpHeight = 2;
    [SerializeField]
    private float jumpPower = 20;

	void Start()
	{
        _rigidbody = GetComponent<Rigidbody>();
	}

	void Update () {
        if(input.JumpDown()){
            StartCoroutine(JumpRoutine());
        }
	}

    IEnumerator JumpRoutine(){
        //create values for the current jump. These can change mid jump
        float maxHeight = transform.position.y + maxJumpHeight;
        float currentJumpPower = jumpPower;
        Vector3 v = _rigidbody.velocity;
        //As long as either jump button is pressed or maxheight isnt't reached, the player can go upper
        while(input.Jump() && transform.position.y < maxHeight){
            v = _rigidbody.velocity;
            _rigidbody.velocity = new Vector3(v.x, jumpPower, 0);
            yield return null;
        }
        //This cuts down the velocity so the player doesn't go way up in the air.
        _rigidbody.velocity = new Vector3(v.x, v.y * 0.8f, 0);
    }
}
