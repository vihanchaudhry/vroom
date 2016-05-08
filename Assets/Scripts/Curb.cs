using UnityEngine;

namespace Assets.Scripts
{
    public class Curb : MonoBehaviour {

        void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                GameManager.Instance.GameOverMenu(GameManager.Errors.HitCurb);
            }
        }
    }
}
