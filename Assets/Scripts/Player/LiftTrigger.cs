using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiftTrigger : MonoBehaviour
{

    [SerializeField] private GameObject lift;
    [SerializeField] private float liftspeed;
    [SerializeField] private float liftdistance;
  //  [SerializeField] private ParticleSystem dust;

    bool Inlift = false;
    bool Canelevate = false;
    private Vector3 Initialpos;
    private PlayerMovement movement;


    private void Start()
    {
        movement = GetComponent<PlayerMovement>();
        Initialpos = lift.transform.position;
    }

    void Update()
    {
        if (Canelevate)
        {
            if (lift.transform.position.y <= liftdistance)
            {
                lift.transform.position += Vector3.up * Time.deltaTime * liftspeed;
            }
            else
            {
            //   dust.Play();
                Invoke("resetlift", 10f);
            }
        }
    }

    private void resetlift()
    {
        Canelevate = false;
        lift.transform.position = Initialpos;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Lift") && movement.Checkkey)
        {
            Canelevate = true;
        }
    }
}