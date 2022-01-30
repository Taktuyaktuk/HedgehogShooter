using UnityEngine;

public class WeaponComponent : MonoBehaviour
{
    ProjectileSystem m_projectileSystem;
    [SerializeField]
    float m_projectileSpeed = 9;

    private void Start()
    {
        m_projectileSystem = ProjectileSystem.GetInstance();
    }

    public void FireWeapon(Vector3 startPos, Vector3 _target)
    {
        m_projectileSystem.FireProjectile(startPos, _target, m_projectileSpeed);
    }

}
