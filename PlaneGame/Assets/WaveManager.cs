using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : Singleton<WaveManager>
{
    float timer;

    [SerializeField]float baseTimer;
    GameObject enemy;

    private float baseSpawnPositionX=10;

    void Start(){
        timer=baseTimer;
        enemy=Resources.Load("Enemies/Enemy") as GameObject;
    }
    void Update()
    {
        timer-=Time.deltaTime;
        if(timer<=0){
            timer=baseTimer;
            SpawnEnemies();
        }
    }

    void SpawnEnemies(){
        int numOfEnemies = Random.Range(2,5);
        //TODO get position of enemies to spawn


        for(int i=0; i<numOfEnemies; i++){
            //spawnenemy on position
        }
        float y=0;
        Instantiate(enemy,new Vector3(baseSpawnPositionX,y,0),Quaternion.identity);
    }
}
