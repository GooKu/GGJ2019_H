using UnityEngine;
using System.Collections;
 
public class Singleton<T> : MonoBehaviour where T : MonoBehaviour {
  	private static object m_oLock = new object ();
  	private static T m_oInstance;
  	public static T Instance {
    	get {
      		lock (m_oLock) {
        		if (m_oInstance == null) {
					if (GameObject.FindObjectsOfType<T>().Length > 1) Debug.LogError("Multiple singleton!!");
          			m_oInstance = GameObject.FindObjectOfType<T>();
        		}
        		return m_oInstance;
      		}
    	}
  	}
}