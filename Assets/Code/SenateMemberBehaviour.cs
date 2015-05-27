using UnityEngine;
using UnityEngine.UI;

namespace Assets.Code
{
    public class SenateMemberBehaviour : MonoBehaviour {

        // External references
        private Transform _senateMembersAnchor;

        // Internal references
        private Button _button;

        void Awake()
        {
            _senateMembersAnchor = GameObject.Find("SenateMembersAnchor").transform;
            _button = GetComponent<Button>();
        }

        // Use this for initialization
        void Start () {
            Initialise();
        }

        // Update is called once per frame
        void Update () {
	
        }

        public void Initialise()
        {
            transform.SetParent(_senateMembersAnchor);
            transform.localScale = Vector3.one;
            _button.interactable = false;
        }
    }
}
