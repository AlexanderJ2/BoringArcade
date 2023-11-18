using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Player : MonoBehaviour
{
    //Money
    public int money = 0;

    //Movement
    public CharacterController controller;
    public Transform cam;
    [SerializeField] float speed = 6f;
    float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    
    void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        //Using unity's old controller system
        float horizontal = Input.GetAxisRaw("Horizontal");
        float Vertical = Input.GetAxisRaw("Vertical");
        Animation.Play("walk");

        Vector3 direction = new Vector3(horizontal, 0f, Vertical); //Uppdates position(Moves player)
    
        if (direction.magnitude >= 0.1f)//no need for anim here
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward; //Moves with camera angle
            // controller.Move(moveDir.normalized * speed * Time.deltaTime);

            Vector3 pos = this.transform.position;
            pos += (moveDir.normalized * speed * Time.deltaTime);
            this.transform.position = pos;
        }
    }
}
