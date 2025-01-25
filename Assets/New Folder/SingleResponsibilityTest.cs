using UnityEngine;

public class SingleResponsibilityTest : MonoBehaviour
{
    // Movement, Particles effects, Input handling, Audio, Collision

    [Header("Movement")]
    [Tooltip("Horizontal Speed")]
    [SerializeField] private float moveSpeed;

    [Tooltip("Rate of change for moveSpeed")]
    [SerializeField] private float acceleration;

    [Tooltip("Deceleration rate when no input is provided")]
    [SerializeField] private float Deceleration;

    [Header("Controls")]
    [Tooltip("use Keys to move")]
    [SerializeField] private KeyCode forwardKey;
    [SerializeField] private KeyCode backwardKey;
    [SerializeField] private KeyCode leftKey;
    [SerializeField] private KeyCode rightKey;

    [Header("Audio")]
    [SerializeField] private AudioClip audioClip;
    [SerializeField] private AudioSource audioSource;

    [Header("Effects")]
    [SerializeField] private ParticleSystem partSys;

    [Header("Collision")]
    [SerializeField] LayerMask WallLayer;

    private Vector3 inputVector;
    private float currentSpeed;
    private CharacterController characterController;
    private float initialYPosition;

    private void Awake()
    {   
        characterController = GetComponent<CharacterController>();
        initialYPosition = transform.position.y;
    }

   
    void Start()
    {
        
    }

    void Update()
    {
        HandleInput();
        Move(inputVector);
    }


    // Handling Input
    private void HandleInput()
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
        inputVector = new Vector3 (xInput, 0, zInput);

    }

    // Movement
    private void Move(Vector3 inputVector)
    {

        if (inputVector == Vector3.zero)
        {
            if(currentSpeed > 0)
            {
                currentSpeed -= Deceleration * Time.deltaTime;
                currentSpeed = Mathf.Max(currentSpeed, 0);
            }
        }
        else
        {
            currentSpeed = Mathf.Lerp(currentSpeed, moveSpeed,Time.deltaTime * acceleration);
        }

        Vector3 movement = inputVector.normalized * currentSpeed * Time.deltaTime;
        characterController.Move(movement);
        transform.position = new Vector3(transform.position.x,initialYPosition, transform.position.z);
    }

    //Aduio 
    private void PlayAudioCLip()
    {
        audioSource.Play();
    }

    // Particle Effect
    private void ParticleEffect()
    {
        partSys.Play();
    }

    // Collision
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if((WallLayer.value & (1 << hit.gameObject.layer)) > 0)
        {
            PlayAudioCLip();
            ParticleEffect();
        }
    }
}
