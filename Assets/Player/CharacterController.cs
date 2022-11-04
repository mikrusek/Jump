using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour {

    [SerializeField] private Transform GroundChecker;
    [SerializeField] private LayerMask WhatIsGround;

    [SerializeField] private bool is_on_Ground = false;
    [SerializeField] private bool AirControl = true;

    private bool FacingRight = false;


    public Rigidbody2D rb;
    public float jumpForce = 300f;

    private float GroundCheckerRadius = 0.05f;

    // Update is called once per frame
    void FixedUpdate() {
        


        Collider2D[] colliders = Physics2D.OverlapCircleAll(GroundChecker.position, GroundCheckerRadius, WhatIsGround);


        if (colliders.Length > 0){
            is_on_Ground = true;
        }


    }


    public void Move(float horizontalMove, bool space_clicked) {
        
        if (is_on_Ground || AirControl) {

            rb.velocity = new Vector3(horizontalMove, rb.velocity.y ,0);

            if (horizontalMove > 0 && !FacingRight) {
                Flip();
            }

            if (horizontalMove < 0 && FacingRight) {
                Flip();
            }
        }


        if (is_on_Ground && space_clicked) {
            is_on_Ground = false;
            rb.AddForce(new Vector2(0f, jumpForce));
        }
    }



    private void Flip() {
        FacingRight = !FacingRight;

        Vector3 skala = transform.localScale;
        skala.x *= -1;

        transform.localScale = skala;
    }
}
