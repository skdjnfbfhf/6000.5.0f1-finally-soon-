using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace babu
{
    public class MainMenu : MonoBehaviour
    {
        public GameObject MenuBack;
        public GameObject Manual;
        public GameObject Story;
        public GameObject Setting;

        public GameObject BackMusic;
        public GameObject BackSound;

        public void BtnStart()
        {
            /*SceneManager.LoadScene("SampleScene");*/
        }
        public void BtnSetting()
        {
            MenuBack.GetComponent<Animator>().SetTrigger("Close");
            Invoke("OpenSetting", 1.5f);
        }
        public void BtnExit()
        {
            Application.Quit();
        }
        void OpenSetting()
        {
            Setting.SetActive(true);
            Setting.GetComponent<Animator>().SetTrigger("Open");
        }

        public void BtnBack()
        {
            Setting.GetComponent<Animator>().SetTrigger("Close");
            Invoke("OpenMenuBG", 1.5f);
        }

        public void OpenMenuBG()
        {
            MenuBack.GetComponent<Animator>().SetTrigger("Open");
        }
        public void BtnBGSound()
        {
            if (BackMusic.GetComponent<Text>().text == "πË∞Ê¿Ωæ«")
            {
                GameDataManager.instance.isMusic = 0;
            }
            else
            {
                GameDataManager.instance.isMusic = 1;
            }
            GameDataManager.instance.SaveData();
        }

        public void SetData()
        {
            if(GameDataManager.instance.isMusic == 0)
            {
                BackMusic.GetComponent<Text>().text = "πË∞Ê¿Ωæ«";
            }
            else if(GameDataManager.instance.isMusic == 0)
            {
                BackMusic.GetComponent<Text>().text = "πË∞Ê¿Ωæ« ≤˚";
            }
            if (GameDataManager.instance.isSound == 0)
            {
                BackSound.GetComponent<Text>().text = "πË∞Ê¿Ωæ«";
            }
            else if (GameDataManager.instance.isSound == 0)
            {
                BackSound.GetComponent<Text>().text = "πË∞Ê¿Ωæ« ≤˚";
            }
            
        }


        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
    }   
}
