using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;



namespace Prime31
{
	public class AdMobEventListener : MonoBehaviour
	{
#if UNITY_IOS
		void OnEnable()
		{
			// Listen to all events for illustration purposes
			AdMobManager.receivedAdEvent += adViewDidReceiveAdEvent;
			AdMobManager.failedToReceiveAdEvent += adViewFailedToReceiveAdEvent;
			AdMobManager.interstitialReceivedAdEvent += interstitialDidReceiveAdEvent;
			AdMobManager.interstitialFailedToReceiveAdEvent += interstitialFailedToReceiveAdEvent;
			AdMobManager.interstitialPresentingScreenEvent += interstitialPresentingScreenEvent;
			AdMobManager.interstitialDismissingScreenEvent += interstitialDismissingScreenEvent;
			AdMobManager.interstitialLeavingApplicationEvent += interstitialLeavingApplicationEvent;
			AdMobManager.rewardBasedAdReceivedEvent += rewardBasedAdReceivedEvent;
			AdMobManager.rewardBasedAdFailedEvent += rewardBasedAdFailedEvent;
			AdMobManager.rewardBasedAdRewardedUserEvent += rewardBasedAdRewardedUserEvent;
		}
	
	
		void OnDisable()
		{
			// Remove all event handlers
			AdMobManager.receivedAdEvent -= adViewDidReceiveAdEvent;
			AdMobManager.failedToReceiveAdEvent -= adViewFailedToReceiveAdEvent;
			AdMobManager.interstitialReceivedAdEvent -= interstitialDidReceiveAdEvent;
			AdMobManager.interstitialFailedToReceiveAdEvent -= interstitialFailedToReceiveAdEvent;
			AdMobManager.interstitialPresentingScreenEvent -= interstitialPresentingScreenEvent;
			AdMobManager.interstitialDismissingScreenEvent -= interstitialDismissingScreenEvent;
			AdMobManager.interstitialLeavingApplicationEvent -= interstitialLeavingApplicationEvent;
			AdMobManager.rewardBasedAdReceivedEvent -= rewardBasedAdReceivedEvent;
			AdMobManager.rewardBasedAdReceivedEvent -= rewardBasedAdReceivedEvent;
			AdMobManager.rewardBasedAdRewardedUserEvent -= rewardBasedAdRewardedUserEvent;
		}
	
	
	
		void adViewDidReceiveAdEvent()
		{
			Debug.Log( "adViewDidReceiveAdEvent" );
		}
	
	
		void adViewFailedToReceiveAdEvent( string error )
		{
			Debug.Log( "adViewFailedToReceiveAdEvent: " + error );
		}
	
	
		void interstitialDidReceiveAdEvent()
		{
			Debug.Log( "interstitialDidReceiveAdEvent" );
		}
	
	
		void interstitialFailedToReceiveAdEvent( string error )
		{
			Debug.Log( "interstitialFailedToReceiveAdEvent: " + error );
		}


		void interstitialPresentingScreenEvent()
		{
			Debug.Log( "interstitialPresentingScreenEvent" );
		}


		void interstitialDismissingScreenEvent()
		{
			Debug.Log( "interstitialDismissingScreenEvent" );
		}


		void interstitialLeavingApplicationEvent()
		{
			Debug.Log( "interstitialLeavingApplicationEvent" );
		}


		void rewardBasedAdReceivedEvent()
		{
			Debug.Log( "rewardBasedAdReceivedEvent" );
		}


		void rewardBasedAdFailedEvent( string error )
		{
			Debug.Log( "rewardBasedAdFailedEvent: " + error );
		}


		void rewardBasedAdRewardedUserEvent( string type, float amount )
		{
			Debug.Log( "rewardBasedAdRewardedUserEvent. type: " + type + ", amount: " + amount );
		}
#endif
	}

}
	
	
