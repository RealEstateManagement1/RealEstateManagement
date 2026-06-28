namespace Web.Services
{
    public class LanguageService
    {
        private string _currentLanguage = "EN";
        public event Action OnLanguageChanged;

        public string CurrentLanguage
        {
            get => _currentLanguage;
            set
            {
                if (_currentLanguage != value)
                {
                    _currentLanguage = value;
                    OnLanguageChanged?.Invoke();
                }
            }
        }

        // Translation dictionary
        public Dictionary<string, Dictionary<string, string>> Translations = new()
        {
            {
                "EN", new Dictionary<string, string>
                {
                    { "Home", "Home" },
                    { "About", "About" },
                    { "Admin Portal", "Admin Portal" },
                    { "Logout", "Logout" },
                    { "Login", "Login" },
                    { "Get Started", "Get Started" },
                    { "Language", "Language" },
                    { "Active Listings", "Active Listings" },
                    { "Find Your Perfect", "Find Your Perfect" },
                    { "Property", "Property" },
                    { "Verified properties across Rwanda", "Verified properties across Rwanda" },
                    { "Location", "Location" },
                    { "e.g. Gasabo, Kicukiro...", "e.g. Gasabo, Kicukiro..." },
                    { "Currency", "Currency" },
                    { "Type", "Type" },
                    { "For", "For" },
                    { "Budget", "Budget" },
                    { "Sort By", "Sort By" },
                    { "All Types", "All Types" },
                    { "Residential", "Residential" },
                    { "Commercial", "Commercial" },
                    { "Industrial", "Industrial" },
                    { "Agricultural", "Agricultural" },
                    { "All Statuses", "All Statuses" },
                    { "Active", "Active" },
                    { "For Sale", "For Sale" },
                    { "For Rent", "For Rent" },
                    { "All Prices", "All Prices" },
                    { "Under $50,000", "Under $50,000" },
                    { "$50,000 - $150,000", "$50,000 - $150,000" },
                    { "Over $150,000", "Over $150,000" },
                    { "Under 50M RWF", "Under 50M RWF" },
                    { "50M - 150M RWF", "50M - 150M RWF" },
                    { "Over 150M RWF", "Over 150M RWF" },
                    { "Latest Listings", "Latest Listings" },
                    { "Price: Low to High", "Price: Low to High" },
                    { "Price: High to Low", "Price: High to Low" },
                    { "Filters", "Filters" },
                    { "Properties", "Properties" },
                    { "All active listings in Rwanda", "All active listings in Rwanda" },
                    { "List", "List" },
                    { "Map", "Map" },
                    { "Loading Properties...", "Loading Properties..." },
                    { "No Properties Found", "No Properties Found" },
                    { "We couldn't find any properties matching your current filters. Try resetting your search filters or searching a different area.", "We couldn't find any properties matching your current filters. Try resetting your search filters or searching a different area." },
                    { "Clear All Filters", "Clear All Filters" },
                    { "BED", "BED" },
                    { "BATH", "BATH" },
                    { "View Details", "View Details" },
                    { "Service", "Service" },
                }
            },
            {
                "RW", new Dictionary<string, string>
                {
                    { "Home", "Inzira" },
                    { "About", "Ku bijyanye" },
                    { "Admin Portal", "Ahantu h'Ubuyobozi" },
                    { "Logout", "Injira Inyuma" },
                    { "Login", "Injira" },
                    { "Get Started", "Tangira" },
                    { "Language", "Ururimi" },
                    { "Active Listings", "Ibihe Bikora" },
                    { "Find Your Perfect", "Gushaka Ihantu Ryawe" },
                    { "Property", "Ry'ubwiyunge" },
                    { "Verified properties across Rwanda", "Ibihe Byemejwe muri Rwanda" },
                    { "Location", "Umwanya" },
                    { "e.g. Gasabo, Kicukiro...", "Ingero: Gasabo, Kicukiro..." },
                    { "Currency", "Amafaranga" },
                    { "Type", "Ubwoko" },
                    { "For", "Ku" },
                    { "Budget", "Ibyo wahamagaruje" },
                    { "Sort By", "Shakisha" },
                    { "All Types", "Ubwoko bwose" },
                    { "Residential", "Ibihe by'abantu" },
                    { "Commercial", "Ibihe bya Biashobozi" },
                    { "Industrial", "Ibihe by'Inzira" },
                    { "Agricultural", "Ibihe by'Urugo" },
                    { "All Statuses", "Serivisi zose" },
                    { "Active", "Ikora" },
                    { "For Sale", "Gutenguza" },
                    { "For Rent", "Kugura" },
                    { "All Prices", "Ibiciro byose" },
                    { "Under $50,000", "Munsi ya $50,000" },
                    { "$50,000 - $150,000", "$50,000 - $150,000" },
                    { "Over $150,000", "Hejuru ya $150,000" },
                    { "Under 50M RWF", "Munsi ya 50M RWF" },
                    { "50M - 150M RWF", "50M - 150M RWF" },
                    { "Over 150M RWF", "Hejuru ya 150M RWF" },
                    { "Latest Listings", "Ibihe Bishya" },
                    { "Price: Low to High", "Ibiciro: Bito kuri Byinshi" },
                    { "Price: High to Low", "Ibiciro: Byinshi kuri Bito" },
                    { "Filters", "Ishingiro" },
                    { "Properties", "Ibihe" },
                    { "All active listings in Rwanda", "Ibihe byose Bikora muri Rwanda" },
                    { "List", "Urutonde" },
                    { "Map", "Ikarita" },
                    { "Loading Properties...", "Gukoresheza Ibihe..." },
                    { "No Properties Found", "Nta bihe Bibonetse" },
                    { "We couldn't find any properties matching your current filters. Try resetting your search filters or searching a different area.", "Ntaduko dukunze ibihe bihanura ku nzira zacu. Gerageza gushyira inyuma ishingiro ryacu cyangwa gushaka umwanya utandukanye." },
                    { "Clear All Filters", "Sukura Ishingiro Ryose" },
                    { "BED", "IMITI" },
                    { "BATH", "INDARO" },
                    { "View Details", "Menya Ibisobanuro" },
                    { "Service", "Serivisi" },
                }
            }
        };

        public string GetTranslation(string key)
        {
            if (Translations.ContainsKey(_currentLanguage) && Translations[_currentLanguage].ContainsKey(key))
            {
                return Translations[_currentLanguage][key];
            }
            return key; // Return key if translation not found
        }
    }
}
