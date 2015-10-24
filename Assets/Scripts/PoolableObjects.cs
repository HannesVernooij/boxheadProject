using UnityEngine;
using System.Collections;

public abstract class PoolableObjects : MonoBehaviour 
{
    public abstract bool IsActive();
    public abstract void SetActive(Vector3 pos, Quaternion rot);
    public abstract void Deactivate();
    public abstract void SetDamage(int damage);

}
