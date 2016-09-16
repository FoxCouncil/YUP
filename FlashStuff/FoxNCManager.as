package
{
	import fl.video.*;
	
	public class FoxNCManager extends NCManager
	{
		use namespace flvplayback_internal;
		
		override public function connectToURL(url:String):Boolean
		{
			var connected:Boolean = super.connectToURL(url);
			
			if(!connected)
			{
				// The NCManager didn't find the
				// flv extension or found parameters
				// so it will try and load a SMILL file.
				// This thows an error after the movie
				// is loaded because there is no smill file
				// So we stop the file loading.
				if(_smilMgr != null)
				{
					if(_smilMgr.xmlLoader != null)
					_smilMgr.xmlLoader.close();
					_smilMgr = null;
				}
				
				var parseResults:ParseResults = parseURL(_contentPath);
				
				var canReuse:Boolean = canReuseOldConnection(parseResults);
				_isRTMP = false;
				_streamName = parseResults.streamName;
				
				return (canReuse || connectHTTP());
			}
			
			return connected;
		}
	}
}