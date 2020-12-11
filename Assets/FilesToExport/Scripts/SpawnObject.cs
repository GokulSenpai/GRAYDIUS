using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObject : MonoBehaviour
{
    public GameObject[] objects;

    void Start()
    {
        int rand = Random.Range(0, objects.Length);
        GameObject instance=Instantiate(objects[rand], transform.position, objects[rand].transform.rotation);
        instance.transform.parent = transform;
    }

}
