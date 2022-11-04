using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;

    public float runSpeed = 40f;
    private bool space_down = false;
    private float horizontalMove = 0f;

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;


        if (Input.GetKeyDown(KeyCode.Space)) {
            space_down = true;
        }
        
    }

    void FixedUpdate(){
        controller.Move(horizontalMove, space_down);
        space_down = false;
    }
}
