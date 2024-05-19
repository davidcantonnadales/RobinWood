using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using Prime31;


#if UNITY_ANDROID

namespace Prime31
{
	public class AdMobAndroidManager : AbstractManager
	{
		// Fired when a new ad is loaded
		public static event Action receivedAdEvent;
		
		// Fired when an ad fails to be loaded
		public static event Action<string> failedToReceiveAdEvent;
		
		// Fired when a screen event ends (a screen event is an AdMob ad being shown)
		public static event Action dismissingScreenEvent;
		
		// Fired when touching an ad will take the user out of your game
		public static event Action leavingApplicationEvent;
		
		// Fired when a screen event is occurring
		public static event Action presentingScreenEvent;
		
		// Fired when an interstitial is loaded and ready for use
		public static event Action interstitialReceivedAdEvent;
		
		// Fired when an interstitial is dismissed
		public static event Action interstitialDismissingScreenEvent;
		
		// Fired when an interstitial fails to receive an ad
		public static event Action<string> interstitialFailedToReceiveAdEvent;
		
		// Fired when a user action on an interstitial causes them to leave your game
		public static event Action interstitialLeavingApplicationEvent;
		
		// Fired when an interstitial is presented
		public static event Action interstitialPresentingScreenEvent;

		// Fired when an reward based ad is ready to show
		public static event Action rewardBasedAdReceivedEvent;
		
		// Fired when the reward based ad download fails
		public static event Action<string> rewardBasedAdFailedEvent;

		// Fired when a reward based ad is complete and a reward was received. Includes the type (string) and amount (float)
		public static event Action<string,float> rewardBasedAdRewardedUserEvent;

	
		static AdMobAndroidManager()
		{
			AbstractManager.initialize( typeof( AdMobAndroidManager ) );
		}
	
	
		void dismissingScreen( string empty )
		{
			if( dismissingScreenEvent != null )
				dismissingScreenEvent();
		}
	
	
		void failedToReceiveAd( string error )
		{
			if( failedToReceiveAdEvent != null )
				failedToReceiveAdEvent( error );
		}
	
	
		void leavingApplication( string empty )
		{
			if( leavingApplicationEvent != null )
				leavingApplicationEvent();
		}
	
	
		void presentingScreen( string empty )
		{
			if( presentingScreenEvent != null )
				presentingScreenEvent();
		}
	
	
		void receivedAd( string empty )
		{
			if( receivedAdEvent != null )
				receivedAdEvent();
		}
	
	
		void interstitialDismissingScreen( string empty )
		{
			if( interstitialDismissingScreenEvent != null )
				interstitialDismissingScreenEvent();
		}
	
	
		void interstitialFailedToReceiveAd( string error )
		{
			if( interstitialFailedToReceiveAdEvent != null )
				interstitialFailedToReceiveAdEvent( error );
		}
	
	
		void interstitialLeavingApplication( string empty )
		{
			if( interstitialLeavingApplicationEvent != null )
				interstitialLeavingApplicationEvent();
		}
	
	
		void interstitialPresentingScreen( string empty )
		{
			if( interstitialPresentingScreenEvent != null )
				interstitialPresentingScreenEvent();
		}
	
	
		void interstitialReceivedAd( string empty )
		{
			if( interstitialReceivedAdEvent != null )
				interstitialReceivedAdEvent();
		}


		void rewardBasedAdDidReceiveAd( string empty )
		{
			if( rewardBasedAdReceivedEvent != null )
				rewardBasedAdReceivedEvent();
		}


		void rewardBasedAdFailedToReceiveAd( string error )
		{
			if( rewardBasedAdFailedEvent != null )
				rewardBasedAdFailedEvent( error );
		}


		void rewardBasedAdRewardedUser( string data )
		{
			if( rewardBasedAdRewardedUserEvent != null )
			{
				var parts = data.Split( new char[] { '|' } );
				if( parts.Length == 2 )
					rewardBasedAdRewardedUserEvent( parts[0], float.Parse( parts[1] ) );
				else
					Debug.LogError( "invalid data from reward received: " + data );
			}
		}

	}

}
#endif
