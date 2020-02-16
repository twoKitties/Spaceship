using UnityEngine;

public class Cannon : MonoBehaviour
{
    private IWeapon current;
    [SerializeField] private PoolData missilePoolData;

    private void Awake()
    {
        current = new Missile(missilePoolData, transform);
    }

    public void Shoot(bool status)
    {
        if (status)
            current.Shoot();
    }
}
