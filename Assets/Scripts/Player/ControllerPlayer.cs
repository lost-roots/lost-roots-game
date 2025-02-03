using UnityEngine;

public class ControllerPlayer : MonoBehaviour
{
    private CharacterController controller;
    [SerializeField] private float speed;

    private Animator animator;
    private Vector3 gravity = new Vector3(0, -9.81f, 0);

    void Start()
    {
        controller = GetComponent<CharacterController>();
        // animator = GetComponent<Animator>();
    }

    void Update()
    {
        float horizontalMovement = Input.GetAxis("Horizontal");
        float verticalMovement = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontalMovement, 0, verticalMovement);
        controller.Move(movement.normalized * Time.deltaTime * speed);
        controller.Move(gravity * Time.deltaTime);

        if (movement != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(movement);
            transform.rotation = Quaternion.Slerp(transform.rotation, toRotation, Time.deltaTime * 10f);
        }

        // animator.SetBool("isWalking", movement != Vector3.zero);
    }
}
