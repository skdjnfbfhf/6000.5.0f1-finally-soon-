using Codice.CM.Common;
using NUnit.Framework.Constraints;
using System;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Random;

namespace babu
{
    public class Boss : MonoBehaviour
    {
        public GameManager gameManager;
        Player player;

        public GameObject objBullet;
        public GameObject bullet;
        public Transform BulletPoint;
        Boss boss;

        public float bossMissileTime;
        public float bossTempTime;

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            GameObject gameManagerObject = GameObject.FindGameObjectWithTag("GameManager");
            if(gameManagerObject != null)
            {
                gameManager = gameManagerObject.GetComponent<GameManager>();
            }
            if(gameManager == null)
            {
                Debug.Log("게임 매니저가 존재하지 않습니다.");
            }
            player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
            if(player == null)
            {
                Debug.LogError("게임 메니져가  존재하지 않습니다.");
            }


            Vector3 spawnPosition = new Vector3(Random.Range(-gameManager.spawnValue.x, gameManager.spawnValue.x), 0, gameManager.spawnValue.z);
            Instantiate(boss, spawnPosition, boss.transform.position);


        }

        // Update is called once per frame
        void Update()
        {
                if (bossTempTime > bossMissileTime)
                {
                    bossTempTime = 0;
                    BossFireBullet(Random.Range(0,2));
            }
                bossTempTime += Time.deltaTime;
        }

        void BossFireBullet(int num)
        {
            switch (num)
            {
                case 0:
                    {
                        GameObject bullet = Instantiate(objBullet, BulletPoint.transform.position, this.transform.rotation);
                        bullet.GetComponent<Bullet>().SetBullet(player.transform.position);
                    }
                    break;
                case 1:
                    {
                        for(int i = 0; i < 3; i++)
                        {
                            GameObject bullet = Instantiate(objBullet, BulletPoint.position, this.transform.rotation);
                            bullet.GetComponent<Bullet>().SetBullet(player.transform.position + new Vector3.forward + new Vector3(-1 + i, 0, 0);
                        }
                    }
            }
        }

    }
}
