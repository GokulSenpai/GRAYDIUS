using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisablePlayerRay : MonoBehaviour
{
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player.GetComponent<RayCastTeleport>().enabled = false;
    }

}
