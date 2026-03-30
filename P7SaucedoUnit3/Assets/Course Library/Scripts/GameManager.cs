using UnityEngine;

public class GameManager : MonoBehaviour
{
    public float score;
    public PlayerController Player;
 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Player = GameObject.Find("Player").GetComponent<PlayerController>();
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(!Player.gameOver)
        {
            if(Player.doubleSpeed)
            {
                score += 2;
            }
            else
            {
                score++;
            }
            Debug.Log("Score: " + score); 
        }
    }
}
