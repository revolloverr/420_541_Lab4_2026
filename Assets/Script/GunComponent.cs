using UnityEngine;

public class GunComponent : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform bulletSpawnPoint;
    public float bulletMaxImpulse = 100.0f;
    public float maxChargeTime = 3.0f;
    private float chargeTime = 0.0f;
    private bool isCharging = false;

    void Update()
    {
        // TODO add the logic to track player keeping the input down.
        if (Input.GetButtonDown("Fire1"))
        {
            //start charging
            chargeTime = 0.0f;
            isCharging = true;
        } if(Input.GetButton("Fire1")){
            //increase charge time while button is pressed
            chargeTime += Time.deltaTime;
            chargeTime = Mathf.Clamp(chargeTime, 0, maxChargeTime);
        } if(Input.GetButtonUp("Fire1")){
            //spawn bullet when fire is released
            ShootBullet();
            isCharging = false;
        }
    }

   
    void ShootBullet()
{
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
       
        // Scale bullet force based on charge time
        float bulletImpulse = (chargeTime / maxChargeTime) * bulletMaxImpulse;
        rb.AddForce(bulletSpawnPoint.forward * bulletImpulse, ForceMode.Impulse);
    }

}
