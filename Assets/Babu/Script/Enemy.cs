using UnityEngine;
using static Codice.Client.Commands.WkTree.WorkspaceTreeNode;

namespace babu
{
    public class Enemy : MonoBehaviour
    {
        public float speed;
        private GameObject Player;
        public GameObject objBullet;
        public Transform BulletPoint;
        public float delay = 0.5f;
        public float fireRate = 1.0f;

        public float hp = 1.0f;
        public float maxHp = 1.0f;
        Rigidbody thisRigi;


        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            

            Player = GameObject.FindGameObjectWithTag("Player");

            if(Player == null)
            {
                Debug.Log("Player Not Found");
            }

            this.GetComponent<Rigidbody>().linearVelocity
                = transform.forward * speed;

            InvokeRepeating("fireBullet", delay, fireRate);
        }

        void fireBullet()
        {
            if(Player != null)
            {
                GameObject bullet = Instantiate(objBullet, BulletPoint.transform.position, this.transform.rotation);
                Bullet bulletScript = bullet.GetComponent<Bullet>();
                bulletScript.isPlayer = false;
                bulletScript.SetBullet(Player.transform.position);
            }
        }
        // Update is called once per frame
        void Update()
        {
            
            //Move();
        }



        void Move()
        {
            if (Player != null)
            {
                transform.position +=
                Vector3.down * speed * Time.deltaTime;
            }
        }


    }
}
