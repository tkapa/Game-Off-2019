using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGeneration : MonoBehaviour
{
    public Transform[] startingPositions;
    public GameObject[] rooms; // index 0 LR, index 1 LRD, index 2 LRU, index 3 LRDU
    public Vector2 roomSize = new Vector2(10, 10); 
    public LayerMask roomMask = 0;

    public float minimumX;
    public float maximumX;
    public float minimumY;
    private bool stoppedGeneration = false;

    private int direction = 0;
    private int downCounter = 0;
    private float timeBtwRoom;
    public float startTimeBtwRoom = 0.25f;

    // Start is called before the first frame update
    void Start()
    {
        int randStartingPos = Random.Range(0, startingPositions.Length);
        transform.position = startingPositions[randStartingPos].transform.position;
        Instantiate(rooms[0], transform.position, Quaternion.identity);
        direction = Random.Range(1, 7);
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
            if(transform.position.x <= maximumX){
                downCounter = 0;
                Vector3 newPos = new Vector3(transform.position.x + roomSize.x, 0, transform.position.z);
                transform.position = newPos;
                
                int rand = Random.Range(0, rooms.Length);
                Instantiate(rooms[rand], transform.position, Quaternion.identity);

                direction = Random.Range(1, 7);
                if(direction == 3){
                    direction = 2;
                } else if(direction == 4){
                    direction = 5;
                }
            } else {
                direction = 5;
            }
        } else if(direction == 3 || direction == 4){ // Move Left
            if(transform.position.x > minimumX){
                downCounter = 0;
                Vector3 newPos = new Vector3(transform.position.x - roomSize.x, 0, transform.position.z);
                transform.position = newPos;

                int rand = Random.Range(0, rooms.Length);
                Instantiate(rooms[rand], transform.position, Quaternion.identity);

                direction = Random.Range(3, 7);
            } else{
                direction = 5;
            } 
        } else if(direction == 5 || direction == 6){ // Move down

            downCounter++;

            if(transform.position.z < minimumY){

                Collider[] roomDetector = Physics.OverlapSphere(transform.position, 1, roomMask);                
                int type = roomDetector[0].GetComponent<RoomType>().type;

                if(type != 1 || type != 3){
                    roomDetector[0].GetComponent<RoomType>().RoomDestruction();
                    
                    if(downCounter >= 2){
                        Instantiate(rooms[3], transform.position, Quaternion.identity);
                    } else{
                        int randBottom = Random.Range(1, 4);
                        if(randBottom == 2){
                            randBottom = 1;
                        }
                        Instantiate(rooms[randBottom], transform.position, Quaternion.identity);
                    }

                    
                }

                Vector3 newPos = new Vector3(transform.position.x, 0, transform.position.z + roomSize.y);
                transform.position = newPos;

                int rand = Random.Range(2, 4);
                Instantiate(rooms[rand], transform.position, Quaternion.identity);

                direction = Random.Range(1, 7);
            } else{
                stoppedGeneration = true;
            }
        }
    }
}
