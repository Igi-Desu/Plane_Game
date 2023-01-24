using UnityEngine;
//singleton is only good it his project, otherwise it would be wise to
//find different solution in case we want to make multiple scrolling backgrounds
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
        //making sure there's no flicker, knowing that background size is 16, after scaling background it should
        //increase by scale factor
        backgroundSize*=transform.localScale.x;
    }
    void Update()
    {
        //simply move background, and teleport it back after it reaches certain point
        transform.position+=Vector3.left*speed*Time.deltaTime;
        if(transform.position.x<=basePosition.x-backgroundSize){
            transform.position=Vector3.zero;
        }
    }
}
