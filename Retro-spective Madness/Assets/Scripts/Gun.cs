using UnityEngine;

public class Gun : MonoBehaviour
{
    [Range(0.5f, 1.5f)] public float fireRate = 1;
    public Timer timer;
    public AudioSource gunFireSource;
    private float fireTimer;
    private int i = 0;

    void Update()
    { 
        fireTimer += Time.deltaTime;
        if (fireTimer >= fireRate)
        {
            if (Input.GetButton("Fire1"))
            {
                fireTimer = 0f;
                FireGun();
            }
        }
        if (i == 3 && timer.timeRemaining > 0)
        {
            GameManager.levelState = GameManager.LevelState.solved;
        }
    }

    private void FireGun()
    {
      
        gunFireSource.Play();

        Ray ray = Camera.main.ViewportPointToRay(Vector3.one * 0.5f);

        Debug.DrawRay(ray.origin, ray.direction * 100, Color.red, 2f);


        RaycastHit hitInfo;

        if (Physics.Raycast(ray, out hitInfo, 100))
        {
            if (hitInfo.collider.gameObject.layer == 9)
            {
                i++;
                hitInfo.collider.gameObject.SetActive(false);
                Debug.Log(timer.timeRemaining);
            }
                
        }
     
    }

}
