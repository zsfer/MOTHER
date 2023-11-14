using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 5;
    private Rigidbody2D _rb;
    private Animator _anim;
    private Vector2 _inputVec;

    private AudioSource _audioSource;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();

        _audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (!GameManager.Instance.CanPlayerMove) return;

        _inputVec = (transform.right * Input.GetAxisRaw("Horizontal") + transform.up * Input.GetAxisRaw("Vertical")).normalized;

        _anim.SetFloat("x", _inputVec.x);
        _anim.SetFloat("y", _inputVec.y);

        // jank footsteps
        _audioSource.enabled = _inputVec.magnitude > 0;
    }

    private void FixedUpdate()
    {
        _rb.velocity = _inputVec * _moveSpeed;
    }
}
