using UnityEngine;

public class Movement : MonoBehaviour
{
    private float currentSpeed;
    private CharacterController characterController;
    private float initialYPosition;

    [Header("Movement")]
    [Tooltip("Horizontal Speed")]
    [SerializeField] private float moveSpeed;

    [Tooltip("Rate of change for moveSpeed")]
    [SerializeField] private float acceleration;

    [Tooltip("Deceleration rate when no input is provided")]
    [SerializeField] private float Deceleration;

    [SerializeField] private HandlingInput inputHandler;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        initialYPosition = transform.position.y;

        inputHandler = GetComponent<HandlingInput>();
    }

    void Update()
    {
        // Get the inputVector from the inputHandler
        Vector3 inputVector = inputHandler.InputVector;
        Move(inputVector);
    }

    private void Move(Vector3 inputVector)
    {
        if (inputVector == Vector3.zero)
        {
            if (currentSpeed > 0)
            {
                currentSpeed -= Deceleration * Time.deltaTime;
                currentSpeed = Mathf.Max(currentSpeed, 0);
            }
        }
        else
        {
            currentSpeed = Mathf.Lerp(currentSpeed, moveSpeed, Time.deltaTime * acceleration);
        }

        Vector3 movement = inputVector.normalized * currentSpeed * Time.deltaTime;
        characterController.Move(movement);
        transform.position = new Vector3(transform.position.x, initialYPosition, transform.position.z);
    }
}
