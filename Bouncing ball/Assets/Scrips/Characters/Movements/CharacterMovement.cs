using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterMovement : MonoBehaviour
{
    private Vector3 currentMovement;
    private const int MaxDistance = 10;

    [Header("Setup")]

    [SerializeField] Rigidbody rb;

    [Header("Movement")]

    [SerializeField] private Transform feetPivot;
    [SerializeField] float speed;
    [SerializeField] float jumpForce;
    [SerializeField] private float minJumpDistance;

    private bool _isJump;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        transform.Translate(speed * Time.deltaTime * currentMovement);  
    }

    private void FixedUpdate()
    {

        if (_isJump
            && Physics.Raycast(feetPivot.position, Vector3.down, out var hit,MaxDistance)
            && hit.distance <= minJumpDistance)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            _isJump = false;
        }
      //  rb.velocity = currentMovement * speed + Vector3.up * rb.velocity.y;

    }

    public void OnMove(InputValue input)
    {
        var movement = input.Get<Vector2>();

        Debug.Log(movement);
        
        
        currentMovement = new Vector3(movement.x,0,movement.y);
    }

    public void OnJump()
    {
        _isJump = true;

    }

    public void OnSprint(InputValue input)
    {
        Debug.Log("Sprint");
    }

    public void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
    }
}
