using UnityEngine;

namespace babu
{
    public class Bullet : MonoBehaviour
    {
        [UnityEngine.SerializeField]
        private Vector3 destination;
        public float speed = 1.0f;
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

    }
}
