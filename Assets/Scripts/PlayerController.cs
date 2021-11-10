using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 10; // Player move speed
    [SerializeField]
    private float rotateSpeed = 5; // Player rotate speed
    [SerializeField]
    private float jumpPower = 10; // Player hump power
    private Rigidbody rb;
    private bool pushJampButton = false;
    private bool isGround = false;
    

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        this.transform.Rotate(new Vector3(0, rotateSpeed * h * Time.deltaTime, 0));
        if (Input.GetKey(KeyCode.UpArrow)) {
            transform.position += transform.forward * moveSpeed * Time.deltaTime;
        }

        pushJampButton = Input.GetKeyDown(KeyCode.Space);
        
    }

    private void FixedUpdate() {
        if (pushJampButton&&isGround) {
            rb.AddForce(new Vector3(0, jumpPower, 0), ForceMode.Impulse);
            isGround = false;
        }
    }

    private void OnCollisionEnter(Collision collision) {
        if(collision.gameObject.tag == "Ground") {
            isGround = true;
        }
    }


}
