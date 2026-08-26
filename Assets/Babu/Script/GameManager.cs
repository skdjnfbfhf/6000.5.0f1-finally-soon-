using NUnit.Framework;
using System.Collections;
using UnityEngine;

namespace babu
{
    public class GameManager : MonoBehaviour
    {
        public GameObject[] Ememy = new GameObject[5];
        public Vector3 spawnValue;
        public int enemyCount;

        public float spawnWait;
        public float startWait;

        public List<GameObject> listEnemys = new List<GameObject>();

        public enum GameStatus
        {
            none,
            play,
            gameOver,
            gameClear
        }

        public GameStatus gameStatus = GameStatus.none;


        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            gameStatus = GameStatus.play;
            StartCoroutine(SpawnEnemy());
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
                        listEnemys[Random.Range(0, listEnemys.Length)];
                    Vector3 spawnPosition =
                        new Vector3(Random.Range(
                            -spawnValue.x, spawnValue.x),
                            spawnValue.y, spawnValue.z);
                    Quaternion spawnRotation = Quaternion.identity;
                    listEnemys.Add(Instantiate(enemy, spawnPosition, spawnRotation));
                    yield return new WaitForSeconds(spawnWait);
                }
            }
        }
    }
}
