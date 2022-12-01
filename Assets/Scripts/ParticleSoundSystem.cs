using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

[RequireComponent(typeof(ParticleSystem))]
public class FireworksParticleSoundSystem : MonoBehaviour
{

    AudioSource audioSoure;

    void Start()
    {
        audioSoure = GetComponent<AudioSource>();
    }

    void Update()
    {
        while (true)
        {
            audioSoure.Play();
        }
    }

    private void ApplyExplosionForceInArea(Vector3 position, bool applyPhysicsForce = true, bool applyShakeEffect = true)
    {
        audioSoure.Play();
    }

    private class ParticleDelta
    {
        public IList<ParticleSystem.Particle> Added { get; set; } = new List<ParticleSystem.Particle>();
        public IList<ParticleSystem.Particle> Removed { get; set; } = new List<ParticleSystem.Particle>();
    }
}