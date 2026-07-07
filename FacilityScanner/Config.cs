using Exiled.API.Interfaces;

namespace FacilityScanner
{
    public class Config : IConfig
    {
        public bool IsEnabled { get; set; }
        public bool Debug { get; set; }
        public int ScanMaxPlayerCount { get; set; }
        public string ScanningFacility { get; set; } = "Tesis taranıyor...";
        public string ScanComplete { get; set; } = "Tesis taraması tamamlandı.";
        public string ScanLocation { get; set; } = "Konumlar parse ediliyor...";
        public string Detected { get; set; } = "Tespit edilen:";
        public string RoleScanText { get; set; } = "%name%: %count%";
        public string ChaosInsurgency { get; set; } = "Kaos İsyancıları:";
        public string Ntf { get; set; } = "NTF";
        public string ClassD { get; set; } = "D-sınıfı personel";
        public string Scientist { get; set; } = "Bilim adamı";
        public string FacilityGuard { get; set; } = "Tesis görevlisi";
        public string Heavy { get; set; } = "Ağır muhafaza bölgesi";
        public string Light { get; set; } = "Hafif muhafaza bölgesi";
        public string Entrance { get; set; } = "Giriş bölgesi";
        public string Surface { get; set; } = "Yüzey bölgesi";
        public int FirstScanDelaySeconds { get; set; } = 250;
        public int ScanDelaySeconds { get; set; } = 500;
    }
}