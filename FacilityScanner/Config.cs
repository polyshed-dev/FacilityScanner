using Exiled.API.Interfaces;

namespace FacilityScanner
{
    public class Config : IConfig
    {
        public bool IsEnabled { get; set; }
        public bool Debug { get; set; }
        public int ScanMaxPlayerCount { get; set; }
        public string ScanningFacility { get; set; } = "Scanning facility...";
        public string ScanComplete { get; set; } = "Facility scan complete.";
        public string ScanLocation { get; set; } = "Parsing locations...";
        public string Detected { get; set; } = "Detected:";
        public string RoleScanText { get; set; } = "%name%: %count%";
        public string ChaosInsurgency { get; set; } = "Chaos Insurgents:";
        public string Ntf { get; set; } = "NTF";
        public string ClassD { get; set; } = "Class-D Personnel";
        public string Scientist { get; set; } = "Science Personnel";
        public string FacilityGuard { get; set; } = "Security Personnel";
        public string Heavy { get; set; } = "Heavy containment zone";
        public string Light { get; set; } = "Light Containment Zone";
        public string Entrance { get; set; } = "Entrance Zone";
        public string Surface { get; set; } = "Surface Zone";
        public int FirstScanDelaySeconds { get; set; } = 250;
        public int ScanDelaySeconds { get; set; } = 500;
    }
}
