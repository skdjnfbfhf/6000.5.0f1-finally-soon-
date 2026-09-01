using UnityEngine;
using UnityEngine.SceneManagement;

namespace babu
{
    public class MainMenu : MonoBehaviour
    {
        public GameObject MenuBack;
        public GameObject Manual;
        public GameObject Story;
        public GameObject Setting;


        public void BtnStart()
        {
            SceneManager.LoadScene("SampleScene");
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

        public void BtnBGsound()
        {
            SettingSound().GetComponent<Text>().text = "¹è°æÀ½¾Ç ²û";
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
