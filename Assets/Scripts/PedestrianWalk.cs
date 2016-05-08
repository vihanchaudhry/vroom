using UnityEngine;

namespace Assets.Scripts
{
    public class PedestrianWalk : MonoBehaviour {

        public GameObject destination;
        protected Vector3 startPos, destPos;
        protected bool run;
        protected float t;
        protected bool fail;
        protected PlayerProperties pp;
        public ParticleSystem indicator;
        protected ParticleSystem ps;

        // Use this for initialization
        void Start () {
            startPos = transform.position;
            destPos = destination.transform.position;
            t = 0;
            run = false;
            fail = false;
        }
	
        // Update is called once per frame
        void Update () {
            if(run)
            {
                transform.position = Vector3.Lerp(startPos, destPos, t);
                if(t > 1)
                {
                    run = false;
                    Destroy(transform.parent.gameObject, 1.5f);
                    this.enabled = false;
                }
                else if(t > 0.78 && t < 0.9)
                {
                    if(pp.GetComponent<Rigidbody>().velocity != Vector3.zero)
                    {
                        GameManager.Instance.GameOverMenu(GameManager.Errors.HitPedestrian);
                    }
                }
                else if(t > 0.56)
                {
                    if (pp.GetComponent<Rigidbody>().velocity != Vector3.zero && !fail)
                    {
                        fail = true;
                        Debug.Log("6");
                        GameManager.Instance.AddDemerit(1);
                    }
                }
                t += Time.unscaledDeltaTime/6;
            
            
            }
        }

        public void TurnOn(PlayerProperties p)
        {
            ps = Instantiate(indicator, transform.parent.transform.position + indicator.transform.position, indicator.transform.rotation) as ParticleSystem;
            pp = p;
            run = true;
        }
    }
}
