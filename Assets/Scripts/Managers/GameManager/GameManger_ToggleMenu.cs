using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace S3
{
    public class GameManger_ToggleMenu : MonoBehaviour
    {


        public GameObject Menu;
        private void Start()
        {

        }

        private void Update()
        {
            CheckForMenuToggleRequest();
        }
        private void OnEnable()
        {

            GameManger_Master.GameOverEvent += ToggleMenu;
            GameManger_Master.GameOverBulletEvent += ToggleMenu;
           
        }

        private void OnDisable()
        {
            GameManger_Master.GameOverEvent -= ToggleMenu;
            GameManger_Master.GameOverBulletEvent -= ToggleMenu;
            

        }

        void CheckForMenuToggleRequest()
        {
            if (Input.GetKeyUp(KeyCode.Escape) && !GameManger_Master.isGameOver && !GameManger_Master.isInventory)
            {
                ToggleMenu();
            }
        }

        public void ToggleMenu()
        {
            if (Menu != null)
            {

                Menu.SetActive(!Menu.activeSelf);
              //  GameManger_Master.isMenuOn = !GameManger_Master.isMenuOn;
                GameManger_Master.CallEventMenuToggle();//fireing 
            }
            else
            {
                Debug.LogWarning("you haven't to assign ui in toggle menu script");
            }
        }
    }
}
