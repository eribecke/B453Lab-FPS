using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPickup : MonoBehaviour, IPickupable
{

    [SerializeField] int ammo;
    // Start is called before the first frame update

    public void Pickup(PlayerController player)
    {
        player.PickupAmmo(ammo);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            Pickup(other.gameObject.GetComponent<PlayerController>());
            Destroy(gameObject);
        }
    }
}
