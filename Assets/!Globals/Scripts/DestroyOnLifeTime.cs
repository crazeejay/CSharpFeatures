using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnLifeTime : MonoBehaviour
{
    public float lifeTime = 5f;

	// Use this for initialization
	void Start ()
    {
        //destroys self after lifetime
        Destroy(gameObject, lifeTime);
		
	}
}
