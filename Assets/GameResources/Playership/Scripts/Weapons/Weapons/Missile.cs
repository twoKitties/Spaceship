using UnityEngine;


public class Missile : IWeapon
{
    private PoolData _requestedPoolData;
    private Transform _shipPosition;

    public Missile(PoolData poolData, Transform shipPosition)
    {
        _requestedPoolData = poolData;
        _shipPosition = shipPosition;
    }

    public void Shoot()
    {
        var missile = PoolManager.Instance.GetObject(_requestedPoolData);
        missile.transform.position = _shipPosition.position;
        missile.SetActive(true);
    }
}
