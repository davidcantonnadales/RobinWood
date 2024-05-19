using UnityEngine;
using System.Collections;

public class GlobalValue : MonoBehaviour {
	public static bool isSound = true;
	public static bool isMusic = true;

	public static string levelReached = "levelReached";
	public static string totalScore = "totalScore";
	public static string perfectLevel = "perfectLevel";		//GlobalValue.perfectLevel + levelNumber

	public static int totalStarGot = 0;
	public static int totalScoreGot = 0;
}
