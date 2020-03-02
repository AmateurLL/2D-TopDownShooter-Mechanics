using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile_Bullet : MonoBehaviour
{
    Rigidbody2D m_RigBody;

    public float fSpeed = 0.0f;
    public int iDamage = 1;

    private float fLifeTime = 4.0f;

    // Start is called before the first frame update
    void Start()
    {
        m_RigBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        BulletMovement();
        EndLife();
    }

    public void SetBulletStats(float _Speed, int _Damage)
    {
        fSpeed = _Speed;
        iDamage = _Damage;
    }

    private void BulletMovement()
    {
        transform.Translate(Vector3.up * fSpeed);
    }

    private void EndLife()
    {
        fLifeTime -= Time.deltaTime;
        if (fLifeTime < 0.0)
        {
            Destroy(this.gameObject);
        }
    }
}
