using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPad : MonoBehaviour
{
    [SerializeField]
    private float jumpSpeed = 15;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            Player playerComponent = other.GetComponent<Player>();
            playerComponent.Jump(jumpSpeed);
        }
    }
}
