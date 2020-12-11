using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flip_Player : MonoBehaviour
{
    public enum ONGrounded { Down,Top,Left,Right};
    public ONGrounded isOn;
    public enum Facing { Left, Right };
    public Facing FacingDir;
    public GameObject Player;
    private float Zrotation;
   
    private Vector3 CursorPosition;
    private Player_Shooting PSRef;

    private Vector3 Scaler;


    private SpriteRenderer SR;

    void Start()
    {

        isOn = ONGrounded.Down;
        FacingDir = Facing.Right;

        Zrotation = Player.transform.localEulerAngles.z;
        Player = this.gameObject;
      //  Player = GameObject.FindGameObjectWithTag("Player");
        SR = Player.GetComponent<SpriteRenderer>();
        PSRef = Player.GetComponent<Player_Shooting>();
        CursorPosition = PSRef.Aim.transform.position;

    }

    void Update()
    {
        CursorPosition = PSRef.Aim.transform.position;

        Scaler = Player.transform.localScale;
        LandedOn();
        Flip();
    }
    void Flip() {
        
        if (isOn == ONGrounded.Down)
        {
            if (FacingDir == Facing.Right & Player.transform.localPosition.x > CursorPosition.x)
            {
                Scaler.x *= -1;
                FacingDir = Facing.Left;
            }
            else if (FacingDir == Facing.Left & Player.transform.localPosition.x < CursorPosition.x)
            {
                Scaler.x *= -1;

                FacingDir = Facing.Right;
            }

        }
        else if (isOn == ONGrounded.Top)
        {
            if (FacingDir == Facing.Right & Player.transform.localPosition.x < CursorPosition.x)
            {
                Scaler.x *= -1;

                FacingDir = Facing.Left;
            }
            else if (FacingDir == Facing.Left & Player.transform.localPosition.x > CursorPosition.x)
            {
                Scaler.x *= -1;

                FacingDir = Facing.Right;
            }

        }
        else if (isOn == ONGrounded.Left)
        {
            if (FacingDir == Facing.Right & Player.transform.localPosition.y > CursorPosition.y)
            {
                Scaler.x *= -1;

                FacingDir = Facing.Left;
            }
            else if (FacingDir == Facing.Left & Player.transform.localPosition.y < CursorPosition.y)
            {
                Scaler.x *= -1;

                FacingDir = Facing.Right;
            }
        }

        else if (isOn == ONGrounded.Right)
        {
            if (FacingDir == Facing.Right & Player.transform.localPosition.y < CursorPosition.y)
            {
                Scaler.x *= -1;

                FacingDir = Facing.Left;
            }
            else if (FacingDir == Facing.Left & Player.transform.localPosition.y > CursorPosition.y)
            {
                Scaler.x *= -1;

                FacingDir = Facing.Right;
            }
        }
        Player.transform.localScale = Scaler;
    }
    void LandedOn()
    {
        Zrotation = Player.transform.localEulerAngles.z;

        if (Zrotation < 5 & Zrotation > -5)
        {
            Player.transform.localRotation = Quaternion.Euler(0, 0, 0);
            isOn = ONGrounded.Down;
          

        }
        else if (Zrotation < 185 & Zrotation > 175 | Zrotation < -175 & Zrotation > -185)
        {
            Player.transform.localRotation = Quaternion.Euler(0, 0, 180);

            isOn = ONGrounded.Top;
           
        }
        else if (Zrotation < 95 & Zrotation > 85)
        {
            Player.transform.localRotation = Quaternion.Euler(0, 0, 90);

            isOn = ONGrounded.Left;
          
        }
        else if (Zrotation < 275 & Zrotation > 265 | Zrotation < -85 & Zrotation > -95)
        {
            Player.transform.localRotation = Quaternion.Euler(0, 0, -90);

            isOn = ONGrounded.Right;
        }
        else
        {
            Zrotation %= 360;
        }

        /*  if (Zrotation ==0)
          {
              isOn = ONGrounded.Down;
          }
          else if (Zrotation == 180)
          {
              isOn = ONGrounded.Top;       
          }
          else if (Zrotation == 90)
          {
              isOn = ONGrounded.Left;     
          }
          else if (Zrotation ==-90)
          {
              isOn = ONGrounded.Right;
          }
        */
    }

}
