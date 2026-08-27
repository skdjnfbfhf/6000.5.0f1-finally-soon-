using UnityEngine;

namespace babu
{
    public class Bullet : MonoBehaviour
    {
        [UnityEngine.SerializeField]
        private Vector3 destination;
        [UnityEngine.SerializeField]
        public float speed = 1.0f;
        private bool isThrow = false;

        public bool isPlayer = true;

        public Vector3 dir;

        private void Update()
        {
            this.transform.position += dir.normalized * Time.deltaTime * speed;
        }

        public void SetBullet(Vector3 _destination)
        {
            destination = _destination;
            dir = destination = this.transform.position;
        }

        void OnTriggerEnter(Collider other)
        {
            if (isPlayer)
            {
                if (other.CompareTag("Enemy"))
                {
                    Destroy(other.gameObject);
                    Destroy(this.gameObject);
                    return;
                }
            }
            else
            {
                if (other.CompareTag("Player"))
                {
                    Destroy(other.gameObject);
                    Destroy(this.gameObject);
                }
            }
        }

    }
}
