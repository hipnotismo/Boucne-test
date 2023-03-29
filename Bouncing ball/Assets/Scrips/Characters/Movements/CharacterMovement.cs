using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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
    private object _JumpCoorutine;
    public float jumpBufferTime;

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
        
        currentMovement = new Vector3(movement.x,0,movement.y);
    }

    public void OnJump()
    {
        if (_JumpCoorutine !=null)
        {
            StopCoroutine(JumpCorutine());
        }
        _JumpCoorutine =  StartCoroutine(JumpCorutine());
        //_isJump = true;

    }

    private IEnumerator JumpCorutine()
    {
        if (!feetPivot)
        {
            yield break;
        }
        float timeElapsed = 0;

        while (timeElapsed <= jumpBufferTime)
        {
            yield return new WaitForFixedUpdate();
            if (Physics.Raycast(feetPivot.position, Vector3.down, out var hit, MaxDistance)
            && hit.distance <= minJumpDistance)
            {
                rb.velocity = new Vector3(rb.velocity.x, y:0 ,rb.velocity.z);
                rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);

                if (timeElapsed > 0)
                {
                    Debug.Log(timeElapsed);
                }
                //rb.velocity = currentMovement * speed + Vector3.up * rb.velocity.y;
                yield break;
            }
            //  rb.velocity = currentMovement * speed + Vector3.up * rb.velocity.y;
            timeElapsed += Time.fixedDeltaTime;
        }
    }

    public void OnSprint(InputValue input)
    {
    }

    public void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
    }
}
