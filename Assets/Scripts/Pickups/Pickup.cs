using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Pickup : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Player player = other.GetComponent<Player>();
        if(player == null)
        {
            return;
        }

        Pick(player);
        Destroy(gameObject);
    }

    public abstract void Pick(Player owner);
}
