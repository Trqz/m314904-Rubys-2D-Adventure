using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RubyController : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;
    private float horizontal, vertical;

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
    }

    private void FixedUpdate()
    {
        Vector2 position = _rigidbody2D.position;
        position += new Vector2(horizontal, vertical) * 3f * Time.deltaTime;
        _rigidbody2D.MovePosition(position);
    }
}
