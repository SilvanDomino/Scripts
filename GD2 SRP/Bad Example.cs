using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

  private Animator animator;
	private new Rigidbody2D rigidbody2D;
  private Vector3 inputMovementVector = Vector3.zero;
	private Gravity gravity;

  [SerializeField]
  private float movementSpeed = 50;
	public bool canJump = false;
	public bool isJumpReady = true;

	[SerializeField]
	private Vector2 jumpVector = new Vector2(0, 10);



	void Start () {
    if(!(animator = this.gameObject.GetComponent<Animator>()))
    {
        animator = this.transform.GetChild(0).gameObject.GetComponent<Animator>();
    }
		gravity = this.GetComponent<Gravity> ();
		this.rigidbody2D = this.GetComponent<Rigidbody2D> ();
	}

	// Update is called once per frame
	void Update () {

		canJump = gravity.isGrounded;

    inputMovementVector = Vector3.zero;
    PlayerInput();

		if (canJump && isJumpReady &&Input.GetButtonDown("Jump"))
		{
			canJump = false;
			isJumpReady = false;
			StartCoroutine ("Jump");
      StartCoroutine("SetJumpReady");
		}

    animator.SetBool("IsRunning", Mathf.Pow(inputMovementVector.x,2) > Mathf.Pow(movementSpeed * 0.5f  * Time.deltaTime, 2)); // pretty way
    if (inputMovementVector.x < 0)
    {
        this.gameObject.transform.localScale = new Vector3(-1, 1, 1);
    }
    if (inputMovementVector.x > 0)
    {
        this.gameObject.transform.localScale = new Vector3(1, 1, 1);
    }

    this.gameObject.transform.position += inputMovementVector;
  }


	private void PlayerInput()
  {
      if (Input.GetAxis("Horizontal") > 0.01f)
      {
          inputMovementVector += new Vector3(movementSpeed * Time.deltaTime, 0);
      }
      if (Input.GetAxis("Horizontal") < -0.01f)
      {
          inputMovementVector -= new Vector3(movementSpeed * Time.deltaTime, 0);
      }
  }

	private IEnumerator SetJumpReady()
	{
		yield return new WaitForSeconds(0.2f);
		isJumpReady = true;
	}

  private IEnumerator Jump()
  {
      float maxHeight = 2.0f;
      float jumpPower = 10.0f;
      while (Input.GetButton("Jump") && this.transform.position.y < maxHeight)
      {
          rigidbody2D.velocity = new Vector2(0, jumpPower);
          jumpPower -= 0.1f;
          yield return null;
      }
  }
}
