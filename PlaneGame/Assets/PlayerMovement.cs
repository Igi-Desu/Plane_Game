using System.Timers;
using UnityEngine;
using UnityEngine.InputSystem;
using Unity.Mathematics;
public class PlayerMovement : Singleton<PlayerMovement>
{
    float movement;
    [SerializeField]float speed;
    /// <summary>
    /// returns current speed of player
    /// </summary>
    public float Speed => speed;

    protected void Update(){
        //clamp position so that player doesn't exit playable ground
        float yPos= math.clamp(transform.position.y+movement*speed*Time.deltaTime,-2,2);
        
        transform.position= new Vector3(0,yPos,0);
        
    }
    
    public void Move(InputAction.CallbackContext ctx){
        movement=ctx.ReadValue<float>();
    }
}
