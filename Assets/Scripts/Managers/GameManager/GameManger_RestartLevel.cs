using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace S3
{
    public class GameManger_RestartLevel : MonoBehaviour
    {
       
        private void OnEnable()
        {

            GameManger_Master.RestartToggleEvent += RestartLevel;
        }

        private void OnDisable()
        {
            GameManger_Master.RestartToggleEvent -= RestartLevel;

        }


        public  void RestartLevel()
        {
          
           // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            SceneManager.LoadScene(0);
        }

    }
}
