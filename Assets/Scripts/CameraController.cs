using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float smoothSpeed = 5f;
    [SerializeField] private Vector3 offset;

    private float _targetY;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _targetY = transform.position.y;
    }

    void LateUpdate()
    {
        Vector3 desiredPosition = new Vector3(transform.position.x, _targetY, transform.position.z);
        
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
        
        transform.position = smoothedPosition;
    }

    public void UpdateTargetHeight(float newY)
    {
        _targetY = newY;
    } 

    // Update is called once per frame
    void Update()
    {
        
    }
}
