using UnityEngine;
using UnityEngine.UI;
using UnityAtoms.BaseAtoms;

namespace MutCommon.UnityAtoms.UI
{
    [RequireComponent(typeof(TMPro.TMP_Text))]
    public class TextIntVariableBinding : MonoBehaviour
    {
        [SerializeField] private IntReference intVariable;
        [SerializeField] private string template = "{0}";

        private TMPro.TMP_Text textComponent;
        // Start is called before the first frame update

        private void Awake()
        {
            textComponent = GetComponent<TMPro.TMP_Text>();
            intVariable.GetChanged()?.Register(t => textComponent.text = string.Format(template, t));
            //intVariable.Changed.Raise(textVariable.Value);
        }
    }
}