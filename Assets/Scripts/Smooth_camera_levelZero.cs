using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Smooth_camera_levelZero : MonoBehaviour
{
    private  Vector3 playerpos;
    private Vector3 velocity=Vector3.zero;
    //make player public for level  0;
    public Transform player;
    public float smoothtime = .2f;

    private Vector3 playerAngle;

    //creating bounderies
    public float XMaxValue = 0;
    public float XMinValue = 0;
    public float YMinValue = 0;
    public float YMaxValue = 0;

    public bool XmaxEnabled = false;
    public bool XminEnabled = false;
    public bool YmaxEnabled = false;
    public bool YminEnabled = false;

    public bool camera_Flipped = false;
//    private LevelGeneration LGRef;

    private void Start()
    {
        //   LGRef = GameObject.Find("LevelGeneration").GetComponent<LevelGeneration>();


        //   player = LGRef.Player.transform;


        //playerpos = LGRef.PlayerPos;
        //playerAngle = LGRef.Player.transform.localEulerAngles;
        //below 2 lines for  level 0;
        playerpos = player.localPosition;
        playerAngle = player.localEulerAngles;
    }

    void FixedUpdate()
    {
        //if (LGRef.TotalLevelSpawned & LGRef.PlayerMoving)
        //{

        //    playerpos = LGRef.PlayerPos;


        //}
        //else if (LGRef.TotalLevelSpawned & !LGRef.PlayerMoving)
        //{
        //    player.transform.position = LGRef.MainRooms[0].transform.position;

        //}
        //use below 2 lines for level zero;
        playerpos = player.transform.position;
        playerAngle = player.rotation.eulerAngles;

        //playerpos = LGRef.PlayerPos;
        //playerAngle = LGRef.Player.transform.localEulerAngles;


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


        playerpos.z = transform.position.z;


        //aligning camera pos.z to player pos.Z
        transform.position = Vector3.SmoothDamp(transform.position, playerpos, ref velocity, smoothtime);

        if (playerAngle.z>85 & playerAngle.z < 95)
        {
            transform.rotation =Quaternion.Slerp(transform.localRotation,Quaternion.Euler(playerAngle),smoothtime);
            camera_Flipped = true;
        }
       else if (playerAngle.z >265 & playerAngle.z <275)
        {
            transform.rotation = Quaternion.Slerp(transform.localRotation, Quaternion.Euler(playerAngle), smoothtime);
            camera_Flipped = true;
        }

        else
        {
            transform.rotation = Quaternion.Euler(0,0,0);
            camera_Flipped = false;
        }

        Limits();

    }
    private void Limits()
    {

        if (camera_Flipped)
        {
            XMinValue = -5f;
            XMaxValue = 5f;
            YMaxValue = 0;
            YMinValue = 0;
        }
        else
        {
            XMinValue = -2.5f;
            XMaxValue = 2.5f;
            YMaxValue = 0;
            YMinValue = 0;
        }
    }
}
