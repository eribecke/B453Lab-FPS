using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kick : MonoBehaviour, Kickable
    
{
    [SerializeField] Vector3 recoilPower;

    // Start is called before the first frame update
    public void Kicked(PlayerController player)
    {
        player.kickRecoil(recoilPower);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {

            gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(0, 3, 10), ForceMode.Impulse);
            
        }
        if(other.gameObject.tag == "Breakable")
            {
                Destroy(other.gameObject);
            }
    }
}
