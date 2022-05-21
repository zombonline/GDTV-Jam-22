using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float speed = 5f;
    Rigidbody2D rigidbody;

    bool isIdle = true;
    [SerializeField] SpriteRenderer movingSprite, idleSprite;
    [SerializeField] ParticleSystem particles;
    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        var verticalThrow = Input.GetAxis("Vertical") * speed;
        var horizontalThrow = Input.GetAxis("Horizontal") * speed;

        rigidbody.velocity = new Vector2(horizontalThrow, verticalThrow);
        if (rigidbody.velocity != Vector2.zero)
        {
            if(isIdle)
            {
                particles.Play();
                isIdle = false;
            }
            idleSprite.enabled = false;
            movingSprite.enabled = true;
        }
        else
        {
            if (!isIdle)
            {
                particles.Play();
                isIdle = true;
            }
            idleSprite.enabled = true;
            movingSprite.enabled = false;
        }
    }
}
