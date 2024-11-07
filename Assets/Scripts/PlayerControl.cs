using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    Rigidbody Vel;
    [SerializeField] float speed = 3f;
    [SerializeField] float jump = 7f;
    [SerializeField] int maxJump = 2;
    [SerializeField] AudioSource jumpSound;
    [SerializeField] AudioSource killSound;
    int jumprem = 0;
    void Start()
    {
        Vel = GetComponent<Rigidbody>();
    }
    void Update()
    {
        float HorIn = Input.GetAxis("Horizontal");
        float VerIn = Input.GetAxis("Vertical");
        
        Vel.velocity = new Vector3(Vel.velocity.x,Vel.velocity.y, HorIn * speed );
        
        if ((Input.GetKeyDown(KeyCode.Space)) && (jumprem>0))
        {
            Jump();
            jumprem -= 1;
        }
    }

    void Jump() // прыжок
    {
        Vel.velocity = new Vector3(Vel.velocity.x, jump, Vel.velocity.z);
        jumpSound.Play();
    }
    public void OnCollisionEnter(Collision collision) // проверка приземления и двойные прыжки
    {
        if (collision.gameObject.tag == "Floor")
        {
            jumprem = maxJump;
        }
    }
    
}
