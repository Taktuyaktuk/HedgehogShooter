using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileComponent : MonoBehaviour
{
    ProjectileSystem _projectileSystem;
    bool m_isActive = false;

    Vector3 m_direction = Vector3.zero;
    float m_speed = 0;


    private void Start()
    {
        _projectileSystem = ProjectileSystem.GetInstance();
        _projectileSystem.RegisterProjectile(this);
        gameObject.SetActive(false);
    }

    private void Update()
    {
        if (m_isActive)
        {
            transform.Translate(m_direction * m_speed * Time.deltaTime);
        }
    }

    internal void FireProjectile(Vector3 _direction, float _speed)
    {
        m_isActive = true;
        m_direction = _direction;
        m_speed = _speed;
        StartCoroutine(DisableObjectDelayed(5));
    }

    private void OnCollisionEnter(Collision collision)
    {
        
        StopAllCoroutines(); 
        StartCoroutine(DisableObjectDelayed(0.1f));
    }


    private IEnumerator DisableObjectDelayed(float _delay)
    {
        yield return new WaitForSeconds(_delay);
        m_isActive = false;
        gameObject.SetActive(false);
    }

    private void OnDestroy()
    {
        if (_projectileSystem != null) { _projectileSystem.UnregisterProjectile(this); }
    }
}
