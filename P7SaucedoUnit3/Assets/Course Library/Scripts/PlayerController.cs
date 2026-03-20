using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    public float JF = 10;
    public float GM;
    public bool isOnGround = true;
    public bool gameOver = false; 

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        rb = GetComponent<Rigidbody>();
        Physics.gravity *= GM;
   

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround)
        {

            rb.AddForce(Vector3.up * JF, ForceMode.Impulse);
            isOnGround = false; 

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
        }

        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            gameOver = true;
            Debug.Log("Game Over!");
        }
      



    }

































































































































































}
