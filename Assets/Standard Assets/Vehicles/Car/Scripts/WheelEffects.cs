using System.Collections;
using UnityEngine;

namespace Assets.Standard_Assets.Vehicles.Car.Scripts
{
    [RequireComponent(typeof(AudioSource))]
    public class WheelEffects : MonoBehaviour
    {
        public Transform SkidTrailPrefab;
        public static Transform SkidTrailsDetachedParent;
        public ParticleSystem SkidParticles;
        public bool Skidding { get; private set; }
        public bool PlayingAudio { get; private set; }


        private AudioSource _mAudioSource;
        private Transform _mSkidTrail;
        private WheelCollider _mWheelCollider;


        private void Start()
        {
            SkidParticles = transform.root.GetComponentInChildren<ParticleSystem>();

            if (SkidParticles == null)
            {
                Debug.LogWarning(" no particle system found on car to generate smoke particles");
            }
            else
            {
                SkidParticles.Stop();
            }

            _mWheelCollider = GetComponent<WheelCollider>();
            _mAudioSource = GetComponent<AudioSource>();
            PlayingAudio = false;

            if (SkidTrailsDetachedParent == null)
            {
                SkidTrailsDetachedParent = new GameObject("Skid Trails - Detached").transform;
            }
        }


        public void EmitTyreSmoke()
        {
            SkidParticles.transform.position = transform.position - transform.up * _mWheelCollider.radius;
            SkidParticles.Emit(1);
            if (!Skidding)
            {
                StartCoroutine(StartSkidTrail());
            }
        }


        public void PlayAudio()
        {
            _mAudioSource.Play();
            PlayingAudio = true;
        }


        public void StopAudio()
        {
            _mAudioSource.Stop();
            PlayingAudio = false;
        }


        public IEnumerator StartSkidTrail()
        {
            Skidding = true;
            _mSkidTrail = Instantiate(SkidTrailPrefab);
            while (_mSkidTrail == null)
            {
                yield return null;
            }
            _mSkidTrail.parent = transform;
            _mSkidTrail.localPosition = -Vector3.up * _mWheelCollider.radius;
        }


        public void EndSkidTrail()
        {
            if (!Skidding)
            {
                return;
            }
            Skidding = false;
            _mSkidTrail.parent = SkidTrailsDetachedParent;
            Destroy(_mSkidTrail.gameObject, 10);
        }
    }
}

