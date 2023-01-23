using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//singleton is only good for this project otherwise it's wise to find different solution
//in case we want to make multiple scrolling backgrounds
public class MovingBackground : Singleton<MovingBackground>
{
    float speed=5;
    float backgroundSize=16;
    /// <summary>
    /// returns current speed that background moves
    /// </summary>
    public float Speed => speed;
    [Tooltip("Base position of background")]
    [SerializeField]Vector3 basePosition;

    void Start(){

    }
    void Update()
    {
        transform.position+=Vector3.left*speed*Time.deltaTime;
        if(transform.position.x<=basePosition.x-backgroundSize){
            transform.position=Vector3.zero;
        }
    }
}
