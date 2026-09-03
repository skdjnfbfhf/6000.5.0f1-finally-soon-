using UnityEngine;

namespace babu
{
    public class GameDataManager : MonoBehaviour
    {
        public static GameDataManager instance;
        public int isMusic = 0;
        public int isSound = 0;
        public float gameTime = 0f;
        public int gameScore;
        public string curld;

        private void Awake()
        {
            DontDestroyOnLoad(instance);
            instance = this;
        }

        void Start()
        {
            SaveData();
            LoadData();
        }
        public void SaveData()
        {
            if (PlayerPrefs.HasKey("id"))
            {
                string id = PlayerPrefs.GetString("id");
                Debug.Log(id);
                PlayerPrefs.DeleteKey("id");
            }
            else
            {
                PlayerPrefs.SetString("id", "Babu");
            }
            PlayerPrefs.SetInt("Music", isMusic);
            PlayerPrefs.SetInt("Sound", isSound);
        }

        public void LoadData()
        {
            if (!PlayerPrefs.HasKey("Music"))
            {
                PlayerPrefs.SetInt("Music", 1); 
            }
            if (!PlayerPrefs.HasKey("Sound"))
            {
                PlayerPrefs.SetInt("Sound", 1);
            }
            isMusic = PlayerPrefs.GetInt("Music");
            isSound = PlayerPrefs.GetInt("Sound");

            Debug.Log(isMusic);
            Debug.Log(isSound);
        }
    }
}
