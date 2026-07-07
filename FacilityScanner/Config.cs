using Exiled.API.Interfaces;

namespace FacilityScanner
{
    public class Config : IConfig
    {
        public bool IsEnabled { get; set; }
        public bool Debug { get; set; }
        public int ScanMaxPlayerCount { get; set; }
        public string ScanningFacility = "Tesis taranıyor...";
        public string ScanComplete = "Tesis taraması tamamlandı.";
        public string ScanLocation = "Konumlar parse ediliyor...";
        public string Detected = "Tespit edilen:";
        public string RoleScanText = "%name%: %count%";
        public string ChaosInsurgency = "Kaos İsyancıları:";
        public string Ntf = "NTF";
        public string ClassD = "D-sınıfı personel";
        public string Scientist = "Bilim adamı";
        public string FacilityGuard = "Tesis görevlisi";
        public string Heavy = "Ağır muhafaza bölgesi";
        public string Light = "Hafif muhafaza bölgesi";
        public string Entrance = "Giriş bölgesi";
        public string Surface = "Yüzey bölgesi";
    }
}