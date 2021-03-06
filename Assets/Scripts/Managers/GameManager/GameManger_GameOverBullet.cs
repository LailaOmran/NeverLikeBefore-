﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace S3
{
    public class GameManger_GameOverBullet : MonoBehaviour
    {
        public GameObject Resume;
        

        public  GameObject panelGameOverBullet;

        private void OnEnable()
        {
            
            GameManger_Master.GameOverBulletEvent += TurnOnGameOverBullet;
           


        }

        private void OnDisable()
        {

            GameManger_Master.GameOverBulletEvent -= TurnOnGameOverBullet;
          



        }



        public  void TurnOnGameOverBullet()
        {

            if (panelGameOverBullet != null)
            {

                //panelGameOver.SetActive(true);
                panelGameOverBullet.SetActive(!panelGameOverBullet.activeSelf);
                GameManger_Master.isMenuOn = !GameManger_Master.isMenuOn;
                Resume.SetActive(false);
                
            }
        }

      


    }
}
