using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    public float score;
    public PlayerController Player;
    public Transform start;
    public float lerp; 
 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Player = GameObject.Find("Player").GetComponent<PlayerController>();
        score = 0;

        Player.gameOver = true;
        StartCoroutine(PlayIntro());
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

    IEnumerator PlayIntro()
    {
        Vector3 startPos = Player.transform.position;
        Vector3 endPos = start.position;
        float journeyLength = Vector3.Distance(startPos, endPos);
        float startTime = Time.time;

        float distanceCovered = (Time.time - startTime) * lerp; 
        float fractionOfJourney = distanceCovered / journeyLength;

        Player.GetComponent<Animator>().SetFloat("Speed_Multiplier", 0.5f);

        while (fractionOfJourney < 1)
        {
            distanceCovered = (Time.time - startTime) * lerp;
            fractionOfJourney = distanceCovered / journeyLength; 
            Player.transform.position = Vector3.Lerp(startPos, endPos, fractionOfJourney);
            yield return null;
        }

        Player.GetComponent<Animator>().SetFloat("Speed_Multiplier", 1.0f);
        Player.gameOver = false; 


    }



}
