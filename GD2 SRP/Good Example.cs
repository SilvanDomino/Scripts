using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private InputManager inputManager;
    [SerializeField]
    private float movementSpeed = 5;


    void Start()
    {
		//check if the inputmanager is present. If it's not, add it.
		//I was too lazy to add it in the unity editor, and this looks pretty nice
        //copy paste from camerarotation
		if (!(inputManager = this.GetComponent<InputManager>()))
		{
			inputManager = this.gameObject.AddComponent<InputManager>();
		}
    }


    void Update () 
    {
        
        if(true){
            
        }
        Vector3 movement = new Vector3();
        if (inputManager.Up())
        {
            movement += this.transform.forward;
        }
        if (inputManager.Down())
		{
            movement -= this.transform.forward;
		}
        if (inputManager.Right())
		{
            movement += this.transform.right;
		}
		if (inputManager.Left())
		{
            movement -= this.transform.right;
		}
        movement.Normalize();
        this.transform.position += (movement * Time.deltaTime * movementSpeed);
	}
}
