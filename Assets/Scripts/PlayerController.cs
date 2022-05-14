using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    private float jumpForce = 20;
    private bool isOnGround = true;
    public float gravityModifier;
    public bool gameOver;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifier;
    }

    // Update is called once per frame
    void Update()
    {
      if(Input.GetKeyDown(KeyCode.Space) && isOnGround)
		{
            rb.AddForce(Vector3.up * jumpForce,ForceMode.Impulse);
		    isOnGround = false;
        }
    }
	private void OnCollisionEnter(Collision collision)
	{
        if (collision.gameObject.CompareTag("Ground"))
		{
            isOnGround = true;
        }
        if (collision.gameObject.CompareTag("Obstacle"))
		{
            gameOver = true;
            Debug.Log("GameOver");
		}
		
        
	}
}
