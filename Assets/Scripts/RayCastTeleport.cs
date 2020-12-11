using System.Collections;
using UnityEngine;

public class RayCastTeleport : MonoBehaviour
{
    Animator animator;

    public AudioSource jump1;
    public AudioSource jump2;

    bool canJump = true;

    public float rayCastRange = 9f;

    GameObject temp;

    LineRenderer lineRender;
    SpriteRenderer sr;

    public GameObject lineGameObject;
    
    private static readonly int IsIdle = Animator.StringToHash("isIdle");
    private static readonly int IsJumping = Animator.StringToHash("isJumping");

    private void Start()
    {
        animator = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        lineRender = lineGameObject.GetComponent<LineRenderer>();
        lineRender.enabled = false;
        lineRender.useWorldSpace = true;
    }

    private void Update()
    {
        RayCast();
    }

    private void RayCast()
    {
        Vector2 trueScreenToWorld = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        RaycastHit2D rayHit = Physics2D.Raycast(transform.position, trueScreenToWorld, rayCastRange);

        if (Input.GetMouseButton(0))
        {    
            lineRender.SetPosition(0, lineGameObject.transform.position);

            if (rayHit && rayHit.collider.gameObject.tag == "Teleport")
            {
                lineRender.SetPosition(1, rayHit.collider.gameObject.transform.position);
            }
            else
            {
                lineRender.SetPosition(1, Camera.main.ScreenToWorldPoint(Input.mousePosition));
            }

            lineRender.enabled = true;
        }
        if(Input.GetMouseButtonUp(0))
        {
            lineRender.enabled = false;
            Teleport(rayHit);
        }
    }

    private void Teleport(RaycastHit2D rayHit)
    { 
        if (rayHit && rayHit.collider.gameObject.tag == "Teleport" && canJump)
        {
            StartCoroutine(Dissolve.Disappear(60));
            animator.SetTrigger(IsJumping);
            canJump = false;
            temp = rayHit.collider.gameObject;
            jump1.Play();
            StartCoroutine(DelayAnimation());
        }
    }

    public IEnumerator DelayAnimation()
    {
        jump2.PlayDelayed(0.21f);
        yield return new WaitForSeconds(0.77f);

        transform.position = temp.transform.position;
        transform.rotation = temp.transform.rotation;

        StartCoroutine(Dissolve.Reappear(60));

        animator.SetBool(IsIdle, true);
        canJump = true;
    }
}
