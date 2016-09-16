package
{
	import fl.video.*;
	import flash.display.*;
	import flash.external.*;
	
	public class YUPplayer extends MovieClip
	{
		public function YUPplayer()
		{
			VideoPlayer.iNCManagerClass = FoxNCManager;
			// Align Stage Properly
			// Like Windows Forms
			stage.align = StageAlign.TOP_LEFT;
			
			// Set up video player.
			video.autoRewind = false;
			video.autoPlay = false;
			video.playheadUpdateInterval = 100;
			
			// Internal Handlers
			video.addEventListener(VideoEvent.READY, videoReadyEvent);			
			
			// Flash to C#
			video.addEventListener(VideoEvent.STOPPED_STATE_ENTERED, videoStopStateEvent);
			video.addEventListener(VideoEvent.STATE_CHANGE, videoStateChangeEvent);
			video.addEventListener(VideoEvent.SEEKED, videoSeekedEvent);
			video.addEventListener(VideoEvent.REWIND, videoRewindEvent);
			video.addEventListener(VideoEvent.PLAYING_STATE_ENTERED, videoPlayingStateEvent);
			video.addEventListener(VideoEvent.PLAYHEAD_UPDATE, videoPlayheadUpdateEvent);
			video.addEventListener(VideoEvent.PAUSED_STATE_ENTERED, videoPauseStateEvent);
			video.addEventListener(VideoEvent.FAST_FORWARD, videoFastForwardEvent);
			video.addEventListener(VideoEvent.COMPLETE, videoCompleteEvent);
			video.addEventListener(VideoEvent.BUFFERING_STATE_ENTERED, videoBufferingStateEvent);
			video.addEventListener(VideoEvent.AUTO_REWOUND, videoAutoRewoundEvent);
			video.addEventListener(SoundEvent.SOUND_UPDATE, soundUpdateEvent);
			video.addEventListener(VideoProgressEvent.PROGRESS, videoProgressEvent);
			video.addEventListener(MetadataEvent.METADATA_RECEIVED, videoMetaDataReceivedEvent);
			
			// From C# to Flash
			ExternalInterface.addCallback("playVideo", video.play);
			ExternalInterface.addCallback("pauseVideo", video.pause);
			ExternalInterface.addCallback("stopVideo", video.stop);
			
			ExternalInterface.addCallback("goFullscreen", goFullscreen);
			ExternalInterface.addCallback("rewindVideo", rewindVideo);
			ExternalInterface.addCallback("maintainVideoSizeRatio", maintainVideoSizeRatio);
			ExternalInterface.addCallback("loadVideo", loadVideo);
			ExternalInterface.addCallback("seekVideo", seekVideo);
			ExternalInterface.addCallback("setVolume", setVolume);
			ExternalInterface.addCallback("resetSize", resetSize);
			
			ExternalInterface.call("videoPlayerLoaded");
		}
		
		private function videoReadyEvent(arg1:fl.video.VideoEvent):void
		{
			video.pause();
			video.playWhenEnoughDownloaded();
			
			ExternalInterface.call("videoReadyEvent");
		}
		
		private function videoFastForwardEvent(arg1:fl.video.VideoEvent):void
		{
			ExternalInterface.call("videoFastForwardEvent");
		}

		private function videoStateChangeEvent(arg1:fl.video.VideoEvent):void
		{
			ExternalInterface.call("videoStateChangeEvent", arg1.state);
		}
		
		private function videoPlayheadUpdateEvent(arg1:fl.video.VideoEvent):void
		{
			ExternalInterface.call("videoPlayheadUpdateEvent", video.playheadTime, video.totalTime);
		}
		
		private function videoPlayingStateEvent(arg1:fl.video.VideoEvent):void
		{
			ExternalInterface.call("videoPlayingStateEvent");
		}
		
		private function videoRewindEvent(arg1:fl.video.VideoEvent):void
		{
			ExternalInterface.call("videoRewindEvent");
		}
		
		private function videoCompleteEvent(arg1:fl.video.VideoEvent):void
		{
			ExternalInterface.call("videoCompleteEvent");
		}
		
		private function videoPauseStateEvent(arg1:fl.video.VideoEvent):void
		{
			ExternalInterface.call("videoPauseStateEvent");
		}
		
		private function videoSeekedEvent(arg1:fl.video.VideoEvent):void
		{
			ExternalInterface.call("videoSeekedEvent");
		}
		
		private function videoBufferingStateEvent(arg1:fl.video.VideoEvent):void
		{
			ExternalInterface.call("videoBufferingStateEvent");
		}
		
		private function videoMetaDataReceivedEvent(arg1:MetadataEvent):void
		{
			ExternalInterface.call("videoMetaDataReceivedEvent", arg1.info.duration);
		}
		
		private function videoStopStateEvent(arg1:fl.video.VideoEvent):void
		{
			ExternalInterface.call("videoStopStateEvent");
		}
		
		private function videoAutoRewoundEvent(arg1:fl.video.VideoEvent):void
		{
			ExternalInterface.call("videoAutoRewoundEvent");
		}
		
		private function videoProgressEvent(progressEvent:fl.video.VideoProgressEvent):void
		{
			ExternalInterface.call("videoProgressEvent", progressEvent.bytesLoaded, progressEvent.bytesTotal);
		}
		
		private function soundUpdateEvent(arg1:fl.video.SoundEvent):void
		{
			ExternalInterface.call("soundUpdateEvent", arg1.soundTransform.volume);
		}
		
		private function goFullscreen():void
		{
			video.fullScreenTakeOver = true;
		}
		
		private function rewindVideo(arg1:Boolean):void
		{
			video.autoRewind = arg1;
		}
		
		private function maintainVideoSizeRatio(arg1:Boolean):void
		{
			if (arg1)
			{
				video.scaleMode = VideoScaleMode.MAINTAIN_ASPECT_RATIO;
			}
			else 
			{
				video.scaleMode = VideoScaleMode.EXACT_FIT;
			}
		}
		
		private function loadVideo(arg1:String):void
		{
			video.stop();
			
			// var vPlayer:VideoPlayer = video.getVideoPlayer(video.activeVideoPlayerIndex);
			// vPlayer.flvplayback_internal::_load(arg1);			
			
			//video.source = arg1;
		}
		
		private function seekVideo(arg1:Number):void
		{
			video.seek(arg1);
		}
		
		private function setVolume(arg1:Number=0):void
		{
			video.volume = arg1;
		}
		
		private function resetSize(arg1:Number):void
		{
			video.setSize(stage.stageWidth, stage.stageHeight - arg1);
		}
	}
}