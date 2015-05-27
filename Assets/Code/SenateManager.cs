using System.Linq;
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
#if UNITY_EDITOR
            if (Input.GetKeyDown(KeyCode.Return))
            {
                foreach (var senateMember in _senateMembers)
                    senateMember.GetComponent<SenateMemberBehaviour>().IncrementSupport();
            }
#endif
        }

        public bool CoupIsSuccessful()
        {
            var sumSupport = _senateMembers.Sum(senateMember => senateMember.GetComponent<SenateMemberBehaviour>().Support);

            return (sumSupport > _senateMembers.Count()/2f);
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
    }
}
