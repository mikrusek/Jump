using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour {

    public Transform GunPoint;
    public float BulletForce;

    public GameObject Bullet;
    public float fireRate = 10;
    private float ReadyForNextShot;


    void Awake() {
        Debug.Log("Awake");
    }

    // Start is called before the first frame update
    void Start() {
        Debug.Log("Start");
    }

    // Update is called once per frame
    void Update() {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = (mousePos - (Vector2)GunPoint.position).normalized;

        if(Input.GetMouseButton(0)) {
            if (Time.time > ReadyForNextShot) {
                ReadyForNextShot = Time.time + 1/fireRate;
                shoot(direction);
            }
        }
    }

    void shoot(Vector2 direction) {
        GameObject BulletIns = Instantiate(Bullet, GunPoint.position, GunPoint.rotation);
        BulletIns.GetComponent<Rigidbody2D>().AddForce(direction * BulletForce);
        Destroy(BulletIns, 10);
    }
}
