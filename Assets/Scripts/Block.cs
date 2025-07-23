using System;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 2f;
    [SerializeField] private float moveDistance = 3f;

    private int _direction = 1;
    private float _startX;
    
    private bool _isMoving = true;

    public Block previousBlock;
    
    public void OnEnable()
    {
        InputManager.OnTap += StopMovement;
    }

    public void OnDisable()
    {
        InputManager.OnTap -= StopMovement;
    }
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _startX = transform.position.x;
        InputManager.OnTap += StopMovement;
    }

    // Update is called once per frame
    void Update()
    {
        if (_isMoving)
        {
            transform.position += Vector3.right * _direction * moveSpeed * Time.deltaTime;

            if (transform.position.x > _startX + moveDistance)
            {
                _direction = -1;
            }
            else if (transform.position.x < _startX - moveDistance)
            {
                _direction = 1;
            }
        }   
    }

    private void StopMovement()
    {
        if (!_isMoving)
        {
            return;
        }
        
        _isMoving = false;
        
        InputManager.OnTap -= StopMovement;

        if (previousBlock == null)
        {
            CallGameManagerForNextBlock();
            return;
        }
        
        float overhang = transform.position.x - previousBlock.transform.position.x;
        
        float absoluteOverhang = Math.Abs(overhang);
        
        float newSize = previousBlock.transform.localScale.x - absoluteOverhang;

        if (newSize <= 0)
        {
            gameObject.AddComponent<Rigidbody>();
            GameManager.Instance.GameOver();
            enabled = false;

            return;
        }

        CreateCutOffPiece(overhang, newSize);
        
        transform.localScale = new Vector3(newSize, transform.localScale.y, transform.localScale.z);
        
        float newPositionX = previousBlock.transform.position.x + (overhang / 2);
        transform.position = new Vector3(newPositionX, transform.position.y, transform.position.z);

        CallGameManagerForNextBlock();  
    }

    private void CallGameManagerForNextBlock()
    {
        GameManager.Instance.ProcessSuccessfulStack(this);
    }

    private void CreateCutOffPiece(float overhang, float newMainBlockSize)
    {
        float cutOffSize = previousBlock.transform.localScale.x - newMainBlockSize;
        
        GameObject cutOff = GameObject.CreatePrimitive(PrimitiveType.Cube);
        
        cutOff.transform.localScale = new Vector3(cutOffSize, transform.localScale.y, transform.localScale.z);
        
        float cutOffPositionX = transform.position.x + (newMainBlockSize / 2 * Math.Sign(overhang));
        cutOff.transform.position = new Vector3(cutOffPositionX, transform.position.y, transform.position.z);
        
        cutOff.GetComponent<MeshRenderer>().material = GetComponent<MeshRenderer>().material;
        
        cutOff.AddComponent<Rigidbody>();
        
        Destroy(cutOff, 2f);
    }
}
