using UnityEngine;

public class HandlingInput : MonoBehaviour
{
    [Header("Controls")]
    [Tooltip("use Keys to move")]
    [SerializeField] private KeyCode forwardKey;
    [SerializeField] private KeyCode backwardKey;
    [SerializeField] private KeyCode leftKey;
    [SerializeField] private KeyCode rightKey;
    private Vector3 inputVector;

    // Public getter for inputVector
    public Vector3 InputVector => inputVector;

    void Update()
    {
        HandleInput();
    }

    public void HandleInput()
    {
        float xInput = 0;
        float zInput = 0;
        if (Input.GetKey(forwardKey))
        {
            zInput++;
        }
        if (Input.GetKey(backwardKey))
        {
            zInput--;
        }
        if (Input.GetKey(leftKey))
        {
            xInput--;
        }
        if (Input.GetKey(rightKey))
        {
            xInput++;
        }
        inputVector = new Vector3(xInput, 0, zInput);
    }
}
