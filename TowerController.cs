using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerController : MonoBehaviour
{
    private Rigidbody _rb;
    private MeshRenderer _mr;
    public static TowerEl TowerEl;
    private Collider _collider;
  
    [SerializeField] private float _moveSpeed = 5.5f;

    void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        _mr = GetComponent<MeshRenderer>();
        TowerEl = transform.parent.GetComponent<TowerEl>();
        _collider = GetComponent<Collider>();
    }  
    public void BreakingPl()
    {
        _rb.isKinematic = false;
        _collider.enabled = false;

        Vector3 forcePoint = transform.parent.position;
        float parentXPosition = transform.parent.position.x;
        float xPos = _mr.bounds.center.x;

        Vector3 subDirection = (parentXPosition - xPos < 0) ? Vector3.right : Vector3.left;
        Vector3 direction = (Vector3.down * _moveSpeed + subDirection).normalized;

        float force = Random.Range(20, 35);
        float torque = Random.Range(110, 180);

        _rb.AddForceAtPosition(direction * force, forcePoint, ForceMode.Impulse);
        _rb.AddTorque(Vector3.down * torque);
        _rb.velocity = Vector3.up;

    }

    public void RemoveAllChildPlatforms()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).SetParent(null);
            i--;
        }
    }


}
