using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace S3
{
    public class GameManger_TogglePause : MonoBehaviour
    {
      
        private bool IsPaused;
        

        private void OnEnable()
        {

            GameManger_Master.MenuToggleEvent += TogglePause;
            GameManger_Master.InventoryUIToggleEvent += TogglePause;
           
        }


        private void OnDisable()
        {
            GameManger_Master.MenuToggleEvent -= TogglePause;
            GameManger_Master.InventoryUIToggleEvent -= TogglePause;
        }

       

        void TogglePause()
        {
            
            if (IsPaused)
            {

                Time.timeScale = 1; //normal
                IsPaused = false;
            }

            else
            {
              
                Time.timeScale = 0; //paused
                IsPaused = true;
                
            }

        }

    }

}