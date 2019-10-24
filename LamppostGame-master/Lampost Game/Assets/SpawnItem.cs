using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class SpawnItem : MonoBehaviour
{
    public GameObject item;
    public float spawnTime = 2f;
    public float fallSpeed = 40.0f; 
    private float timer = 0; //counting timer, reset after calling SpawnRandom() function
    private int randomNumber;       //variable for storage of an random Number

    void Update()
    {
        timer += Time.deltaTime;   // Timer Counter
        if (timer > spawnTime)
        {
            SpawnRandom();       //Calling method SpawnRandom()
            timer = 0;        //Reseting timer to 0
        }
    }
    public void SpawnRandom()
    {

        //Creating random Vector3 position
        Vector3 screenPosition = (new Vector3(0, 13, 3));
        Instantiate(item, screenPosition, Quaternion.identity);;
    }
}
