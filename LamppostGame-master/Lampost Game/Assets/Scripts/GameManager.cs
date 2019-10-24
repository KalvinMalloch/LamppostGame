using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public GameObject light1, light2, light3;
    public bool IsLightChosen;
    public int LightChosen;
    public float Countdown = 5f;
    public int nextLight;
    float switchFlickerDelay = 0.2f;


    void Start()
    {
        IsLightChosen = false;

        nextLight = Random.Range(1, 4);

        LightChosen = nextLight;
    }

    void Update()
    {
        RandomLight();
        TurnLightsOn();
        FlickerLight(nextLight);
    }

    void RandomLight() 
    {
        if (IsLightChosen == false) 
        {
            int previousLight = LightChosen;   
            while(nextLight == previousLight){
                nextLight = Random.Range(1, 4);
            }
            IsLightChosen = true;
            Countdown = 5f;
        }

        if (Countdown >= 0) 
        {
            Countdown = Countdown - (Time.deltaTime * 1);
        }

        if (Countdown <= 0) 
        {
            LightChosen = nextLight;
            IsLightChosen = false;
        }
    }

    void FlickerLight(int light)
    {

        if(switchFlickerDelay <= 0.8f)
        {
            if (light == 1)
            {
                light1.SetActive(false);
            }
            else if (light == 2)
            {
                light2.SetActive(false);
            }
            else if (light == 3)
            {
                light3.SetActive(false);
            }
        }
        else if(switchFlickerDelay >= 0.9f)
        {
            if (light == 1)
            {
                light1.SetActive(true);
            }
            else if (light == 2)
            {
                light2.SetActive(true);
            }
            else if (light == 3)
            {
                light3.SetActive(true);
            }
        }

        switchFlickerDelay -= Time.deltaTime;
        if(switchFlickerDelay <= 0)
        {
            switchFlickerDelay = 1;
        }
    }

    void TurnLightsOn() 
    {
        if (LightChosen == 1)
        {
            light1.SetActive (true);
            light2.SetActive (false);
            light3.SetActive (false);
        }
        else if (LightChosen == 2)
        {
            light1.SetActive (false);
            light2.SetActive (true);
            light3.SetActive (false);
        }
        else if (LightChosen == 3)
        {
            light1.SetActive (false);
            light2.SetActive (false);
            light3.SetActive (true);
        }
    }
}
