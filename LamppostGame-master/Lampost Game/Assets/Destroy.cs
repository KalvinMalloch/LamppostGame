using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Example : MonoBehaviour {
    public GameObject player;
    public void OnTriggerEnter2D(Collider2D Item)
    {
    
        if (player != null)
        {
            Destroy(gameObject);
        }
    }
    
}