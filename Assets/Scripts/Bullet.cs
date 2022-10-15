using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class Bullet : MonoBehaviour
{
    public float life = 3;
 
    void Awake()
    {
        Destroy(gameObject, life);
    }
 
    void OnCollisionEnter(Collision collision)
    {
	if(collision.gameObject.name == "AICar1" || collision.gameObject.name == "AICar2" || collision.gameObject.name == "AICar3" || collision.gameObject.name == "AICar4"){
		Destroy(collision.gameObject);
	        Destroy(gameObject);
	}
        
    }
}