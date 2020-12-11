using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGeneration : MonoBehaviour {

    public Transform[] StartingPos;

    public GameObject[] rooms;

    public GameObject EnemySpawner;

    private int direction;
    public float Distance;
    private float TimeBtwRoom;
    public float StartTimeBtwRoom=0.05f;
    public float MinX, MaxX, MinY;

    public bool StopGeneration = false;

    public LayerMask Room;

    private int DownCounter = 0;
    private GameObject obj;
    public List<GameObject> MainRooms;

    public GameObject Player;
    public Vector3 PlayerSpawnPos;

    public bool playerSpawned = false;

    public GameObject CheckPointImage;
    public bool checkPointSpawned = false;


    public GameObject BossImage;
    public bool BossImagedSpawned = false;

    public bool EnemiesSpawned = false;
    public bool TotalLevelSpawned = false;


    void Start()
    {
        int rand = Random.Range(0, StartingPos.Length);

        MainRooms = new List<GameObject>();

        //EnemySpawner =GameObject.Find("EnemySpwanpoints");
        transform.position = StartingPos[rand].position;
        obj=  Instantiate(rooms[0], transform.position,transform.rotation);
        MainRooms.Add(obj);
        direction = Random.Range(1, 6);

        PlayerSpawnPos = MainRooms[0].transform.localPosition;
    }


    private void FixedUpdate()
    {
        
        if (TimeBtwRoom <= 0 && StopGeneration==false)
        {
            Roomspawn();

            TimeBtwRoom = StartTimeBtwRoom;

        }
        else
        {
            TimeBtwRoom -= Time.deltaTime;
        }

        if (StopGeneration & !playerSpawned)
        {
           Player= Instantiate(Player, PlayerSpawnPos, Quaternion.identity);
            playerSpawned = true;
        }

       
        if (StopGeneration & playerSpawned & !EnemiesSpawned)
        {
            SpawnEnemy();
            EnemiesSpawned = true;
        }
        BossRoom();
        CheckPoints();

        if(StopGeneration & playerSpawned & EnemiesSpawned & BossImagedSpawned & checkPointSpawned)
        {
            TotalLevelSpawned = true;
        }
        

    }

    private void Roomspawn()
    {
        
        if (direction == 1 || direction == 2)//move Right
        {
            if (transform.position.x < MaxX)
            {
                DownCounter = 0;

                Vector2 newpos = new Vector2(transform.position.x + Distance, transform.position.y);
                transform.position = newpos;

                int rand = Random.Range(0, rooms.Length);

                 obj=Instantiate(rooms[rand], transform.position, Quaternion.identity);
                MainRooms.Add(obj);
                direction = Random.Range(1, 6);
                
                if (direction == 3) {
                    direction = 2;
                }

                else if (direction == 4)
                {
                    direction = 5;
                }

            }
            else { direction = 5; }

        }
        else if (direction == 3 || direction == 4)//move Left
        {
            if (transform.position.x > MinX)
            {
                DownCounter = 0;

                Vector2 newpos = new Vector2(transform.position.x - Distance, transform.position.y);
                transform.position = newpos;


                int rand = Random.Range(0, rooms.Length);
                 obj = Instantiate(rooms[rand], transform.position, Quaternion.identity);
                MainRooms.Add(obj);

                direction = Random.Range(3, 6);
            }
            else { direction = 5; }
        }
        else if (direction == 5 )//move Down
        {
            DownCounter++;
            if (transform.position.y > MinY)
            {
                Collider2D roomDetection =Physics2D.OverlapCircle(transform.position, 1, Room);

                if (roomDetection.GetComponent<RoomType>().type != 1 && roomDetection.GetComponent<RoomType>().type != 3)
                {
                    if (DownCounter >= 2)
                    {
                        roomDetection.GetComponent<RoomType>().RoomDestruction();
                        MainRooms.RemoveAt(MainRooms.Count - 1);
                       var Robj = Instantiate(rooms[3], transform.position, Quaternion.identity);
                        MainRooms.Add(Robj);

                    }
                    else
                    {
                        roomDetection.GetComponent<RoomType>().RoomDestruction();
                        MainRooms.RemoveAt(MainRooms.Count - 1);
                        int RandBottomRoom = Random.Range(1, 4);
                        if (RandBottomRoom == 2)
                        {
                            RandBottomRoom = 1;
                        }

                        var Robj= Instantiate(rooms[RandBottomRoom], transform.position, Quaternion.identity);
                        MainRooms.Add(Robj);
                    }
                }

                Vector2 newpos = new Vector2(transform.position.x, transform.position.y - Distance);
                transform.position = newpos;

                int rand = Random.Range(2, rooms.Length);
                var obj= Instantiate(rooms[rand], transform.position, Quaternion.identity);
                MainRooms.Add(obj);
                direction = Random.Range(1, 6);
            }
            else {
                StopGeneration = true;
            }

        }

    }

    private void SpawnEnemy()
    {

        for (int i = 0; i < MainRooms.Count; i++)
        {
            if (PlayerSpawnPos == MainRooms[i].transform.position)
            {
            }
            else
            {
                var obj =   Instantiate(EnemySpawner, MainRooms[i].transform.position, Quaternion.identity);
            }
        }
    }
    private void BossRoom()
    {
        if (StopGeneration && !BossImagedSpawned)
        { int lastMainRoom = MainRooms.Count-1;
            Instantiate(BossImage, MainRooms[lastMainRoom].transform.position, Quaternion.identity);
            BossImagedSpawned = true;
        }
    }

    private void CheckPoints()
    {

        if (StopGeneration & !checkPointSpawned)
        {
            if(MainRooms.Count<=5 & MainRooms.Count > 3)
            {
                Instantiate(CheckPointImage, MainRooms[2].transform.position, Quaternion.identity);
                checkPointSpawned=true;
            }

            else if (MainRooms.Count <= 7 & MainRooms.Count >5)
            {
                Instantiate(CheckPointImage, MainRooms[3].transform.position, Quaternion.identity);
                Instantiate(CheckPointImage, MainRooms[5].transform.position, Quaternion.identity);
                checkPointSpawned = true;
            }
            else if (MainRooms.Count <= 9 & MainRooms.Count > 7)
            {
                Instantiate(CheckPointImage, MainRooms[4].transform.position, Quaternion.identity);
                Instantiate(CheckPointImage, MainRooms[7].transform.position, Quaternion.identity);
                checkPointSpawned = true;
            }
            else if(MainRooms.Count <= 10 & MainRooms.Count>8)
            {
                Instantiate(CheckPointImage, MainRooms[4].transform.position, Quaternion.identity);
                Instantiate(CheckPointImage, MainRooms[7].transform.position, Quaternion.identity);
                checkPointSpawned = true;


            }

           else if (MainRooms.Count <= 12 & MainRooms.Count > 10)
            {
                Instantiate(CheckPointImage, MainRooms[4].transform.position, Quaternion.identity);
                Instantiate(CheckPointImage, MainRooms[6].transform.position, Quaternion.identity);
                Instantiate(CheckPointImage, MainRooms[9].transform.position, Quaternion.identity);
                checkPointSpawned = true;

            }
        }
    }
}
