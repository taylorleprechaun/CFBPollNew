using CFBPollDTOs.CFBDataAPI;

namespace CFBPollDTOs
{
    public class Lines
    {
        public double OverUnder { get; set; }
        public string Provider { get; set; }
        public double Spread { get; set; }

        public Lines() { }

        public Lines(double overUnder, string provider, double spread)
        {
            OverUnder = overUnder;
            Provider = provider;
            Spread = spread;
        }

        public Lines(CFBDataAPIBetting apiData)
        {
            OverUnder = apiData?.overUnder ?? 0;
            Provider = apiData?.provider ?? string.Empty;
            Spread = apiData?.spread ?? 0;
        }

        #region public methods

        /// <summary>
        /// Returns if betting data is valid
        /// </summary>
        /// <returns>True if it is. False if it isn't</returns>
        public bool IsValid()
        {
            return OverUnder != 0.0
                && !string.IsNullOrEmpty(Provider)
                && Spread != 0.0;
        }

        #endregion
    }
}
