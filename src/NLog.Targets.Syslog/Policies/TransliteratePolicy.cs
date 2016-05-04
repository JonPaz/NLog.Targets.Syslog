using UnidecodeSharpFork;

namespace NLog.Targets.Syslog.Policies
{
    internal class TransliteratePolicy : IBasicPolicy<string, string>
    {
        private readonly Enforcement enforcement;

        public TransliteratePolicy(Enforcement enforcement)
        {
            this.enforcement = enforcement;
        }

        public bool IsApplicable()
        {
            return enforcement.Transliterate;
        }

        public string Apply(string s)
        {
            return s.Length == 0 ? s : s.Unidecode();
        }
    }
}