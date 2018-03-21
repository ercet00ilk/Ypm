namespace YPM.SuretVarlik.Mulk.Model.Istisna
{
    public class IstisnaViewModel
    {
        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}