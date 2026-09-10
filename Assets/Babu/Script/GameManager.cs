using Codice.Client.Common;
using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace babu
{
    public class GameManager : MonoBehaviour
    {
        public GameObject[] Enemy = new GameObject[5];
        public Vector3 spawnValue;
        public int enemyCount;
        public float spawnWait;
        public float startWait;

        public float waveWait;

        public List<GameObject> listEnemys = new List<GameObject>();

        public enum GameStatus
        {
            none = 0,
            play = 11,
            gameOver,
            gameClear
        }
        public GameStatus gameStatus = GameStatus.none;

        public Text score;
        public Text HP;
        public Text Upgrade;
        public Text Bomb;

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            gameStatus = GameStatus.play;
            StartCoroutine(SpawnEnemy());
            Player player = GameObject.Find("Player").GetComponent<Player>();
            player.Hp = GameDataManager.instance.maxHp;
            player.Upgrade = GameDataManager.instance.upgrade;
            player.Bomb = GameDataManager.instance.bomb;

            HP.text = "HP" + player.Hp;
            Upgrade.text = "Upgrade" + player.Upgrade;
            Bomb.text = "Bomb" + player.Bomb;
            score.text = "Score" + player.score;                        
        }

        // Update is called once per frame
        void Update()
        {
        
        }

        IEnumerator SpawnEnemy()
        {
            yield return new WaitForSeconds(startWait);
            while (true)
            {
                for(int i=0; i<enemyCount; i++)
                {
                    GameObject enemy =
                        Enemy[Random.Range(0, Enemy.Length)];
                    Vector3 spawnPosition =
                        new Vector3(Random.Range(
                            -spawnValue.x, spawnValue.x),
                            spawnValue.y, spawnValue.z);
                    Quaternion spawnRotation = Quaternion.identity;
                    listEnemys.Add(Instantiate(enemy, spawnPosition, enemy.transform.rotation));
                    yield return new WaitForSeconds(spawnWait);
                }
                yield return new WaitForSeconds(waveWait);
            }
        }
    }
}
