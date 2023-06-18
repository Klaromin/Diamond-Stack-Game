using System;
using StackGame.Data;
using StackGame.Observer_Pattern;
using UnityEngine;

namespace StackGame.Collectable
{
    public class Gem : MonoBehaviour
    {
        #region Events

        public event EventHandler OnGemCollectedEvent;

        #endregion

        #region Serialize Fields

        [SerializeField] private Subject _playerSubject;
        [SerializeField] private GemData _gemData;
        [SerializeField] private MeshRenderer _meshRenderer;

        #endregion

        #region Private Fields

        [SerializeField] private int _price;
        private Vector3 _maximumSize;
        private Vector3 _initialSize;
        private float _currentScale;
    
        private Sprite _sprite;
        private MeshFilter _meshFilter;
        private float Timer;
        private bool _isPicked = false;

        #endregion

        private void Start()
        {
            _initialSize = transform.localScale;
        }

        private void Update()
        {
            _currentScale = transform.localScale.x;
            if (transform.localScale.x <= 0.99f && !_isPicked)
            {
                HandleScaling();
            }
        }

        private void OnEnable()
        {
            _maximumSize = new Vector3(0.4f, 0.4f, 0.4f);
        }

        public void Init()
        {
            InitPrice();
            InitModel();
            InitSprite();
            InitMaterial();
        }

        private void InitPrice()
        {
            _price = _gemData.GemInintialPrice;
        }

        private void InitSprite()
        {
            _sprite = _gemData.GemIcon;
        }

        private void InitModel()
        {
            _meshFilter = _gemData.GemModel;
        }

        private void InitMaterial()
        {
            _meshRenderer.material = _gemData.GemMaterial;
        }

        public void SetData(GemData gemData)
        {
            _gemData = gemData;
        }

        private void HandleScaling()
        {
            var scaleSpeed = Time.deltaTime * 0.25f;
            var temp = transform.localScale;
            temp.x += scaleSpeed;
            temp.y += scaleSpeed;
            temp.z += scaleSpeed;
            transform.localScale = temp;
        }

        private void HandlePricing()
        {
            _price += (int)((_currentScale)*_gemData.GemInintialPrice);
        }

        public float GetGemPrice()
        {
            return _price;
        }

        public GemType GetGemType()
        {
            return _gemData.GemType;
        }
    
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag == "Player")
            {
                if (transform.localScale.x < 0.25f) return;
                _isPicked = true;
                HandlePricing();
                OnGemCollectedEvent?.Invoke(this, EventArgs.Empty);
            }
        }
    }
}
