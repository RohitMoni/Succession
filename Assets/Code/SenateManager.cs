using UnityEngine;

namespace Assets.Code
{
    public class SenateManager : MonoBehaviour {

        // public references set in unity
        public GameObject SenateMemberPrefab;

        // Internal references
        private Transform _senateMemberLocationsAnchor;

        // Member variables
        private GameObject[] _senateMembers;

        void Awake()
        {
            _senateMemberLocationsAnchor = GameObject.Find("SenateMemberLocationsAnchor").transform;
        }

        // Use this for initialization
        void Start ()
        {
            Initialise();
        }
	
        // Update is called once per frame
        void Update () {
	
        }

        public bool CoupIsSuccessful()
        {
            return true;
        }

        void Initialise()
        {
            CreateSenateMembers();
        }

        void CreateSenateMembers()
        {
            _senateMembers = new GameObject[_senateMemberLocationsAnchor.childCount];

            var i = 0;
            foreach (Transform location in _senateMemberLocationsAnchor)
            {
                var senateMember = Instantiate(SenateMemberPrefab);
                senateMember.transform.position = location.position;

                _senateMembers[i++] = senateMember;
            }
        }

        void SenateMemberPressed()
        {

        }
    }
}
