using System.Collections;
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
    bool canShot=true;

    [SerializeField]GameObject bullet;

    void Start(){
        GameManager.Instance.AddOnStartAction(EnableMovement);
        this.enabled=false;
    }
    void EnableMovement(){
        this.enabled=true;
    }
    protected void Update(){
        //clamp position so that player doesn't exit playable ground
        float yPos= math.clamp(transform.position.y+movement*speed*Time.deltaTime,-2,2);
        
        transform.position= new Vector3(transform.position.x,yPos,0);
        
    }

    public void Move(InputAction.CallbackContext ctx){
        if(!this.enabled)return;
        movement=ctx.ReadValue<float>();
    }

    public void Shoot(InputAction.CallbackContext ctx){
        if(!this.enabled)return;
        if(!canShot)return;
        Instantiate(bullet,transform.position,quaternion.identity);
        StartCoroutine(ShootingCooldown(0.5f));
    }

    IEnumerator ShootingCooldown(float amount){
        canShot=false;
        yield return new WaitForSeconds(amount);
        canShot=true;
    }
}
