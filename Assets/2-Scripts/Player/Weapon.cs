using UnityEngine;


namespace Karoushi
{
    /// <summary>
    /// Basic class of a weapon
    /// </summary>
    public class Weapon : MonoBehaviour
    {
        [SerializeField]
        protected Player player;

        public void EnableCollider(bool value)
        {
            GetComponent<Collider>().enabled = value;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag == "DestructibleComponent")
            {
                DestructibleComponent destructibleComponent = other.gameObject.GetComponentInParent<DestructibleComponent>();
                Debug.Log("Trigger on " + destructibleComponent);
                player.Attack(destructibleComponent);
            }
        }

    }
}
