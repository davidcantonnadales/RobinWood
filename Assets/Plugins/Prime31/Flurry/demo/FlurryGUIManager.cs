using UnityEngine;
using System.Collections.Generic;
using Prime31;



namespace Prime31
{
	public class FlurryGUIManager : MonoBehaviourGUI
	{
#if UNITY_IOS
	
		void OnGUI()
		{
			beginColumn();
	
			if( GUILayout.Button( "Start Flurry Session" ) )
			{
				// Optional information
				FlurryAnalytics.setAge( 12 );
				FlurryAnalytics.setGender( "M" );
				
				// replace with your Flurry Key!!!
				FlurryAnalytics.startSession( "XJHB5EGMQ9NCC6XWH43W" );
			}
	
	
			if( GUILayout.Button( "Log Event" ) )
			{
				FlurryAnalytics.logEvent( "Stuff Happened", false );
			}
	
	
			if( GUILayout.Button( "Log Event with Params" ) )
			{
				var dict = new Dictionary<string,string>();
				dict.Add( "akey1", "value1" );
				dict.Add( "bkey2", "value2" );
				dict.Add( "ckey3", "value3" );
				dict.Add( "dkey4", "value4" );
	
				FlurryAnalytics.logEventWithParameters( "EventWithParams", dict, false );
			}
	
	
			if( GUILayout.Button( "Log Timed Event" ) )
			{
				FlurryAnalytics.logEvent( "Timed Event", true );
			}
	
	
			if( GUILayout.Button( "End Timed Event" ) )
			{
				FlurryAnalytics.endTimedEvent( "Timed Event" );
			}
	
	
			if( GUILayout.Button( "Set Reports on Close" ) )
			{
				FlurryAnalytics.setSessionReportsOnCloseEnabled( true );
			}
	
	
			if( GUILayout.Button( "Set Reports on Pause" ) )
			{
				FlurryAnalytics.setSessionReportsOnPauseEnabled( true );
			}
	
	
			endColumn( true );
	
	
			if( GUILayout.Button( "Enable Ads" ) )
			{
				FlurryAds.enableAds( true );
			}
	
	
			if( GUILayout.Button( "Fetch Ads" ) )
			{
				FlurryAds.fetchAdForSpace( "adSpace", FlurryAdSize.Bottom );
				FlurryAds.fetchAdForSpace( "splash", FlurryAdSize.Fullscreen );
			}
	
	
			if( GUILayout.Button( "Check if Ad Available" ) )
			{
				var isAvailable = FlurryAds.isAdAvailableForSpace( "adSpace", FlurryAdSize.Bottom );
				Debug.Log( "is ad available: " + isAvailable );
			}
	
	
			if( GUILayout.Button( "Show Ad on Bottom" ) )
			{
				FlurryAds.displayAdForSpace( "adSpace", FlurryAdSize.Bottom );
			}
	
	
			if( GUILayout.Button( "Fetch and Show Ad" ) )
			{
				FlurryAds.fetchAndDisplayAdForSpace( "adSpace", FlurryAdSize.Top );
			}
	
	
			if( GUILayout.Button( "Show Full Screen Ad" ) )
			{
				FlurryAds.fetchAndDisplayAdForSpace( "splash", FlurryAdSize.Fullscreen );
			}
	
	
			if( GUILayout.Button( "Remove Ad" ) )
			{
				FlurryAds.removeAdFromSpace( "adSpace" );
			}
	
			endColumn();
		}
	
#endif
	}

}
