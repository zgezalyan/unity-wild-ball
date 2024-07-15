using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace WildBall.Inputs
{
    
    [RequireComponent(typeof(Rigidbody))]
    public class BallMovement : MonoBehaviour
    {

        [SerializeField, Range(1, 10)] private float speed;
        [SerializeField, Range(1, 10)] private float jumpForce;
        private Rigidbody ballRigidbody;
        private bool isOnGround;
        private AudioSource jumpSound;

        private void Awake()
        {
            ballRigidbody = GetComponent<Rigidbody>();
            isOnGround = false;
            jumpSound = GetComponent<AudioSource>();
        }        

        private void OnCollisionStay(Collision collision)
        {
            if (collision.collider.material.name == GlobalVars.FloorPhisicsMaterial)
                isOnGround = true;
        }

        private void OnCollisionExit(Collision collision)
        {
            isOnGround = false;
        }

        public void MoveBall(Vector3 movement)
        {
            ballRigidbody.AddForce(movement * speed);
        }

        public void JumpBall()
        {
            if (isOnGround)
            {
                Vector3 jumpVector = new Vector3(0, jumpForce, 0);
                jumpSound.Play();
                ballRigidbody.AddForce(jumpVector, ForceMode.Impulse);
            }
        }
       

#if UNITY_EDITOR
        [ContextMenu("Reset Values")]
        public void ResetValues()
        {
            speed = 2.0f;
            jumpForce = 2.0f;
        }

#endif

    }
}
