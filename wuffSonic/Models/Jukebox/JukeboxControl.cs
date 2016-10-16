using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace wuffSonic.Models
{
    [XmlRoot(ElementName = "subsonic-response", Namespace = "http://subsonic.org/restapi")]
    public class JukeboxControlResponse
    {
        [XmlAttribute(AttributeName = "version")]
        public string version { get; set; }
        [XmlAttribute(AttributeName = "status")]
        public string status { get; set; }
        [XmlElement(ElementName = "jukeboxStatus")]
        public JukeboxStatus jukeboxStatus { get; set; }
        [XmlElement(ElementName = "jukeboxPlaylist")]
        public JukeboxPlaylist jukeboxPlaylist { get; set; }
    }
    public class JukeboxStatus
    {
        [XmlAttribute(AttributeName = "currentIndex")]
        public string currentIndex { get; set; }
        [XmlAttribute(AttributeName = "playing")]
        public string playing { get; set; }
        [XmlAttribute(AttributeName = "gain")]
        public string gain { get; set; }
        [XmlAttribute(AttributeName = "position")]
        public string position { get; set; }
    }
    public class JukeboxPlaylist : JukeboxStatus
    {
        [XmlAttribute(AttributeName = "entry")]
        public Entry[] entry { get; set; }
    }
    public enum JukeboxControlAction
    {
        get,
        status,
        set,
        start,
        stop,
        skip,
        add,
        clear,
        remove,
        shuffle,
        setGain
    }
    public class JukeboxControl : Request<JukeboxControlResponse>
    {
        /// <summary>
        /// Controls the jukebox, i.e., playback directly on the server's audio hardware. 
        /// Note: The user must be authorized to control the jukebox 
        /// (see Settings > Users > User is allowed to play files in jukebox mode).
        /// </summary>
        public JukeboxControl()
        {

        }
        public JukeboxControlResponse Response
        {
            get
            {
                return (JukeboxControlResponse)_response;
            }
        }
        public override string method
        {
            get
            {
                return "JukeboxControl.view";
            }
        }

        public async Task<JukeboxControlResponse> Get()
        {
            UpdateParams(
                "action", JukeboxControlAction.get.ToString()
                );
            return await DoRequest();
        }
        public async Task<JukeboxControlResponse> Status()
        {
            UpdateParams(
                 "action", JukeboxControlAction.status.ToString()
                );
            return await DoRequest();
        }
        /// <summary>
        /// Add a song to the jukebox playlist.
        /// Similar to a clear followed by a add, but will not change the currently playing track
        /// </summary>
        /// <param name="id">ID of song to add to the jukebox playlist</param>
        /// <returns></returns>
        public async Task<JukeboxControlResponse> Set(string id)
        {
            UpdateParams(
                 "action", JukeboxControlAction.set.ToString(),
                 nameof(id), id
                );
            return await DoRequest();
        }
        public async Task<JukeboxControlResponse> Start()
        {
            UpdateParams(
                 "action", JukeboxControlAction.start.ToString()
                );
            return await DoRequest();
        }
        public async Task<JukeboxControlResponse> Stop()
        {
            UpdateParams(
                 "action", JukeboxControlAction.stop.ToString()
                );
            return await DoRequest();
        }
        /// <summary>
        /// Skip a song of the jukebox playlist.
        /// </summary>
        /// <param name="index">Zero-based index of the song to skip.</param>
        /// <param name="offset">Start playing this many seconds into the track.</param>
        /// <returns></returns>
        public async Task<JukeboxControlResponse> Skip(string index, string offset = "0")
        {
            UpdateParams(
                 "action", JukeboxControlAction.skip.ToString(),
                 nameof(index), index,
                 nameof(offset), offset
                );
            return await DoRequest();
        }
        /// <summary>
        /// Add a song to the jukebox playlist.
        /// </summary>
        /// <param name="id">ID of song to add to the jukebox playlist</param>
        /// <returns></returns>
        public async Task<JukeboxControlResponse> Add(string id)
        {
            UpdateParams(
                 "action", JukeboxControlAction.add.ToString(),
                 nameof(id), id
                );
            return await DoRequest(); ;
        }
        public async Task<JukeboxControlResponse> Clear()
        {
            UpdateParams(
                 "action", JukeboxControlAction.clear.ToString()
                );
            return await DoRequest(); ;
        }
        /// <summary>
        /// Remove a song of the jukebox playlist.
        /// </summary>
        /// <param name="index">Zero-based index of the song to remove.</param>
        /// <returns></returns>
        public async Task<JukeboxControlResponse> Remove(string index)
        {
            UpdateParams(
                 "action", JukeboxControlAction.remove.ToString(),
                 nameof(index), index
                );
            return await DoRequest();
        }
        public async Task<JukeboxControlResponse> Shuffle()
        {
            UpdateParams(
                 "action", JukeboxControlAction.shuffle.ToString()
                );
            return await DoRequest();
        }
        /// <summary>
        /// Controls the playback volume
        /// </summary>
        /// <param name="gain">A float value between 0.0 and 1.0.</param>
        /// <returns></returns>
        public async Task<JukeboxControlResponse> Gain(string gain)
        {
            UpdateParams(
                 "action", JukeboxControlAction.setGain.ToString(),
                 nameof(gain), gain
                );
            return await DoRequest();
        }

        private void UpdateParams(params string[] args)
        {
            parameters = new Dictionary<string, string>();
            if (args != null)
            {
                for (int i = 0; i < args.Length; i += 2)
                {
                    if (args[i] != null && args[i + 1] != null)
                        parameters.Add(args[i], args[i + 1]);
                }
            }
        }
    }
}

