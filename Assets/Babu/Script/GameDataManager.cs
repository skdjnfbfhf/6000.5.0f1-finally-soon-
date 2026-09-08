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

        public float maxHp = 5f;
        public int upgrade = 0;
        public int maxUpgrade = 3;
        public int bomb = 0;
        public int maxBomb = 3;


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
            
           
            PlayerPrefs.SetString("id", curld);
            PlayerPrefs.SetInt("score", gameScore);

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

            if(!PlayerPrefs.HasKey("id"))
            {
                PlayerPrefs.SetString("id", curld);
            }
            if(!PlayerPrefs.HasKey("score"))
            {
                PlayerPrefs.SetInt("score", 0);
            }
            gameScore = PlayerPrefs.GetInt("score");
            Debug.Log(isMusic);
            Debug.Log(isSound);
        }
        
        public void LoadData2()
        {
            if (!PlayerPrefs.HasKey("saveData"))
            {
                string saveData = curld + "." + gameScore;
                PlayerPrefs.SetString("savveData", saveData);
            }
            string tempData = PlayerPrefs.GetString("saveData");
            string[] data = tempData.Split('.');

            curld = data[0];
            gameScore = int.Parse(data[1]);
        }
    }
}
