using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnTriggerEnter2D(Collider2D Player)
    {
        if (Player.tag == "Player")
        {
            MovementScript PlayerScripts = Player.GetComponent<MovementScript>();
            PlayerScripts.depression = PlayerScripts.depression + 30;

            Destroy(gameObject);
        }
    }
}
