using UnityEngine;

namespace Assets.Scripts
{
    public class StopSign : MonoBehaviour
    {

        private bool _enabled = true;
        private bool _part2 = false;
        //private bool temp = false;
        public ParticleSystem left, right;
        private ParticleSystem leftPS, rightPS;
        private Vector3 offset1, offset2;
        public bool temp = false;
        public Transform a, b;
        // Use this for initialization
        void Start()
        {
            offset2 = new Vector3(25, 10, -60);
            offset1 = new Vector3(25, 10, 40);
        }

        // Update is called once per frame
        void Update()
        {

            if (_part2)
            {
                if (leftPS.startSpeed >= 1 && rightPS.startSpeed >= 1)
                {
                    Destroy(leftPS);
                    Destroy(rightPS);
                    _enabled = false;
                    _part2 = false;
                }
            }
        }

        void OnTriggerStay(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                if (other.GetComponent<Rigidbody>().velocity == Vector3.zero && !_part2 && _enabled)
                {
                    
                    _part2 = true;
                    if (!temp)
                    {
                        leftPS =
                            Instantiate(left, transform.position + offset1, left.transform.rotation) as ParticleSystem;
                        rightPS =
                            Instantiate(right, transform.position + offset2, right.transform.rotation) as ParticleSystem;
                    }
                    else
                    {
                        leftPS =
                            Instantiate(left, a.position, left.transform.rotation) as ParticleSystem;
                        rightPS =
                            Instantiate(right, b.position, right.transform.rotation) as ParticleSystem;
                    }
                    other.GetComponent<PlayerProperties>().startRayCasting();
                }
            }
        }

        void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                if (!other.GetComponentInParent<PlayerProperties>().getImm())
                {
                    if (_enabled)
                    {
                        if (!_part2)
                        {
                            GameManager.Instance.AddDemerit(1);
                            Debug.Log("1");
                        }
                        Debug.Log("2");
                        GameManager.Instance.AddDemerit(1);
                        _part2 = true;
                        // temp = true;
                    }
                    else
                    {
                        // temp = false;
                        _enabled = true;
                    }
                    other.GetComponentInParent<PlayerProperties>().stopRayCasting();
                    Destroy(leftPS);
                    Destroy(rightPS);
                    Destroy(gameObject);
                }
            }
        }
    }
}
