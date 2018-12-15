using UnityEngine;
using System.Collections;

public class PlayerPrefsManager : MonoBehaviour {

	const string MASTER_VOLUME_KEY = "master_volume";
	const string DIFFICULTY_KEY = "difficulty";
	const string LEVEL_KEY = "level_unlocked_";
	
	
	//---Volume Management 
	public static void SetMasterVolume(float volume){
		if (volume >= 0f && volume <= 1f){
			PlayerPrefs.SetFloat(MASTER_VOLUME_KEY, volume);
		}
		else {
			Debug.LogError("Master volume out of range");
		}
	}
	
	public static float GetMasterVolume(){
		return PlayerPrefs.GetFloat(MASTER_VOLUME_KEY);
	}
	
	
	//---Level Management
	public static void UnlockLevel(int level){
        //Check if there is an additional level to unlock
		if (level <= Application.levelCount - 1){
			//Use 1 for true
			PlayerPrefs.SetInt(LEVEL_KEY + level.ToString(), 1);
		}
		else {
			Debug.LogError ("Attempt to unlock level not in build order");
		}
	}
	
	public static bool IsLevelUnlocked(int level){
		int levelValue = PlayerPrefs.GetInt (LEVEL_KEY + level.ToString());
		bool isLevelUnlocked = (levelValue == 1);
		
		if (level <= Application.levelCount - 1){
			return isLevelUnlocked;
		}
		else {
			Debug.LogError("Attempted query for level not in build order");
			return false;
		}
			
	}
	
	
	//---Difficulty Management
	public static void SetDifficulty(float difficulty){
		//May want difficulty range checker here
		if (difficulty >= 1f && difficulty <= 3f){
			PlayerPrefs.SetFloat(DIFFICULTY_KEY, difficulty);
		}
		else {
			Debug.LogError("Difficulty out of range, 1 - 3");
		}
		
	}
	
	public static float GetDifficulty(){
		return PlayerPrefs.GetFloat(DIFFICULTY_KEY);
	}
	
	
	
	
	
	
	
	
	
	
}
