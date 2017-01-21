using UnityEngine;

public class PlayerController : MonoBehaviour
{
	public float ForwardSpeed = 1.0f;
	public float TurnSpeed = 30.0f;
	public float AngleSmoothing = 2.0f;

    [SerializeField]
    float _Rotation;

    public Quaternion _RotationTarget = Quaternion.identity;

	void Update ()
	{
        ApplyInput();
        Move();
	}

    void ApplyInput()
    {
        _Rotation += Input.GetAxisRaw("Horizontal") * TurnSpeed;
    }

    public void AddRotation(float yRotation)
    {
        _Rotation += yRotation;
    }

    void Move()
    {
		transform.Translate(Vector3.forward* ForwardSpeed, Space.Self);
		transform.rotation = Quaternion.Slerp(transform.rotation,
            Quaternion.Euler(0f, _Rotation, 0f),
            Time.deltaTime * AngleSmoothing);
    }
}
