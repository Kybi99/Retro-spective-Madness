using UnityEngine;

public class Gun : MonoBehaviour
{
    [Range(0.5f, 1.5f)] public float fireRate = 1;
    public AudioSource gunFireSource;
    private float fireTimer;
    [HideInInspector] public int i = 0;
    public Animator enemyAnim;

    void Update()
    {
        fireTimer += Time.deltaTime;
        if (fireTimer >= fireRate)
        {
            if (Input.GetButton("Fire1") && PauseMenu.gameIsPaused == false)
            {
                fireTimer = 0f;
                FireGun();
            }
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
            }
            else if (hitInfo.collider.gameObject.layer == 12)
            {
                enemyAnim.Play("Dead");
                DialogManager.canTalk = false;
                GameManager.levelState = GameManager.LevelState.failed;
            }
                
        }
     
    }

}
