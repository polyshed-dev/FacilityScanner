using System.Text;
using LabApi.Events.Arguments.ServerEvents;
using MEC;
using PluginAPI.Events;

namespace FacilityScanner
{
    public class EventHandler
    {
        private Config _config => Plugin.Instance.Config;
        private Utils _utils;
        public EventHandler()
        {
            _utils = new Utils();
            Exiled.Events.Handlers.Server.RoundStarted += OnRoundStart;
        }

        internal void UnregisterEvents()
        {
            Exiled.Events.Handlers.Server.RoundStarted -= OnRoundStart;
            _utils = null;
        }

        public void SendCassie()
        {
            Exiled.API.Features.Cassie.MessageTranslated("Scanning facility", _config.ScanningFacility, false, false, true);
            RoleCounts counts = _utils.GetRoleCounts();
            Exiled.API.Features.Cassie.MessageTranslated("Scan complete", _config.ScanComplete, false, false, true);
            Exiled.API.Features.Cassie.MessageTranslated("Detected", _config.Detected, false, false, true);
            StringBuilder sb = new StringBuilder();
            
            _utils.AnnounceCount(sb, _config.ClassD, counts.countDClass, "Class D personnel");
            _utils.AnnounceCount(sb, _config.Scientist, counts.countScientist, "Science personnel");
            _utils.AnnounceCount(sb, _config.FacilityGuard, counts.countGuards, "Facility guard");
            _utils.AnnounceCount(sb, _config.Ntf, counts.countNtf, "Nine tailed fox");
            _utils.AnnounceCount(sb, _config.ChaosInsurgency, counts.countChaos, "Chaos Insurgency");
            _utils.AnnounceCount(sb, "<color=red>SCP</color>", counts.countScp, "SCP");
            
            Exiled.API.Features.Cassie.MessageTranslated("Parsing location", _config.ScanLocation, false, false, true);
            
            _utils.AnnounceLocation(sb, _config.Surface, counts.countSurface, "Surface zone");
            _utils.AnnounceLocation(sb, _config.Entrance, counts.countEntrance, "Entrance zone");
            _utils.AnnounceLocation(sb, _config.Heavy, counts.countHeavy, "Heavy containment zone");
            _utils.AnnounceLocation(sb, _config.Light, counts.countLight, "Light containment zone");
        }

        public void OnRoundStart()
        {
            
        }
    }
}