

using System.Linq;
using System.Text;
using Exiled.API.Enums;
using PlayerRoles;
using PluginAPI.Core;
using Player = Exiled.API.Features.Player;
using Cassie = Exiled.API.Features.Cassie;

namespace FacilityScanner
{
    public class EventHandler
    {
        private Config _config => Plugin.Instance.Config;
        public EventHandler()
        {
            
        }

        internal void UnregisterEvents()
        {
            
        }

        public RoleCounts GetRoleCounts()
        {
            var counts = new RoleCounts();
            
            if (Player.ConnectedCount > _config.ScanMaxPlayerCount) 
                return counts;
            
            foreach (Player player in Player.List.Where(p => p.IsAlive))
            {
                if (player.IsCHI)
                    counts.countChaos++;
                
                if (player.IsNTF)
                    counts.countNtf++;
                
                if (player.Role.Type == RoleTypeId.ClassD)
                    counts.countDClass++;
                
                if (player.Role.Type == RoleTypeId.FacilityGuard)
                    counts.countGuards++;
                
                if (player.Role.Type == RoleTypeId.Scientist)
                    counts.countScientist++;
                
                if (player.IsScp)
                    counts.countScp++;
                
                if (player.Zone == ZoneType.Entrance)
                    counts.countEntrance++;
                
                if (player.Zone == ZoneType.Surface)
                    counts.countSurface++;
                
                if (player.Zone == ZoneType.HeavyContainment)
                    counts.countHeavy++;
                
                if (player.Zone == ZoneType.LightContainment)
                    counts.countLight++;

                return counts;
            }
            
            return counts;
        }

        public void SendCassie()
        {
            RoleCounts counts = GetRoleCounts();
            
            string ChaosCount =  counts.countChaos.ToString();
            string NtfCount =  counts.countNtf.ToString();
            string DClassCount =  counts.countDClass.ToString();
            string GuardCount =  counts.countGuards.ToString();
            string SciCount =  counts.countScientist.ToString();
            
            StringBuilder sbrp = new StringBuilder();
            StringBuilder sbrs = new StringBuilder();

            sbrp.Append();
            
            string HeavyCount =  counts.countHeavy.ToString();
            string LightCount =  counts.countLight.ToString();
            string EntranceCount =  counts.countEntrance.ToString();
            string SurfaceCount =  counts.countSurface.ToString();
            StringBuilder sbzc = new StringBuilder();
            
            Exiled.API.Features.Cassie.MessageTranslated("Scanning facility", _config.ScanningFacility, false, false, true);
            
            Exiled.API.Features.Cassie.MessageTranslated("Scan complete", _config.ScanComplete, false, false, true);
            
            Exiled.API.Features.Cassie.MessageTranslated("Scan complete", _config.ScanComplete, false, false, true);
        }
    }
}