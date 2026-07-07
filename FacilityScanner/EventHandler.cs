using System.Text;
using Exiled.API.Features;
using Exiled.Events.EventArgs.Server;
using MEC;

namespace FacilityScanner
{
    public class EventHandler
    {
        private Config _config => Plugin.Instance.Config;
        private Utils _utils;
        private CoroutineHandle _scanCoroutine;
        public EventHandler()
        {
            _utils = new Utils();
            Exiled.Events.Handlers.Server.RoundStarted += OnRoundStart;
            Exiled.Events.Handlers.Server.RoundEnded += OnRoundEnd;
        }

        internal void UnregisterEvents()
        {
            Exiled.Events.Handlers.Server.RoundStarted -= OnRoundStart;
            Exiled.Events.Handlers.Server.RoundEnded -= OnRoundEnd;
            
            if (_scanCoroutine.IsRunning)
                Timing.KillCoroutines(_scanCoroutine);
            
            _utils = null;
        }
        
        public void OnRoundStart()
        {
            _scanCoroutine = Timing.CallDelayed(_config.FirstScanDelaySeconds, SendCassie);
        }

        public void OnRoundEnd(RoundEndedEventArgs ev)
        {
            if (_scanCoroutine.IsRunning)
                Timing.KillCoroutines(_scanCoroutine);
        }
        
        public void SendCassie()
        {
            if (Player.List.Count > _config.ScanMaxPlayerCount) return;
            
            Exiled.API.Features.Cassie.MessageTranslated("Scanning facility", _config.ScanningFacility, false, false);
            RoleCounts counts = _utils.GetRoleCounts();
            Exiled.API.Features.Cassie.MessageTranslated("Scan complete", _config.ScanComplete, false, false);
            Exiled.API.Features.Cassie.MessageTranslated("Detected", _config.Detected, false, false);
            StringBuilder sb = new StringBuilder();
            
            _utils.AnnounceCount(sb, _config.ClassD, counts.countDClass, "Class D personnel");
            _utils.AnnounceCount(sb, _config.Scientist, counts.countScientist, "Science personnel");
            _utils.AnnounceCount(sb, _config.FacilityGuard, counts.countGuards, "Facility guard");
            _utils.AnnounceCount(sb, _config.Ntf, counts.countNtf, "Nine tailed fox");
            _utils.AnnounceCount(sb, _config.ChaosInsurgency, counts.countChaos, "Chaos Insurgency");
            _utils.AnnounceCount(sb, "<color=red>SCP</color>", counts.countScp, "SCP");
            
            Exiled.API.Features.Cassie.MessageTranslated("Parsing location", _config.ScanLocation, false, false);
            
            _utils.AnnounceLocation(sb, _config.Surface, counts.countSurface, "Surface zone");
            _utils.AnnounceLocation(sb, _config.Entrance, counts.countEntrance, "Entrance zone");
            _utils.AnnounceLocation(sb, _config.Heavy, counts.countHeavy, "Heavy containment zone");
            _utils.AnnounceLocation(sb, _config.Light, counts.countLight, "Light containment zone");
            
            _scanCoroutine = Timing.CallDelayed(_config.ScanDelaySeconds, SendCassie);
        }


    }
}