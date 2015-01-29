using System.Linq.Expressions;
using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour
{

    //Public Vars
    
    public float Speed;
	public float RotationSpeed;

    //Private Vars
	[SerializeField]
	private Camera _camera;
    private Vector3 _mousePosition;
    private Vector3 _direction;
    private float _distanceFromObject;

    private void Update()
    {

#region Mouse Control

//				_mousePosition = _camera.ScreenToWorldPoint (new Vector2 (Input.mousePosition.x, Input.mousePosition.y));
//				//Debug.Log(Input.mousePosition);
//				//Rotates toward the mouse
//
//				_direction = _mousePosition - transform.position;
//				_direction.Normalize ();
//		      
//				float rot = Mathf.Atan2 (_direction.y, _direction.x) * Mathf.Rad2Deg - 90;//Mathf.PI;
//				transform.rotation = Quaternion.AngleAxis (rot, Vector3.forward); 
//
//				//Judge the distance from the object and the mouse
//				_distanceFromObject = (Input.mousePosition - _camera.WorldToScreenPoint (transform.position)).magnitude;
//		      
//		      
//
//				if (Input.GetKey (KeyCode.W)) {
//						Debug.Log ("Key down [W]");
//
//						var targetPosition = new Vector2 (_mousePosition.x, _mousePosition.y);
//						Debug.Log ("Distance: " + _distanceFromObject);
//						if (_distanceFromObject > 25) {
//								transform.position = Vector2.MoveTowards (transform.position, targetPosition, Speed * Time.deltaTime);
//						} else {
//								transform.position = transform.position;
//						}
//		          
//				}
//
//				if (Input.GetKey (KeyCode.S)) {
//						Debug.Log ("Key down [S]");
//						
//						var targetPosition = new Vector2 (_mousePosition.x, _mousePosition.y);
//
//						Debug.Log ("Distance" + _distanceFromObject);
//
//						if (_distanceFromObject > 25) {
//								transform.position = Vector2.MoveTowards (transform.position, targetPosition, -Speed * Time.deltaTime);
//						} else {
//								transform.position = transform.position;
//						}
//			
//				}

#endregion
				

#region Keyboard Control

		// поворот корабля
		Quaternion _rotation = transform.rotation;
		float z = _rotation.eulerAngles.z;
		z -= Input.GetAxis("Horizontal") * RotationSpeed * Time.deltaTime;
		_rotation = Quaternion.Euler(0, 0, z);
		transform.rotation = _rotation;
		
		// корабль летит вперед в зависимости от поворота
		Vector3 _position = transform.position;
		Vector3 velocity = new Vector3(0, Input.GetAxis("Vertical") * Speed * Time.deltaTime, 0);
		_position += _rotation * velocity;
		transform.position = _position;


#endregion
		
	}
	
	void Awake()
	{
		
	}
	
	void Start ()
	{
		_camera = Camera.main;
	}
	


}
