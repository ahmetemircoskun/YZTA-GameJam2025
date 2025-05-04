using UnityEngine;

public class Turret : MonoBehaviour
{
    [SerializeField] float range = 10f;
    [SerializeField] GameObject[] bulletPrefabs;
    [SerializeField] Transform firePoint;
    [SerializeField] float fireRate = 0.8f;
    [SerializeField] AudioClip fireSound;

    Transform target;
    float fireCountdown = 0f;
    int currentBulletIndex = 0;

    AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    void Update()
    {
        GameObject player = GameObject.FindWithTag("Player");
        if (player != null)
            target = player.transform;
        else
            return;

        float distanceToTarget = Vector3.Distance(transform.position, target.position);
        if (distanceToTarget > range) return;

        fireCountdown -= Time.deltaTime;

        if (fireCountdown <= 0f)
        {
            Shoot();
            fireCountdown = fireRate;
        }
    }

    void Shoot()
    {
        if (bulletPrefabs.Length == 0 || firePoint == null)
        {
            Debug.LogError("Mermi prefabları veya fire point eksik!");
            return;
        }

        GameObject selectedBullet = bulletPrefabs[currentBulletIndex];
        Instantiate(selectedBullet, firePoint.position, firePoint.rotation);

        if (fireSound != null && audioSource != null)
        {
            audioSource.PlayOneShot(fireSound);
        }

        currentBulletIndex = (currentBulletIndex + 1) % bulletPrefabs.Length;
    }
}
