#region Includes
using UnityEngine;
#endregion

namespace TS.GazeInteraction
{
    public class GazeInteractor : MonoBehaviour
    {
        #region Variables

        [Header("Configuration")]
        [SerializeField] private float _maxDetectionDistance;
        [SerializeField] private float _minDetectionDistance;
        [SerializeField] private float _timeToActivate = 1.0f;
        [SerializeField] private LayerMask _layerMask;

        private Ray _ray;
        private RaycastHit _hit;

        private GazeReticle _reticle;
        private GazeInteractable _interactable;
        private float aimDistance = 10.0f;

        private float _enterStartTime;
        private Vector3 screenCenter;

        public GameObject fireworks;

        #endregion

        private void Start()
        {
            var instance = ResourcesManager.GetPrefab(ResourcesManager.FILE_PREFAB_RETICLE);
            var reticle = instance.GetComponent<GazeReticle>();

#if UNITY_EDITOR || DEVELOPMENT_BUILD
            if(instance == null) { throw new System.Exception("Missing instance"); }
            if(reticle == null) { throw new System.Exception("Missing GazeReticle"); }
#endif

            _reticle = Instantiate(reticle);
            _reticle.SetInteractor(this);

            screenCenter = new Vector3(Camera.main.pixelWidth / 2, Camera.main.pixelHeight / 2);
        }
        private void Update()
        {
            _ray = Camera.main.ScreenPointToRay(screenCenter);
            _reticle.Enable(true);

            if (Physics.Raycast(_ray, out _hit, Mathf.Infinity))
            {

                var distance = Vector3.Distance(transform.position, _hit.transform.position);
                var name = _hit.transform.name;

                Debug.Log("Updated: " + distance + " Name: " + name);

                if (distance < _minDetectionDistance)
                {
                    _reticle.Enable(false);
                    Reset();
                    return;
                }

                _reticle.SetTarget(_hit);
                fireworks.transform.position = _hit.transform.position;
                
            } else
            {
                var pos = _ray.origin + _ray.direction * aimDistance;
                _reticle.SetPos(pos);
                fireworks.transform.position = pos;
            }
        }

        private void Reset()
        {
            _reticle.SetProgress(0);

            if (_interactable == null) { return; }
            _interactable.GazeExit(this);
            _interactable = null;
        }

#if UNITY_EDITOR
        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawRay(transform.position, transform.forward * _maxDetectionDistance);
        }
#endif
    }
}