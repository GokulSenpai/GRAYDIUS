using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnRoom : MonoBehaviour
{
    public LayerMask roomLayer;
    public LevelGeneration levelgen;

    void Update()
    {
        Collider2D roomDetection = Physics2D.OverlapCircle(transform.position, 1, roomLayer);
        if (roomDetection == null && levelgen.StopGeneration == true)
        {

            int rand = Random.Range(0, levelgen.rooms.Length);
            Instantiate(levelgen.rooms[rand], transform.position, transform.rotation);
            Instantiate(levelgen.EnemySpawner, transform.position, transform.rotation);
            Destroy(gameObject);
        }

    }
}
