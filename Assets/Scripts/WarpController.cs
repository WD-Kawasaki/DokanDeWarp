using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarpController : MonoBehaviour
{
    [SerializeField]
    private GameObject toDokan = null;
    private bool isPushWarpButton = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        isPushWarpButton = Input.GetKeyDown(KeyCode.DownArrow);
        
       
    }

    private void OnCollisionStay(Collision collision) {
        if(collision.gameObject.tag == "Player" && this.transform.position.y < collision.gameObject.transform.position.y && isPushWarpButton) {
            collision.gameObject.transform.position = toDokan.transform.position + new Vector3(0, 0.01f, 0);
        }
    }

}
