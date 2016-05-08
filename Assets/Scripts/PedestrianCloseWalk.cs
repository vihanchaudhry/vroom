using UnityEngine;

namespace Assets.Scripts
{
    public class PedestrianCloseWalk : Assets.Scripts.PedestrianWalk {

        private bool can = true;
        public GameObject coll;

        // Use this for initialization
        void Start () {
            startPos = transform.position;
            destPos = destination.transform.position;
            t = 0;
        }
	
        // Update is called once per frame
        void Update () {
            if(run)
            {
                transform.position = Vector3.Lerp(startPos, destPos, t);
                if (t > 1)
                {
                    run = false;
                    Destroy(transform.parent.gameObject, 1.5f);
                    this.enabled = false;
                }
                else if(t > 0.8 && can)
                {
                    Destroy(coll);
                    can = false;
                }
                t += Time.unscaledDeltaTime/6;
            }
        }

        public new void TurnOn(PlayerProperties p)
        {
            ps = Instantiate(indicator, transform.parent.transform.position + indicator.transform.position, indicator.transform.rotation) as ParticleSystem;
            run = true;
        }
    }
}
