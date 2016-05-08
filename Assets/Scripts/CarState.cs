using UnityEngine;
using System.Collections;

public class CarState : MonoBehaviour
{

    public Sprite[] sprites = { };
    private SpriteRenderer spr;

    // Use this for initialization
    void Start()
    {
        spr = GetComponent<SpriteRenderer>();
        spr.sprite = sprites[0];
    }

    // Update is called once per frame
    void Update()
    {

    }

    //f is 1 for P, 2 for R, 3 for D
    public void shift(int f)
    {
        if (f == 2)
            spr.color = new Color(180, 0, 0);
        else
            spr.color = new Color(0, 178, 0);
        spr.sprite = sprites[f - 1];
    }
}
