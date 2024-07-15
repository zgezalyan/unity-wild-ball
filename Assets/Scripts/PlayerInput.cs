using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace WildBall.Inputs
{
    [RequireComponent(typeof(BallMovement))]
    public class PlayerInput : MonoBehaviour
    {

        private Vector3 movement;
        private BallMovement ballMovement;
        private bool isJumped;
        private bool isOnActivator;
        private GameObject activator;
        private bool isActivated;

        private void Awake()
        {
            ballMovement = GetComponent<BallMovement>();
        }

        private void Update()
        {
            float horizontal = Input.GetAxis(GlobalVars.HorizontalAxis);
            float vertical = Input.GetAxis(GlobalVars.VerticalAxis);
            
            movement = new Vector3(horizontal, 0, vertical).normalized;
            if (!isJumped)
                if (Input.GetButtonDown(GlobalVars.JumpButton))
                    isJumped = true;
            if (isOnActivator)
            {                
                if (Input.GetKeyDown(GlobalVars.ActionCode))
                    isActivated = true;                
            }
        }

        private void FixedUpdate()
        {
            ballMovement.MoveBall(movement);
            if (isJumped)
            {
                ballMovement.JumpBall();
                isJumped = false;
            }
            if (isActivated)
            {                
                activator.GetComponent<MechanismControl>().Activate();
                isActivated = false;
            }
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.name == GlobalVars.ActivatorName)
            {
                isOnActivator = true;
                activator = collision.gameObject;
            }   
        }

        private void OnCollisionExit(Collision collision)
        {
            if (collision.gameObject.name == GlobalVars.ActivatorName)
            {
                isOnActivator = false;                
            }
        }
    }
}
