using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMovement : MonoBehaviour
{
    public Animator anim;
    public static bool carMove = false;

    // Update is called once per frame
    void Update()
    {
        if(carMove)
        {
            anim.SetTrigger("MoveCar");
        }
    }
}
