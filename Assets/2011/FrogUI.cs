using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Frog2011 {
    public class FrogUI : MonoBehaviour
    {
        public FrogController frogController;
        public List<Renderer> uiGems; // should be 3;

        public Material gemUIMaterial;
        public Material emptyGemUIMaterial;

        // Start is called before the first frame update
        void Start()
        {
            
        }

        // Update is called once per frame
        void Update()
        {
            for (int i = 0; i < uiGems.Count; i++) {
                uiGems[i].material = (i < frogController.nGems) ? gemUIMaterial : emptyGemUIMaterial;
            }
        }
    }
}