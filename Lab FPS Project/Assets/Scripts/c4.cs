using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class c4 : MonoBehaviour
{
    // Start is called before the first frame update

    public float radius = 5f;
    public float power = 500;
    public Boolean blown = false;
    [SerializeField] ParticleSystem explosion;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void TriggerC4()
    {
        Vector3 position = transform.position;
        Collider[] hitColliders = Physics.OverlapSphere(position, radius);
        foreach (Collider thing in hitColliders)
        {
            if (thing.GetComponent<Rigidbody>())
            {
                Rigidbody rb = thing.GetComponent<Rigidbody>();
                rb.AddExplosionForce(power, position, radius, 0.0f, ForceMode.Impulse);
                blown = true;
                

            }

        }
        explosion.Play();
    }
}
