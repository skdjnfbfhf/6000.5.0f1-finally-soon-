using UnityEngine;

namespace babu
{
    public class Bullet : MonoBehaviour
    {
        [UnityEngine.SerializeField]
        private Vector3 destination;
        [UnityEngine.SerializeField]
        public float speed = 1.0f;
//        private bool isThrow = false;

        public bool isPlayer = true;

        public Vector3 dir;
        public GameObject Item;

        private void Update()
        {
            this.transform.position += dir.normalized * Time.deltaTime * speed;
        }

        public void SetBullet(Vector3 _destination)
        {
            destination = _destination;
            dir = destination - this.transform.position;
        }

        void OnTriggerEnter(Collider other)
        {
            if (isPlayer)
            {
                if (other.CompareTag("Enemy"))
                {
                    GameManager gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
                    Player player = GameObject.Find("Player").GetComponent<Player>();
                    player.score += 10;
                    gameManager.score.text = "Score : " + player.score;
                    Instantiate(Item, this.transform.position, Item.transform.rotation);
                    Destroy(other.gameObject);
                    Destroy(this.gameObject);
                }
            }
            else
            {
                if (other.CompareTag("Player"))
                {
                    Player player = GameObject.Find("Player").GetComponent<Player>();
                    GameManager gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
                    player.Hp -= 1;
                    gameManager.HP.text = "HP : " + player.Hp.ToString();
                    if(player.Hp <= 0)
                    {
                        Destroy(other.gameObject);
                    }
                    Destroy(this.gameObject);
                }
            }
        }

    }
}
