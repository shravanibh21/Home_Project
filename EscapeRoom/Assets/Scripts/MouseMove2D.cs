using UnityEngine;
using System.Collections;
 
public class MouseMove2D : MonoBehaviour {
 
    private Vector3 mousePosition;
    public float moveSpeed = 0.5f;
    public bool isPickedUp = false;
 
    // Use this for initialization
    void Start () {
        
    }

    public void PickUp() {
        isPickedUp = true;
    }

    public void Drop() {
        isPickedUp = false;
    }
   
    // Update is called once per frame
    void Update () {
        if (isPickedUp) {
            if (Input.GetMouseButton(0)) {
                mousePosition = Input.mousePosition;
                mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
                transform.position = Vector2.Lerp(transform.position, mousePosition, moveSpeed);
            } else {
                this.Drop();
            }
        }
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.name == "Square")
        {
            Destroy(coll.gameObject);
        }
    }
}