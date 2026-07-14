namespace BindingUI.Boost.Editor
{
    internal sealed class BoostIntegrationDefinition
    {
        public string DisplayName { get; }
        public string DefineSymbol { get; }
        public string OfficialUrl { get; }

        public BoostIntegrationDefinition(
            string displayName,
            string defineSymbol,
            string officialUrl)
        {
            DisplayName = displayName;
            DefineSymbol = defineSymbol;
            OfficialUrl = officialUrl;
        }
    }
}