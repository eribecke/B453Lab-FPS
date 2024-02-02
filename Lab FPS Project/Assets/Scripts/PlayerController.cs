using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    public float speed;
    public float sensitivity;
    public float sprintSpeed;

    private float moveFB;
    private float moveLR;
    private float rotX;
    private float rotY;
    private CharacterController cc;
    private Camera _camera;
    private int bulletInv;

   
    [SerializeField] c4 myC4;

    public void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        cc = gameObject.GetComponent<CharacterController>();
        _camera = gameObject.transform.GetChild(0).transform.gameObject.GetComponent<Camera>();
    }

    private void Update()
    {
        if(!PauseMenu.instance.isPaused)
        {
             Move();
        }
       

        if (Input.GetKeyDown(KeyCode.C))
        {
            myC4.TriggerC4();
        }
    }

    private void Move()
    {
        float movementSpeed = speed;
        if(Input.GetKey(KeyCode.LeftShift))
        {
            movementSpeed = sprintSpeed;
        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            movementSpeed = speed;
        }

        //Grabbing axis and mouse movement

        moveFB = Input.GetAxis("Vertical") * movementSpeed;
        moveLR = Input.GetAxis("Horizontal") * movementSpeed;
        rotX = Input.GetAxis("Mouse X") * sensitivity;
        rotY -= Input.GetAxis("Mouse Y") * sensitivity;

        //Clamping Y Rotation
        rotY = Mathf.Clamp(rotY, -60f, 60f);

        //Creating movement vector
        Vector3 movement = new Vector3(moveLR, 0, moveFB).normalized * movementSpeed;

        //Rotating the camera
        transform.Rotate(0, rotX, 0);
        _camera.transform.localRotation = Quaternion.Euler(rotY, 0, 0);

        movement = transform.rotation * movement;
        cc.Move(movement * Time.deltaTime);
    }

    public void PickupAmmo(int amount)
    {
        bulletInv += amount;
        
    }

    public int BulletsObtained()
    {
        return bulletInv;
    }

    public void kickRecoil(Vector3 recoilPower)
    {
        gameObject.GetComponent<Rigidbody>().AddForce(recoilPower);
    }

   

   

    
}
