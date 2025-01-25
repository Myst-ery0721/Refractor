using UnityEngine;

public class ParticlesFX : MonoBehaviour
{
    [Header("Effects")]
    [SerializeField] private ParticleSystem partSys;


    // Particle Effect
    public void ParticleEffect()
    {
        partSys.Play();
    }
}
