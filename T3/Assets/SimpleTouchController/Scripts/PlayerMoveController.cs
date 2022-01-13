using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class PlayerMoveController : MonoBehaviour {

	public SimpleTouchController leftController;
	public float speedMovements = 5f;
	public float speedProgressiveLook = 3000f;

	private Rigidbody _rigidbody;

	void Awake()
	{
		_rigidbody = GetComponent<Rigidbody>();
	}
	void Update()
	{
		_rigidbody.MovePosition(transform.position + (transform.forward * leftController.GetTouchPosition.y * Time.deltaTime * speedMovements) +
			(transform.right * leftController.GetTouchPosition.x * Time.deltaTime * speedMovements) );
	}


}
