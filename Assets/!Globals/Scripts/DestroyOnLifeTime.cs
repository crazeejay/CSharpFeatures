using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnLifeTime : MonoBehaviour
{
    public float lifeTime = 5f;
    public GameObject sphere;

	// Use this for initialization
	void Start ()
    {
        //destroys self after lifetime
        Destroy(gameObject, lifeTime);

        lifeTime = 5;
		
	}
}
