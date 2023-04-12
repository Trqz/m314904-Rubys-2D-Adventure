using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RubyController : MonoBehaviour
{
    //[SerializeField]
    public int maxHealth = 5;
    [SerializeField]
    private float timeInvincible = 2f;

    private bool isInvincible;
    private float invincibleTimer;

    public int health { get { return currentHealth; } }
    private int currentHealth;

    [SerializeField]
    private float speed = 3f;

    private Rigidbody2D _rigidbody2D;
    private float horizontal, vertical;

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();

        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        if (isInvincible)
        {
            invincibleTimer -= Time.deltaTime;
            if (invincibleTimer < 0)
                isInvincible = false;
        }
    }

    private void FixedUpdate()
    {
        Vector2 position = _rigidbody2D.position;
        position += new Vector2(horizontal, vertical) * speed * Time.deltaTime;
        _rigidbody2D.MovePosition(position);
    }

    public void ChangeHealth(int amount)
    {
        if (amount < 0)
        {
            if (isInvincible)
                return;

            isInvincible = true;
            invincibleTimer = timeInvincible;
        }

        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
        Debug.Log(currentHealth + "/" + maxHealth);
    }
}
