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
        public string RoleScanTextPrimary = "Bilim adamları: %sci% D-sınıfı personel: %dclass% Tesis görevlileri: %guards%";
        public string RoleScanTextSecondary = "Kaos güçleri: %ci% MTF güçleri: %ntf%";
        public string ZoneScanText = "HCZ: %heavy% LCZ: %light% EZ: %entrance% Yüzey: %surface%";
    }
}