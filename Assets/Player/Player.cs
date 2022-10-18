using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public float speed = 1.0f;
    public float jumpForce = 5.0f;

    public Rigidbody2D rb;

    [SerializeField]
    private bool isGround;

    // Start is called before the first frame update
    void Start() {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update() {
        //Debug.Log("update encji");
        move4();
    }


    void move1() {
        if (Input.GetKey(KeyCode.LeftArrow)){ 
            transform.position = transform.position + new Vector3(-1.0f * Time.deltaTime * speed, 0, 0);
        }
        if (Input.GetKey(KeyCode.RightArrow)){ 
            transform.position = transform.position + new Vector3(1.0f * Time.deltaTime * speed, 0, 0);
        }
    }

    void move2() {
        if (Input.GetKey(KeyCode.LeftArrow)){ 
            transform.Translate(-1.0f * Time.deltaTime * speed, 0, 0);
        }
        if (Input.GetKey(KeyCode.RightArrow)){ 
            transform.Translate(1.0f * Time.deltaTime * speed, 0, 0);
        }
    }

    void move3() {

        float Hdirect;
        float Jump;

        if((Hdirect = Input.GetAxis("Horizontal")) != 0) {
            
            if(Hdirect < 0)
                transform.Translate(-1.0f * Time.deltaTime * speed, 0, 0);
            if(Hdirect > 0)
                transform.Translate(1.0f * Time.deltaTime * speed, 0, 0);
        }
        if((Jump = Input.GetAxis("Jump")) != 0 && isGround) {   
            transform.Translate(0, 1.0f * jumpForce, 0);
        }
    }

     void move4() {
        float direction;
        float Jump;

        if((direction = Input.GetAxis("Horizontal")) != 0) {
            Vector2 v = new Vector2(direction * Time.deltaTime * speed, 0);
            rb.AddForce(v);
        }

        if(((direction = Input.GetAxis("Jump")) != 0) && isGround) {
            Vector2 v = new Vector2(0, direction * Time.deltaTime * jumpForce);
            rb.AddForce(v);
        }

     }

    void OnCollisionEnter2D(Collision2D col) {
        //Debug.Log("start kolizji");
        //Debug.Log(col);
        isGround = true;
    }

    void OnCollisionExit2D(Collision2D col) {
        isGround = false;
    }
}
