using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bouncy : MonoBehaviour
{
    public float force = 1000f;
    private Animator _anim;


    void Awake()
    {
        _anim = GetComponent<Animator>();
    }

    IEnumerator AnimateBouncy()//animating the Bounce pad animation
    {
        _anim.Play("Up");
        yield return new WaitForSecondsRealtime(.5f);//waits .5 seconds to go back down
        _anim.Play("Down");
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")// if the player hits the bounce pad then he's launched updwards, it calls the BouncePlayer function in PlayerMovement script
        {
            collision.gameObject.GetComponent<PlayerMovement>().BouncePlayer(force);
            StartCoroutine(AnimateBouncy());

        }
    }
}
