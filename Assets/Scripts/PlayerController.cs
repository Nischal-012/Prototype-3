using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    private float jumpForce = 900;
    private bool isOnGround = true;
    public float gravityModifier;
    public bool gameOver;
    public Animator playerAnim;
    public ParticleSystem explosionParticle;
    public ParticleSystem runningParticle;
    public AudioSource playerAudio;
    public AudioClip jumpSound;
    public AudioClip collisionSound;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        playerAnim = GetComponent<Animator>();
        Physics.gravity *= gravityModifier;
        playerAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround && !gameOver)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
            playerAnim.SetTrigger("Jump_trig");
            runningParticle.Stop();
            playerAudio.PlayOneShot(jumpSound,0.2f);
           
        }
    }
	private void OnCollisionEnter(Collision collision)
	{
        if (collision.gameObject.CompareTag("Ground"))
		{
            isOnGround = true;
            runningParticle.Play();
        }
        if (collision.gameObject.CompareTag("Obstacle"))
		{
            gameOver = true;
            Debug.Log("GameOver");
            playerAnim.SetBool("Death_b",true);
            playerAnim.SetInteger("DeathType_int", 1);
            explosionParticle.Play();
            runningParticle.Stop();
            playerAudio.PlayOneShot(collisionSound, 2.0f);
		}
		
        
	}
}
