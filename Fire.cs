using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Fire : MonoBehaviour
{
    public GameObject Bullet;
    public Transform SpawnPoint;
    public float BulletSpeed;
    private XRGrabInteractable m_Grabbable;
    // Start is called before the first frame update
    void Start()
    {
        m_Grabbable = GetComponent<XRGrabInteractable>();
        m_Grabbable.activated.AddListener(FireBullet);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FireBullet(ActivateEventArgs interactor)
    {
        GameObject bulletInstance = Instantiate(Bullet, SpawnPoint.position, Quaternion.identity);
        Rigidbody body = bulletInstance.GetComponent<Rigidbody>();
        body.velocity = SpawnPoint.forward * BulletSpeed;

        Destroy(bulletInstance, 3.0f);
    }
}
