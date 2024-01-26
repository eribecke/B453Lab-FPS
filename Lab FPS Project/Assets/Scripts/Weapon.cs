using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{

    [SerializeField] protected string gunName;
    [SerializeField] protected int currentBullets;
    [SerializeField] protected int maxBullets;
    [SerializeField] protected GameObject bulletHole;
    [SerializeField] protected GameObject particles;
    [SerializeField] protected int bulletsInInventory;
    private int storedBullets;
    private PlayerController playerController;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public virtual void Shoot()
    {
        if (currentBullets > 0)
        {
            RaycastHit hit;
            if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, Mathf.Infinity))
            {
                GameObject decal = Instantiate(bulletHole, hit.point, Quaternion.identity);
                GameObject particle = Instantiate(particles, hit.point, Quaternion.identity);
                decal.transform.forward = -hit.normal;
                decal.transform.Translate(Vector3.back * 0.01f);
                Vector3 worldPosition = decal.transform.position;
                Quaternion worldRotation = decal.transform.rotation;
                decal.transform.SetParent(hit.transform);
                decal.transform.position = worldPosition;
                decal.transform.rotation = worldRotation;

                particle.transform.forward = -hit.normal;
                particle.transform.Translate(Vector3.back * 0.01f);
                particle.transform.position = worldPosition;
                particle.transform.rotation = worldRotation;
                particle.transform.SetParent(hit.transform);
                ParticleSystem p = particle.GetComponent<ParticleSystem>();
                p.Play();


                currentBullets--;
            }
        }
    }

    public virtual int Reload(int rounds)
    {
        storedBullets = playerController.BulletsObtained();
        if (currentBullets < maxBullets)
        {
            currentBullets += rounds;

            int roundsUsed = maxBullets - currentBullets;
            int roundsLeftover = rounds - roundsUsed;

            if(currentBullets > maxBullets)
            {
                currentBullets = maxBullets;
            }

            return roundsLeftover;
        }
        else
        {
            return rounds;
        }

    }
}
