using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Shooting : MonoBehaviour
{
    private Vector3 Target;
    public GameObject Aimobj;
    public GameObject Aim;
    private GameObject Player;
    public GameObject Shootingobj;
    private Transform Spawningpos;
    public  GameObject BulletPrefab;
    public float bullet_Speed = 10f;
    private GameObject PlayerHand;
    void Start()
    {
        Cursor.visible = false;

        Player = this.gameObject;


        PlayerHand = Instantiate(Shootingobj, Shootingobj.transform.position, Shootingobj.transform.rotation);
 
        Spawningpos = PlayerHand.transform.GetChild(0).gameObject.transform;
        PlayerHand.transform.localPosition = Player.transform.localPosition;

         Aim = Instantiate(Aimobj, Aimobj.transform.position, Aimobj.transform.rotation);

    }

    void Update()
    {
        PlayerHand.transform.localPosition = transform.localPosition;

        Target =Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, transform.position.z));
        Aim.transform.position = new Vector2(Target.x, Target.y);

        Vector3 difference = Target - PlayerHand.transform.position;
        float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        PlayerHand.transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ);

        if (Input.GetMouseButtonDown(1))
        {
            float distance = difference.magnitude;
            Vector2 direction =  difference / distance;
            direction.Normalize();
            Fire(direction);
        }

     
    }

    private void Fire(Vector2 direction)
    {
        GameObject obj  =Instantiate(BulletPrefab, Spawningpos.position,Spawningpos.transform.rotation);
         obj.GetComponent<Rigidbody2D>().velocity = direction * bullet_Speed;
        //add particle effect;

    }

   
}
