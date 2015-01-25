using System.Linq.Expressions;
using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour
{

    //Public Vars
    public Camera camera;
    public float speed;

    //Private Vars
    private Vector3 mousePosition;
    private Vector3 direction;
    private float distanceFromObject;

    private void Update()
    {
        mousePosition = camera.ScreenToWorldPoint(new Vector2(Input.mousePosition.x, Input.mousePosition.y));
        //Debug.Log(Input.mousePosition);
        //Rotates toward the mouse

        direction = mousePosition - transform.position;
        direction.Normalize();
        Debug.Log("main"+direction);
        float rot = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90;//Mathf.PI;
        transform.rotation = Quaternion.AngleAxis(rot, Vector3.forward); 

        //Judge the distance from the object and the mouse
        distanceFromObject = (Input.mousePosition - camera.WorldToScreenPoint(transform.position)).magnitude;

      

        if (Input.GetKeyDown(KeyCode.W))
        {
            Debug.Log("Key down");
            direction = new Vector2(mousePosition.x - transform.position.x,mousePosition.y-transform.position.y).normalized;
            Debug.Log("if"+direction);
            rigidbody.AddForce(direction * speed * Time.deltaTime);
           
            
        }

    }

    // Ray ray = cam.ScreenPointToRay(Input.mousePosition);

            //RaycastHit hit = new RaycastHit();
            //if (Physics.Raycast(ray, out hit))
            //{
            //    Vector3 rot = transform.eulerAngles;
            //    transform.LookAt(hit.point);
            //    transform.eulerAngles = new Vector3(rot.x, transform.eulerAngles.y - 90, rot.z);
            //}

   

    // Use this for initialization
	void Start ()
	{
	    
	}
	


}
