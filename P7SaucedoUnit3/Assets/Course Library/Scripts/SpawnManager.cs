using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] op;
    private Vector3 spawnPos = new Vector3(25, 0, 0);
    private float sd = 2;
    private float rr = 2;
    public PlayerController Player;
    private int randomObstacle;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InvokeRepeating("SpawnObstacle", sd, rr);
        Player = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    void SpawnObstacle ()
    {
        if (Player.gameOver == false)
        {
            randomObstacle = Random.Range(0, op.Length);
            Instantiate(op[randomObstacle], spawnPos, op[randomObstacle].transform.rotation);
        }
    }

    // Update is called once per frame
    void Update()
    {
        



    }
}
