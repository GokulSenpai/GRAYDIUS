using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Smooth_camera : MonoBehaviour
{
    private  Vector3 playerpos;
    private Vector3 velocity=Vector3.zero;
    private Transform player;
    public float smoothtime = .2f;

    //creating bounderies
    public float XMaxValue = 0;
    public float XMinValue = 0;
    public float YMinValue = 0;
    public float YMaxValue = 0;

    public bool XmaxEnabled = false;
    public bool XminEnabled = false;
    public bool YmaxEnabled = false;
    public bool YminEnabled = false;

    private LevelGeneration LGRef;

    private void Start()
    {
        LGRef = GameObject.Find("LevelGeneration").GetComponent<LevelGeneration>();

        player = LGRef.Player.transform;
        playerpos = player.transform.position;

    }

    void FixedUpdate()
    {
       
        player = LGRef.Player.transform;
        playerpos = player.transform.position;
       

        //vertical Boundaries
        if (YmaxEnabled && YminEnabled)
            playerpos.y = Mathf.Clamp(player.transform.position.y, YMinValue, YMaxValue);

        else if ( YmaxEnabled )
            playerpos.y = Mathf.Clamp(player.transform.position.y, player.transform.position.y, YMaxValue);

        else if ( YminEnabled)
            playerpos.y = Mathf.Clamp(player.transform.position.y, YMinValue, player.transform.position.y);



        //horizontal Boundaries
        if (XmaxEnabled && XminEnabled)
            playerpos.x = Mathf.Clamp(player.transform.position.x,  XMinValue, XMaxValue);

        else if (XmaxEnabled)
            playerpos.x = Mathf.Clamp(player.transform.position.x, player.transform.position.x, XMaxValue);

        else if (YminEnabled)
            playerpos.x = Mathf.Clamp(player.transform.position.x, XMinValue, player.transform.position.x);




        //aligning camera pos.z to player pos.Z
        playerpos.z = transform.position.z;
        transform.position = Vector3.SmoothDamp(transform.position, playerpos, ref velocity, smoothtime);



    }

}
