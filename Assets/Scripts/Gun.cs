using UnityEngine;

public class Gun : MonoBehaviour
{
    
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private float shotDelay = 0.5f;
    private float nextShot;
    [SerializeField] private int maxAmmo = 36;
    public int currentAmmo;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentAmmo = maxAmmo;
    }

    // Update is called once per frame
    void Update()
    {
        RotateMouse();
        Shoot();
        Reload();
    }

    void RotateMouse()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 direction = mousePos - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0,0,angle);

        if (angle > 90 || angle < -90)
        {
            transform.localScale = new Vector3(1, -1, 1);
        }
        else
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
    }

    void Shoot()
    {
        if(Input.GetMouseButtonDown(0) && Time.time > nextShot && currentAmmo > 0)
        {
            nextShot = Time.time + shotDelay;
            Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            currentAmmo--;
        }
    }

    void Reload()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            currentAmmo = maxAmmo;
        }
    }
}
