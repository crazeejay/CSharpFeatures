﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour {

    public int score = 0;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    void OnCollisionEnter(Collision ball)
    {
        if(ball.gameObject.tag == "Ball") 
        {
            score++;
            Destroy(ball.gameObject);
        }
    }
}
