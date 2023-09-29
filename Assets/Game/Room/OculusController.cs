using UnityEngine;
using NaughtyAttributes;

namespace Room
{
    public class OculusController : MonoBehaviour
    {
        [SerializeField] private Player player;
        [SerializeField] private float requiredDistanceToPlayer;
        [SerializeField] private GameObject helpWindow;
        [SerializeField] private float setupTime = 1;
        [SerializeField] private KeyCode getKey = KeyCode.Space;
        [SerializeField] private float dropForce;

        private Rigidbody2D rb;
        private Collider2D coll;

        private void Awake()
        {
            rb = GetComponent<Rigidbody2D>();
            coll = GetComponent<Collider2D>();
        }
        private void Start()
        {
            Physics2D.IgnoreCollision(coll, player.GetComponent<Collider2D>());

            if (GameDirector.oculusOnThePlayer)
            {
                DropOculus();
            }
        }
        private void Update()
        {
            if (Mathf.Abs(this.transform.position.x - player.transform.position.x) <= requiredDistanceToPlayer)
            {
                helpWindow.SetActive(true);
                if (Input.GetKeyDown(getKey))
                {
                    GetOculus();
                }
            }
            else
            {
                helpWindow.SetActive(false);
            }
        }
        [Button]
        public void GetOculus()
        {
            rb.gravityScale = 0;
            player.GetOculus(this, setupTime);
        }
        [Button]
        public void DropOculus()
        {
            player.DropOculus(this, dropForce);
        }
    }
}
