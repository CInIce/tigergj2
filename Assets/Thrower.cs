using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thrower : MonoBehaviour
{
    bool hasGrabbed;
    RaycastHit2D hit;
    [SerializeField] float distance = 2;
    [SerializeField] float throwForce;
    GameObject throwableObject;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if(Input.GetKeyDown(KeyCode.Z)){
            if(!hasGrabbed){
                Physics2D.queriesStartInColliders = false;
                hit = Physics2D.Raycast(transform.position, transform.right,distance);
                
                
                if(hit.collider!= null){
                    hasGrabbed = true;
                }
            }else{
                hasGrabbed = false;
            }

            
            
        }

        if(hasGrabbed){
                hit.collider.gameObject.transform.position = transform.GetChild(0).position;
                throwableObject = hit.collider.gameObject;
        }

        if(Input.GetKeyDown(KeyCode.X) && hasGrabbed){
            ThrowObject();
        }
    }


    private void ThrowObject(){
        Vector2 input;
        input.x = Input.GetAxis("Horizontal");
        input.y = Input.GetAxis("Vertical");
        
        if(throwableObject != null){
        throwableObject.GetComponent<Rigidbody2D>().velocity = transform.right * throwForce;
        // Debug.DrawRay(transform.position, new Vector2(Input.GetAxis("Horizontal"),Input.GetAxis("Vertical")), Color.red);
        }
        hasGrabbed=false;

    }

    private void OnDrawGizmos() {
        Gizmos.color = Color.green;
        Gizmos.DrawLine(transform.position, transform.position+Vector3.right*transform.localScale.x*distance);
    }
}
