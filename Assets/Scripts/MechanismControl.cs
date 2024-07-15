using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WildBall.Inputs
{
    public class MechanismControl : MonoBehaviour
    {

        public GameObject mechanismItself;
        private bool isOnActivator;
        public bool isActivated;
        private bool activate;

        private void Awake()
        {
            activate = false;
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.name == GlobalVars.BallName)
                isOnActivator = true;            
        }

        private void OnCollisionExit(Collision collision)
        {
            if (collision.gameObject.name == GlobalVars.BallName)
                isOnActivator = false;
        }

        private void Update()
        {
            if (activate && isOnActivator && !isActivated)
            {
                mechanismItself.GetComponent<MechanismItself>().Activate();
                isActivated = true;
            }
        }

        public void Activate()
        {
            activate = true;
        }
    }
}