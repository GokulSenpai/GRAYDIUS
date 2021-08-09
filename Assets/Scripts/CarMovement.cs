using UnityEngine;

public class CarMovement : MonoBehaviour
{
    public Animator anim;
    public static bool carMove = false;
    private static readonly int MoveCar = Animator.StringToHash("MoveCar");

    // Update is called once per frame
    private void Update()
    {
        if(carMove)
        {
            anim.SetTrigger(MoveCar);
        }
    }
}
