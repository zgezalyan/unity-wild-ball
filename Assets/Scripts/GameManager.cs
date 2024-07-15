using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


namespace WildBall.Inputs
{
    [RequireComponent(typeof(BallMovement))]
    public class GameManager : MonoBehaviour
    {

        public Canvas interfaceCanvas;
        public GameObject firework;
        private BallMovement ballMovement;
        private PauseControl interfaceControl;
        private float timeElapsed;
        private bool gameOn;
        private bool isWin;
        private ParticleSystem deathParticles;        

        void Start()
        {
            ballMovement = GetComponent<BallMovement>();
            interfaceControl = interfaceCanvas.GetComponent<PauseControl>();
            timeElapsed = 0.0f;
            gameOn = true;
            isWin = false;
            interfaceControl.ShowWelcomeInfo(GetLevelName(SceneManager.GetActiveScene().buildIndex), GetLevelInfo(SceneManager.GetActiveScene().buildIndex));
            deathParticles = GetComponentInChildren<ParticleSystem>();

            StartCoroutine(WelcomePlayer());
        }

        void Update()
        {
            if (isWin && gameOn)
            {
                gameOn = false;
                bool isLastLevel = SceneManager.GetActiveScene().buildIndex == SceneManager.sceneCountInBuildSettings - 1;                
                interfaceControl.ActivateWin(GetLevelName(SceneManager.GetActiveScene().buildIndex), timeElapsed, isLastLevel);
                if (firework != null)
                {
                    ParticleSystem[] fires = firework.GetComponentsInChildren<ParticleSystem>();
                    foreach (ParticleSystem fire in fires)
                        fire.Play();
                }
            }
            else
                timeElapsed = timeElapsed + Time.deltaTime;
        }

        private string GetLevelName(int sceneNum)
        {
            switch (sceneNum)
            {
                case 1: return GlobalVars.Level1Name;
                case 2: return GlobalVars.Level2Name;
                case 3: return GlobalVars.Level3Name;
                case 4: return GlobalVars.Level4Name;
                case 5: return GlobalVars.Level5Name;
                case 6: return GlobalVars.Level6Name;
            }
            return "";
        }

        private string GetLevelInfo(int sceneNum)
        {
            switch (sceneNum)
            {
                case 1: return GlobalVars.Level1Cap;
                case 2: return GlobalVars.Level2Cap;
                case 3: return GlobalVars.Level3Cap;
                case 4: return GlobalVars.Level4Cap;
                case 5: return GlobalVars.Level5Cap;
                case 6: return GlobalVars.Level6Cap;
            }
            return "";
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.name == GlobalVars.DeathFallName && gameOn)
            {
                gameOn = false;
                interfaceControl.ActivateLost(GetLevelName(SceneManager.GetActiveScene().buildIndex));
                gameObject.transform.DetachChildren();                
                deathParticles.Play();
                gameObject.SetActive(false);
            }

            if (other.gameObject.GetComponent<ParticleSystem>() != null)
            {
                other.gameObject.GetComponent<ParticleSystem>().Play();
                GameObject toHide = other.gameObject.transform.parent.gameObject;
                other.gameObject.transform.parent = null;
                toHide.SetActive(false);
                other.enabled = false;
            }

        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.name == GlobalVars.FinishName)
                isWin = true;
            if (collision.collider.material.name == GlobalVars.SpikePhisicsMaterial)
            {
                gameOn = false;
                interfaceControl.ActivateLost(GetLevelName(SceneManager.GetActiveScene().buildIndex));
                gameObject.transform.DetachChildren();
                deathParticles.Play();
                gameObject.SetActive(false);
            }
            if (collision.gameObject.name == GlobalVars.ActivatorName)
                if (collision.gameObject.GetComponent<MechanismControl>().isActivated)
                    interfaceControl.ShowHint("ACTIVATED");
                else
                    interfaceControl.ShowHint("PRESS E TO ACTIVATE");
        }

        public void OnCollisionStay(Collision collision)
        {
            if (collision.gameObject.name == GlobalVars.ActivatorName)
                if (collision.gameObject.GetComponent<MechanismControl>().isActivated)
                    interfaceControl.ShowHint("ACTIVATED");
        }

        private void OnCollisionExit(Collision collision)
        {
            if (collision.gameObject.name == GlobalVars.ActivatorName)
                interfaceControl.HideHint();
        }

        public bool GetGameOn()
        {
            return gameOn;
        }

        private IEnumerator WelcomePlayer()
        {
            while (timeElapsed < 3.0f)
                 yield return 0;                            
            
            if (gameOn)
            {
                yield return 0;                
                interfaceControl.HideWelcomeInfo();
            }

        }
    }
}
