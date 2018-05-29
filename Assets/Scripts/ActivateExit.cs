using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateExit : MonoBehaviour {

    public GameObject FindtoExit;
	private void OnTriggerEnter()
    {
        FindtoExit.SetActive(true);
    }
}
