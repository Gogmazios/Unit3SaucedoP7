using UnityEngine;

public class MoveLeft : MonoBehaviour
{

    public PlayerController Player;
    private float leftBound = -15; 
  
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Player = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    private float speed = 30;
  

    // Update is called once per frame
    void Update()
    {
        if (Player.gameOver == false)
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }
     
        if (transform.position.x < leftBound && gameObject.CompareTag("Obstacle"))
        {
            Destroy(gameObject); 
        }
    }
}
