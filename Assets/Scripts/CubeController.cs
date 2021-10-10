using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour
{

    public float speed = 5f;
    public float jumpSpeed = 16f;
    public float jumpCoolDown = 0f;

    // Update is called once per frame
    void Update()
    {
        // on va chercher le composant rigidbody associé à cet objet
        Rigidbody body = GetComponent<Rigidbody>();

        // ETAPE2 : contrôle au clavier
        Vector3 move = new Vector3();
        move.x = speed * Input.GetAxis("Horizontal"); // clavier
        move.z = speed * Input.GetAxis("Vertical");   // clavier
        move.y = body.velocity.y;                     // gravité normale

        // saut : solution élaborée
        jumpCoolDown = jumpCoolDown - Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.Space) && jumpCoolDown <= 0)
        {
            jumpCoolDown = 1.5f;
            move.y = jumpSpeed;
        }
        body.velocity = move;
    }   

}