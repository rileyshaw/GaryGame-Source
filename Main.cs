using UnityEngine;
using System.Collections;

public class Main : MonoBehaviour {
	public Info info;
	public GUISkin menu;
	public GUIStyle health;
	public GUIStyle health2;
	public GUIStyle health3;
	/* GUISkins and GUIStyles resemble each other in function, however the skin is an
    asset, while the style is a variable specific to the class instance. GUISkins
    should be used when applied to multiple GUI elements, but when a different one
    is used per element, the style should be used. */
	
	public void ReplaceInfo(Info _info) {
		info.currentHealth= _info.objtransform.parent.transform.GetComponent<cubeenemy>().currenthealth;
		info.maxHealth= _info.objtransform.parent.transform.GetComponent<cubeenemy>().maxhealth;
		info.level= _info.objtransform.parent.transform.GetComponent<cubeenemy>().level;
	}
	// Sets 'info' to the parameter value
	
	void OnGUI() {
		if (info && Vector3.Distance(transform.position, info.transform.position) < 10) {
			/* It confirms that 'info' is assigned the distance between the GameObject of this instance is
            less than ten units from the GameObject of the Info instance. */
			
			GUI.skin = menu;
			// 'menu' is assigned to the following two elements.
			
			GUI.Box(new Rect(Screen.width - 350, 20, 330, 200), GUIContent.none);
			GUI.Label(new Rect(Screen.width - 210, 40, 100, 200), "Level " + info.level + " Cube");
			GUI.Box(new Rect(Screen.width - 270, 60, 200, 30), GUIContent.none, health);
			GUI.Box(new Rect(Screen.width - 270, 60, (info.currentHealth * 200/info.maxHealth), 30), GUIContent.none, health2);
			GUI.Box(new Rect(Screen.width - 270, 60, 200, 30), "Health: " + info.currentHealth + "/" + info.maxHealth, health3);
			// The previous three elements use individual GUIStyles.  
		}
	}
}