using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileSystem : Singleton<ProjectileSystem>
{
    List<ProjectileComponent> m_projectileList = new List<ProjectileComponent>();

    public void RegisterProjectile(ProjectileComponent _projectile) { m_projectileList.Add(_projectile); }
    public void UnregisterProjectile(ProjectileComponent _projectile) { m_projectileList.Remove(_projectile); }

    public void FireProjectile(Vector3 _startPosition, Vector3 _target, float _speed)
    {
        //Find disabled object and fire it towards target
        ProjectileComponent availableProjectile = m_projectileList.Find(x => !x.gameObject.activeInHierarchy);
        if (availableProjectile != null)
        {
            availableProjectile.gameObject.SetActive(true);
            availableProjectile.transform.position = _startPosition;
            Vector3 direction = (_target - _startPosition).normalized;

            availableProjectile.FireProjectile(direction, _speed);
        }
        else { Debug.LogWarning("Projectile not fired because no active projectile was found in the scene"); }
    }
    
}
