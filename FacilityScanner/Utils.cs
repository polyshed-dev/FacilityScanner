using System.Linq;
using System.Text;
using Exiled.API.Enums;
using Exiled.API.Features;
using PlayerRoles;

namespace FacilityScanner
{
    public class Utils
    {
        private Config _config => Plugin.Instance.Config;
        private void SetUpString(StringBuilder sb, string head, int count)
        {
            sb.Clear();
            sb.Append(_config.RoleScanText);
            sb.Replace("%name%", head);
            sb.Replace("%count%", count.ToString());
        }

        public void AnnounceCount(StringBuilder sb, string role, int count, string cassieEnglishRoleName)
        {
            if (count == 0)
                return;
            
            SetUpString(sb, role, count);
            Exiled.API.Features.Cassie.MessageTranslated($"{count} {cassieEnglishRoleName}",sb.ToString() , false, false, true);
        }

        public void AnnounceLocation(StringBuilder sb, string zone, int count, string cassieEnglish)
        {
            if (count == 0)
                return;
            
            SetUpString(sb, zone, count);
            Exiled.API.Features.Cassie.MessageTranslated($"{count} in {cassieEnglish}",sb.ToString() , false, false, true);
        }
        
        public RoleCounts GetRoleCounts()
        {
            RoleCounts counts = new RoleCounts();
            
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
            }
            
            return counts;
        }
    }
}