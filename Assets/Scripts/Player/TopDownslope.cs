using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownslope : MonoBehaviour
{
    private PlayerMovement movement;
    [SerializeField] BoxCollider[] _2dblockers;

    private void Start()
    {
        movement = gameObject.GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        if (movement.CheckTD)
        {
            foreach (BoxCollider bc in _2dblockers)
            {
                bc.enabled = true;
            }
        }
        else
        {
            foreach (BoxCollider bc in _2dblockers)
            {
                bc.enabled = false;
            }
        }
    }
}
