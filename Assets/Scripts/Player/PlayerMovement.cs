using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
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
    private float gravity = -9.81f;

    private bool In2D;
    public bool Check2D
    { get { return In2D; } }

    private bool InTopDown;
    public bool CheckTD
    { get { return InTopDown; } }

    private bool Haskey = false;
    public bool Checkkey
    { get { return Haskey;  } }

    private void Start()
    {
        charcontrol = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        
        PlayerMovements();

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
            transform.rotation = Quaternion.Slerp(transform.rotation,newDirection,Time.deltaTime*turnspeed);
        }

        IsGrounded = Physics.CheckSphere(transform.position, groundcheckdistance, groundmask);
        if (IsGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
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
        charcontrol.Move(velocity * Time.deltaTime);
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
        if (other.gameObject.CompareTag("Spikes"))
        {
            anim.SetTrigger("Dead");
            charcontrol.enabled = false;

            Invoke("Reload", 3f);
        }

        if(other.gameObject.CompareTag("Key"))
        {
            Haskey = true;
            Destroy(key);
        }

        if (other.gameObject.CompareTag("Door") && Haskey)
        {
            if (SceneManager.GetActiveScene().buildIndex < SceneManager.sceneCountInBuildSettings - 1)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
            else
            {
                SceneManager.LoadScene(0);
            }
        }
    }

    private void Reload()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void OnTriggerStay(Collider other)
    {
        if (In2D && other.gameObject.CompareTag("level2keytrigger"))
        {
            // keybox.size = new Vector3(1.5f, 1f, 1f);
            gameObject.transform.position = new Vector3(5.51f, 1.3f, 4f);
        }

        if (In2D && other.gameObject.CompareTag("level4keytrigger"))
        {
            gameObject.transform.position = new Vector3(transform.position.x, transform.position.y, 9.25f);
        }

        if(In2D && other.gameObject.CompareTag("level5slopetrigger"))
        {
            gameObject.transform.position = new Vector3(transform.position.x, transform.position.y, 7.5f);
        }

        if(In2D && Haskey && other.gameObject.CompareTag("level5doortrigger"))
        {
            gameObject.transform.position = new Vector3(transform.position.x, transform.position.y, 10.5f);
        }
    }
}

