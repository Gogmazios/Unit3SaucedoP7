using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    public float JF = 10;
    public float GM;
    public bool isOnGround = true;
    public bool gameOver = false;
    private Animator playerAnim;
    public ParticleSystem explosionParticle;
    public ParticleSystem dirtParticle;
    public AudioClip crashSound;
    public AudioClip jumpSound; 
    private AudioSource PA;
    public bool DJU = false;
    public float DJF; 
    public int a;
    public bool doubleSpeed = false; 
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        rb = GetComponent<Rigidbody>();
        playerAnim = GetComponent<Animator>();
        Physics.gravity *= GM;
        PA = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround && !gameOver)
        {

            rb.AddForce(Vector3.up * JF, ForceMode.Impulse);
            isOnGround = false;
            playerAnim.SetTrigger("Jump_trig");
            dirtParticle.Stop();
            PA.PlayOneShot(jumpSound, 1.0f);

            DJU = false; 
        }

        else if(Input.GetKeyDown(KeyCode.Space) && !isOnGround && !DJU)
        {
            DJU = true;
            rb.AddForce(Vector3.up * DJF, ForceMode.Impulse);
            playerAnim.Play("Running_Jump", a);
            PA.PlayOneShot(jumpSound, 1.0f);
        }

        if(Input.GetKey(KeyCode.LeftShift))
        {
            doubleSpeed = true;
            playerAnim.SetFloat("Speed_Multiplier", 2.0f);
        }
        else if (doubleSpeed)
        {
            doubleSpeed = false;
            playerAnim.SetFloat("Speed_Multiplier", 1.0f);

        }


    }

    void FixedUpdate()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
            dirtParticle.Play(); 
        }

        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            gameOver = true;
            Debug.Log("Game Over!");
            playerAnim.SetBool("Death_b", true);
            playerAnim.SetInteger("DeathType_int", 1);
            explosionParticle.Play();
            Destroy(rb);
            dirtParticle.Stop();
            PA.PlayOneShot(crashSound, 1.0f);
        }

    }

}
