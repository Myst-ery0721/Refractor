using UnityEngine;

public class Colllision : MonoBehaviour
{
    [Header("Collision")]
    [SerializeField] LayerMask WallLayer;
    public Audio AudioFX;
    public ParticlesFX VisualFX;

    private void Awake()
    {
        AudioFX = GetComponent<Audio>();
        VisualFX = GetComponent<ParticlesFX>();
    }

    // Collision
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if ((WallLayer.value & (1 << hit.gameObject.layer)) > 0)
        {
            AudioFX.PlayAudioCLip();
            VisualFX.ParticleEffect();
        }
    }
}
