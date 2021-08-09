using System.Collections;
using UnityEngine;

public class RayCastTeleport : MonoBehaviour
{
    private Animator _animator;

    public AudioSource jump1;
    public AudioSource jump2;

    private bool _canJump = true;

    public float rayCastRange = 9f;

    private GameObject _temp;

    private LineRenderer _lineRender;
    private SpriteRenderer _sr;
    
    public GameObject lineGameObject;
    
    private static readonly int IsIdle = Animator.StringToHash("isIdle");
    private static readonly int IsJumping = Animator.StringToHash("isJumping");

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _sr = GetComponent<SpriteRenderer>();
        _lineRender = lineGameObject.GetComponent<LineRenderer>();
        _lineRender.enabled = false;
        _lineRender.useWorldSpace = true;
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
            _lineRender.SetPosition(0, lineGameObject.transform.position);

            if (rayHit && rayHit.collider.gameObject.CompareTag("Teleport"))
            {
                _lineRender.SetPosition(1, rayHit.collider.gameObject.transform.position);
            }
            else
            {
                _lineRender.SetPosition(1, Camera.main.ScreenToWorldPoint(Input.mousePosition));
            }

            _lineRender.enabled = true;
        }
        if(Input.GetMouseButtonUp(0))
        {
            _lineRender.enabled = false;
            Teleport(rayHit);
        }
    }

    private void Teleport(RaycastHit2D rayHit)
    { 
        if (rayHit && rayHit.collider.gameObject.CompareTag("Teleport") && _canJump)
        {
            StartCoroutine(Dissolve.Disappear(60));
            _animator.SetTrigger(IsJumping);
            _canJump = false;
            _temp = rayHit.collider.gameObject; 
            jump1.Play();
            StartCoroutine(DelayAnimation());
        }
    }

    public IEnumerator DelayAnimation()
    {
        jump2.PlayDelayed(0.21f);
        yield return new WaitForSeconds(0.77f);

        transform.position = _temp.transform.position;
        transform.rotation = _temp.transform.rotation;

        StartCoroutine(Dissolve.Reappear(60));

        _animator.SetBool(IsIdle, true);
        _canJump = true;
    }
}
