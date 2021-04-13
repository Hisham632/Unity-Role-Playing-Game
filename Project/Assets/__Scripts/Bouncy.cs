using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bouncy : MonoBehaviour
{
    public float force = 500f;
    private Animator _anim;


    void Awake()
    {
        _anim = GetComponent<Animator>();
    }

    IEnumerator AnimateBouncy()
    {
        _anim.Play("Up");
        yield return new WaitForSecondsRealtime(.5f);
        _anim.Play("Down");
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        // if collision tag is Player //
        if (collision.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerMovement>().BouncePlayer(force);
            StartCoroutine(AnimateBouncy());

        }
    }
}
