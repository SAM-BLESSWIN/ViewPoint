using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class TutorialMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float turnspeed;
    [SerializeField] private GameObject _2dcam;
    [SerializeField] private float groundcheckdistance;
    [SerializeField] private LayerMask groundmask;
    [SerializeField] private GameObject key;
    

    private CharacterController charcontrol;
    private Animator anim;

    private bool IsGrounded;
    private Vector3 velocity;
    private Vector3 direction;
    private float gravity=-9.81f;

    private bool In2D;
    public bool Check2D
    { get { return In2D; } }

    private bool InTopDown;
    public bool CheckTD
    { get { return InTopDown; } }

    private bool Haskey = false;
    public bool Checkkey
    { get { return Haskey; } }

    private bool bMove2D;
    public bool Moved2D
    { get { return bMove2D; } }

    private bool bMovetopdown;
    public bool MovedTD
    { get { return bMovetopdown; } }

    private bool bcanmoveTD;
    public bool CanMoveTD
    { set { bcanmoveTD = value; } }


    private void Start()
    {
        charcontrol = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if(TutorialManager.Instance.IsInTutorial)
        {
            TutorialMovements();
        }
        else
        {
            PlayerMovements();
        }

        if (direction.magnitude > 0)
        {
            anim.SetBool("walk", true);
        }
        else
        {
            anim.SetBool("walk", false);
        }

        if (direction != Vector3.zero)
        {
            Quaternion newDirection = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, newDirection, Time.deltaTime * turnspeed);
        }

        IsGrounded = Physics.CheckSphere(transform.position, groundcheckdistance, groundmask);
        if (IsGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
    }

    private void TutorialMovements()
    {
        if(_2dcam.activeSelf)
        {
            MoveIn2D();
            if(direction.magnitude!=0)
            {
                bMove2D = true;
            }
        }
        else
        {
            if (bcanmoveTD)
            {
                MoveInTD();
                if (direction.magnitude != 0)
                {
                    bMovetopdown = true;
                }
            }
        }
    }


    private void PlayerMovements()
    {
        if (_2dcam.activeSelf)
        {
            MoveIn2D();
        }
        else
        {
            MoveInTD();
        }
    }
    
    private void MoveIn2D()
    {
        In2D = true;
        InTopDown = false;
        charcontrol.slopeLimit = 60f;

        float Xaxis = Input.GetAxis("Horizontal");
        direction = Xaxis * Vector3.right * speed * Time.deltaTime;
        charcontrol.Move(direction);

        velocity.y += gravity * Time.deltaTime;
        charcontrol.Move(velocity);
    }

    private void MoveInTD()
    {
        InTopDown = true;
        In2D = false;
        charcontrol.slopeLimit = 0;

        if (IsGrounded)
        {
            float Xaxis = Input.GetAxis("Horizontal");
            float Yaxis = Input.GetAxis("Vertical");
            direction = new Vector3(Xaxis, 0, Yaxis);
            charcontrol.Move(direction * speed * Time.deltaTime);
        }

        velocity.y += gravity * Time.deltaTime;
        charcontrol.Move(velocity);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Key"))
        {
            Haskey = true;
            Destroy(key);
        }

        if(other.gameObject.CompareTag("Door") && Haskey)
        {
            if (SceneManager.GetActiveScene().buildIndex < SceneManager.sceneCountInBuildSettings - 1)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
        }

    }

}

