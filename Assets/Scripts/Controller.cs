using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace SpaceAdv
{
    public class Controller : MonoBehaviour
    {

        public float _speedMove;

        public Transform mainCamera;
        private Vector3 offset;

        public float hor;
        public float vert;
        
        public ParticleSystem _flame;
        public Transform _turbine;
       
        
        public Transform _laserTransform1;
        public Transform _laserTransform2;
        public GameObject _laser;
        public float laserSpeed;
        private GameObject laser1;
        private GameObject laser2;
       

        void Start()
        {
            _speedMove = 0f;
           _flame.startLifetime = 0f;

            offset = mainCamera.position - transform.position;
        }


        void Update()
        {

            SpaceShipController();

             


        }


        private void SpaceShipController()
        {
  
            if (Input.GetMouseButtonDown(1))
            {
                laser1 = Instantiate(_laser, _laserTransform1);
                laser2 = Instantiate(_laser, _laserTransform2);


            }
            if (laser1 && laser2)
            {
                
                laser1.transform.Translate(Vector3.up * Time.deltaTime * laserSpeed);
                laser2.transform.Translate(Vector3.up * Time.deltaTime * laserSpeed);
                Destroy(laser1, 3);
                Destroy(laser2, 3);
            }
            //if ( dist1 >= 100.0)
            //{
            //    Destroy()
            //}


            if (Input.GetMouseButton(0))
            {

                _speedMove += 0.1f;
                if (_speedMove >= 50.0f)
                {
                    _speedMove = 50.0f;
                }


                _flame.startLifetime += 0.011f;
                if (_flame.startLifetime >= 0.7f)
                {
                    _flame.startLifetime = 0.7f;
                }

            }
            else
            {
                _speedMove -= 0.05f;
                if (_speedMove <= 0.0f)
                {
                    _speedMove = 0.0f;
                }

                _flame.startLifetime -= 0.001f;
                if (_flame.startLifetime <= 0)
                {
                    _flame.startLifetime = 0;
                }
            }


            //_rigidbody.AddForce(Vector3.forward * _speedVert *_flame.startLifetime);
            transform.Translate(Vector3.forward * _speedMove * _flame.startLifetime * Time.deltaTime);

            hor = Input.GetAxis("Horizontal");
            Vector3 hormovement = new Vector3(0, hor * _flame.startLifetime * Time.deltaTime * _speedMove, 0);
            transform.Rotate(hormovement);

            vert = Input.GetAxis("Vertical");
            Vector3 vertmovement = new Vector3(vert * _flame.startLifetime * Time.deltaTime * _speedMove, 0, 0);
            transform.Rotate(vertmovement);


            //mainCamera.position = transform.position + offset;


            if (Input.GetKey(KeyCode.E))
            {
                

                transform.Rotate(0, 0, -90 * Time.deltaTime, Space.Self );
                
            }

            if (Input.GetKey(KeyCode.Q))
            {
                transform.Rotate(0, 0, 90 * Time.deltaTime);
            }

        }
    }
}
