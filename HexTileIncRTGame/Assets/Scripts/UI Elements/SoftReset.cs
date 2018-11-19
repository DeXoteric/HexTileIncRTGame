using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoftReset : MonoBehaviour {

	public void Reset()
    {
        GameDataManager.instance.SoftReset();
    }
}
