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
        //possible y position where enemy can spawn
        int[] lanes = {-2,-1,0,1,2};

        int numOfEnemies = Random.Range(2,5);

        bool fromArrayEnd = numOfEnemies>5/2;
        for(int i=0; i<numOfEnemies; i++){
            //get random number from interval that is tightening with every iteration
            int randomNum = Random.Range(0,5-i);
            //spawn enemy on position that was chosen
            Instantiate(enemy,new Vector3(baseSpawnPositionX,lanes[randomNum],0),Quaternion.identity);
            //switch chosen number with last possible one that can be chosen
            lanes[randomNum] = lanes[5-(i+1)];
            //this way we can generate n random numbers using rand function n times
        }  
    }
}
