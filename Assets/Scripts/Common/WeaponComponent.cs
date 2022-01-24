using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponComponent : MonoBehaviour
{
    ProjectileSystem _projectileSystem;
    [SerializeField]
    float _projectileSpeed;

    private void Start()
    {
        _projectileSystem = ProjectileSystem.GetInstance();
    }

    public void FireWeapon(Vector3 _target)
    {
        _projectileSystem.FireProjectile(transform.position, _target, _projectileSpeed);
    }
}
