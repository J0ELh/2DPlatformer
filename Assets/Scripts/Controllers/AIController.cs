using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AIController", menuName = "InputController/AIController")]



public class AIController : InputController
{
    private float movement = -1f;
    private float switchRate = 2f;
    private static float nextSwitch = 0f;

    
    

    void Start()
    {
        nextSwitch = 0f;
    }

    public override bool RetrieveJumpInput() {
        
        return true;
    }

    public override float RetrieveMoveInput() { 
        if (Time.time > nextSwitch) { 
            nextSwitch = Time.time + switchRate;
            movement =  movement * (-1f);
        }

        return movement;
    }
}
