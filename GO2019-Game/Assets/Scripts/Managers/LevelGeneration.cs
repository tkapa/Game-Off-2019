using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGeneration : MonoBehaviour
{
    public Transform[] startingPositions;

    /*  Room Index
        0 LR 1 LRD 2 LRU 3 LRDU 4 DU 5 LDU 6 RDU 7 UL 8 UR */
    public GameObject[] rooms; 

    //Room Index 9
    public GameObject spawnRoom;
    //Room Index 10
    public GameObject finalRoom;
    public Vector2 roomSize = new Vector2(10, 10); 
    public LayerMask roomMask = 0;

    public float minimumX;
    public float maximumX;
    public float minimumY;
    public static bool stoppedGeneration = false;

    private float timeBtwRoom;
    public float startTimeBtwRoom = 0.25f;

    private int direction = 0;
    private int downCounter = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        stoppedGeneration = false;
        int randStartingPos = Random.Range(0, startingPositions.Length);
        transform.position = startingPositions[randStartingPos].transform.position;
        Instantiate(spawnRoom, transform.position, Quaternion.identity);
        direction = Random.Range(1, 5);
    }

    private void Update() {
        if(timeBtwRoom <= 0 && !stoppedGeneration){
            Move();
            timeBtwRoom = startTimeBtwRoom;
        } else{
            timeBtwRoom -= Time.deltaTime;
        }
    }

    void Move(){
        if(direction == 1 || direction == 2){ //Move Right
            MoveRight();
        } else if(direction == 3 || direction == 4){ // Move Left
            MoveLeft();
        } else if(direction == 5){ // Move down
            MoveDown();            
        }
    }

    void MoveRight(){
        if(transform.position.x < maximumX){
            downCounter = 0;
            Vector3 newPos = new Vector3(transform.position.x + roomSize.x, 0, transform.position.z);
            transform.position = newPos;
                
            InstantiateRandomRoom(0,5);

            direction = Random.Range(1, 6);
            if(direction == 3){
                direction = 2;
            } else if(direction == 4){
                direction = 5;
            }
        } else {
            direction = 5;
        }
    }

    void MoveLeft(){
        if(transform.position.x > minimumX){
            downCounter = 0;
            Vector3 newPos = new Vector3(transform.position.x - roomSize.x, 0, transform.position.z);
            transform.position = newPos;

            InstantiateRandomRoom(0,5);

            direction = Random.Range(3, 6);
        } else{
            direction = 5;
        } 
    }

    void MoveDown(){
        downCounter++;

        if(transform.position.z < minimumY){

            Collider[] roomDetector = Physics.OverlapSphere(transform.position, 1, roomMask);                
            int type = roomDetector[0].GetComponent<RoomType>().type;

            if(type != 1 || type != 3 || type != 9){
                roomDetector[0].GetComponent<RoomType>().RoomDestruction();
                    
                if(downCounter >= 2){
                    InstantiateRoom(rooms[3]);
                } else{
                    InstantiateRandomRoom(1,4);
                }                    
            }

            Vector3 newPos = new Vector3(transform.position.x, 0, transform.position.z + roomSize.y);
            transform.position = newPos;

            InstantiateRandomRoom(2, 4);

            direction = Random.Range(1, 6);
        } else{
            Collider[] roomDetector = Physics.OverlapSphere(transform.position, 1, roomMask);
            roomDetector[0].GetComponent<RoomType>().RoomDestruction();
            InstantiateRoom(finalRoom);
            stoppedGeneration = true;
        }
    }

    void InstantiateRandomRoom(int minimumRoll, int maximumRoll){
        int rand = Random.Range(minimumRoll, maximumRoll);
        Instantiate(rooms[rand], transform.position, Quaternion.identity);
    }

    void InstantiateRoom(GameObject room){
        Instantiate(room, transform.position, Quaternion.identity);
    }
}
