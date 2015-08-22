﻿using UnityEngine;
using UnitySampleAssets.CrossPlatformInput;

public class PlayerMovement : MonoBehaviour {
    public float playerMovementSpeed = 6f;
    public bool isAI;
    private Vector3 normalizedMovementDirection;
    private Animator animator;
    private Rigidbody playerRigidbody;
#if !MOBILE_INPUT
    int floorMask;
    float cameraRayCastLength = 100f;
#endif

    void Awake( ) {
#if !MOBILE_INPUT
        floorMask = LayerMask.GetMask( "Floor" );
#endif
        animator = GetComponent<Animator>( );
        playerRigidbody = GetComponent<Rigidbody>( );
    }

    void FixedUpdate( ) {
        float horizontalAxisMovement = CrossPlatformInputManager.GetAxisRaw( "Horizontal" );
        float verticalAxisMovement = CrossPlatformInputManager.GetAxisRaw( "Vertical" );

        if ( !isAI ) {
            Vector3 movementDirection = GetNormalizedMovementDirection( horizontalAxisMovement, verticalAxisMovement );
            MovePlayerAlongAxis( movementDirection );

            if ( PlayerIsMoving( horizontalAxisMovement, verticalAxisMovement ) ) {
                animator.SetFloat( "Speed", 1.0f );
                RotatePlayer( movementDirection );
            } else {
                animator.SetFloat( "Speed", 0.0f );
            }
            //TurnPlayerTowardsMouseCursor( );
        }
    }

    private bool PlayerIsMoving( float horizontal, float vertical ) {
        bool walking = horizontal != 0.0f || vertical != 0.0f;
        return walking;
    }

    public void AIMovePlayer( Vector3 movementDirection ) {
        Vector3 playerMovementDirection = movementDirection * playerMovementSpeed * Time.deltaTime;
        playerRigidbody.MovePosition( transform.position + playerMovementDirection );
    }

    private Vector3 GetNormalizedMovementDirection( float horizontal, float vertical ) {
        normalizedMovementDirection.Set( horizontal, 0f, vertical );
        normalizedMovementDirection = normalizedMovementDirection.normalized * playerMovementSpeed * Time.deltaTime;
        return normalizedMovementDirection;
    }

    private void RotatePlayer( Vector3 rotationDirection ) {
        Quaternion rotateTowards = Quaternion.LookRotation( normalizedMovementDirection );
        transform.rotation = Quaternion.RotateTowards( transform.rotation,
            rotateTowards,
            1000 * Time.deltaTime );
    }

    private void MovePlayerAlongAxis( Vector3 movementDirection ) {
        playerRigidbody.MovePosition( transform.position + movementDirection );
    }

    //    void TurnPlayerTowardsMouseCursor( ) {
    //#if !MOBILE_INPUT
    //        Ray cameraRayCast = Camera.main.ScreenPointToRay( Input.mousePosition );
    //        RaycastHit floorHit;

    //        if ( Physics.Raycast( cameraRayCast, out floorHit, cameraRayCastLength, floorMask ) ) {
    //            Vector3 playerToMouse = floorHit.point - transform.position;
    //            playerToMouse.y = 0f;
    //            Quaternion newRotatation = Quaternion.LookRotation( playerToMouse );
    //            playerRigidbody.MoveRotation( newRotatation );
    //        }
    //#else
    //            Vector3 turnDir = new Vector3(CrossPlatformInputManager.GetAxisRaw("Mouse X") , 0f , CrossPlatformInputManager.GetAxisRaw("Mouse Y"));
    //            if (turnDir != Vector3.zero)
    //            {
    //                // Create a vector from the player to the point on the floor the raycast from the mouse hit.
    //                Vector3 playerToMouse = (transform.position + turnDir) - transform.position;

    //                // Ensure the vector is entirely along the floor plane.
    //                playerToMouse.y = 0f;

    //                // Create a quaternion (rotation) based on looking down the vector from the player to the mouse.
    //                Quaternion newRotatation = Quaternion.LookRotation(playerToMouse);

    //                // Set the player's rotation to this new rotation.
    //                playerRigidbody.MoveRotation(newRotatation);
    //            }
    //#endif
    //    }

}