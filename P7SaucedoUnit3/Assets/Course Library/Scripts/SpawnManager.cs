using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject op;
    private Vector3 spawnPos = new Vector3(25, 0, 0);
    private float sd = 2;
    private float rr = 2; 


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InvokeRepeating("SpawnObstacle", sd, rr);

    }

    void SpawnObstacle ()
    {
        Instantiate(op, spawnPos, op.transform.rotation); 
    }

    // Update is called once per frame
    void Update()
    {
        



    }
}
