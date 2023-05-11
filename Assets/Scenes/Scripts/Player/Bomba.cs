using UnityEngine;

public class Bomba : MonoBehaviour
{
    public float explosionRadius = 5f;
    public int damage = 100;
    public float delay = 3f;

    private void Start()
    {
        Invoke("StartExplosion", delay);
    }

    private void StartExplosion()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);

        foreach (Collider collider in colliders)
        {
            Wall wall = collider.GetComponent<Wall>();

            if (wall != null)
            {
                wall.TakeDamage_wall(damage);
            }

            MOB mob = collider.GetComponent<MOB>();

            if (mob != null && Vector3.Distance(transform.position, mob.transform.position) <= explosionRadius)
            {
                mob.TakeDamage_mob(damage);
            }
            
        }

        Destroy(gameObject);
    }
}
